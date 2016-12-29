from bs4 import BeautifulSoup,Comment
from os import listdir
from urllib.parse import urljoin
import pymysql
import string

basePath=r'C://Users//Sohaib//Desktop//HTMLPages//'
pageList= listdir(basePath)
baseURL='https://en.wikipedia.org/wiki/'

anchors=[]
wordSet = dict()
conn = pymysql.connect(host='localhost', port=3306, user='root', passwd='of88line', db='Forager')
curr = conn.cursor()
curr.execute("""SELECT word,word_id FROM word;""")

for row in curr:
    wordSet[row[0]]=row[1]

for page in pageList:
    pageID = page.replace('.html','')
    soup = BeautifulSoup(open(basePath+page, "rb"),"html.parser")
    newWordSet = dict()
    pageURL = soup.findAll(text=lambda text:isinstance(text, Comment))[0]

    for i in range(1,7):
        print(i)
    h1tags = soup.find_all('h1')
    h2tags = soup.find_all('h2')
    h3tags = soup.find_all('h3')
    h4tags = soup.find_all('h4')
    h5tags = soup.find_all('h5')
    h6tags = soup.find_all('h6')
    ptags = soup.find_all('p')

    h1Contents=""
    h2Contents=""
    h3Contents=""
    h4Contents=""
    h5Contents=""
    h6Contents=""
    pContents=""

    for tag in h1tags:
        for content in tag.contents:
            if content.string != "" and content.string is not None:
                h1Contents += ' '+content.string.lower().translate(str.maketrans('','',string.punctuation))

    for tag in h2tags:
        for content in tag.contents:
            if content.string !="" and content.string is not None:
                h2Contents += ' '+content.string.lower().translate(str.maketrans('','',string.punctuation))

    for tag in h3tags:
        for content in tag.contents:
            if content.string !="" and content.string is not None:
                h3Contents+=' '+content.string.lower().translate(str.maketrans('','',string.punctuation))

    for tag in h4tags:
        for content in tag.contents:
            if content.string !="" and content.string is not None:
                h4Contents+=' '+content.string.lower().translate(str.maketrans('','',string.punctuation))

    for tag in h5tags:
        for content in tag.contents:
            if content.string !="" and content.string is not None:
                h5Contents+=' '+content.string.lower().translate(str.maketrans('','',string.punctuation))

    for tag in h6tags:
        for content in tag.contents:
            if content.string !="" and content.string is not None:
                h6Contents+=' '+content.string.lower().translate(str.maketrans('','',string.punctuation))

    for ptag in ptags:
        for content in ptag.contents:
            if content.string !="" and content.string is not None:
                pContents += ' '+content.string.lower().translate(str.maketrans('', '', string.punctuation))

    for link in soup.findAll('a', href=True):
        if link['href'][0] is not'#':
                anchors.append((pageID, urljoin(baseURL, link['href']), link.string))

    #Done: Add page data to the database "document" table. If already added, do cleanup of data
    curr.execute("""INSERT INTO document (doc_ID, doc_URL, pageRank, doc_Title) VALUES
                    (%s, %s,null, %s)""", (pageID, pageURL, h1Contents))

    h1List = h1Contents.split()
    h2List = h2Contents.split()
    h3List = h3Contents.split()
    h4List = h4Contents.split()
    h5List = h5Contents.split()
    h6List = h6Contents.split()
    pList = pContents.split()

    i=0
    for word in h1List:
        i+=1
        if word in wordSet:
            wordID=wordSet[word]
        else:
            if word not in newWordSet:
            newWordSet[word]=len(wordSet)+len(newWordSet)+1
            wordID=newWordSet[word]
            curr.execute("""INSERT INTO word VALUES (%s,%s);""", (wordID,word))
        curr.execute("""INSERT INTO hits VALUES (%s,%s,%s,7,false);""", (pageID,wordID,i))

    #TODO: Add the newWordSet to the words table in DataBase
    wordSet.update(newWordSet)
    print(h1List)
    #print(h2List)
    # print(h3List)
    # print(h4List)
    # print(h5List)
    # print(h6List)
    # print(pList)
    conn.commit()
