__author__ = 'Sohaib'
from bs4 import BeautifulSoup,Comment
from os import listdir
from urllib.parse import urljoin
import pymysql
import string
from unidecode import unidecode

def replace_trash(unicode_string):
     for i in range(0, len(unicode_string)):
         try:
             unicode_string[i].encode("ascii")
         except:
              #means it's non-ASCII
              unicode_string.replace(unicode_string[i],"") #replacing it with a single space
     return unicode_string

basePath=r'C://Users//Sohaib//Desktop//HTMLPages//'
pageList= listdir(basePath)
baseURL='https://en.wikipedia.org/wiki/'

anchors=[]
indexed=set()
oldindexed=set()
wordSet = dict()
conn = pymysql.connect(host='localhost', port=3306, user='root', passwd='of88line', db='Forager', use_unicode=True, charset="utf8")
curr = conn.cursor()

curr.execute("""SELECT doc_id FROM document;""")
for row in curr:
    oldindexed.add(row[0])

curr.execute("""SELECT word,word_id FROM word;""")
for row in curr:
    wordSet[row[0]]=row[1]

for page in pageList:
    pageID = page.replace('.html','')
    soup = BeautifulSoup(open(basePath+page, "rb"),"html.parser")
    newWordSet = dict()
    pageURL = soup.findAll(text=lambda text:isinstance(text, Comment))[0]

    if pageURL in indexed:
        continue
    else:
        indexed.add(pageURL.string)

    if int(pageID) in oldindexed:
        print('DELETING')
        curr.execute("""DELETE FROM document WHERE doc_id =%s;""",pageID)

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
    pageURL=replace_trash(pageURL)
    h1Contents=replace_trash(h1Contents)
    try:
        curr.execute("""INSERT INTO document (doc_ID, doc_URL, pageRank, doc_Title) VALUES
                    (%s, %s,null, %s)""", (pageID, pageURL, h1Contents[0:100]))
    except pymysql.err.DataError:
        pass

    h1List = h1Contents.split()
    h2List = h2Contents.split()
    h3List = h3Contents.split()
    h4List = h4Contents.split()
    h5List = h5Contents.split()
    h6List = h6Contents.split()
    pList = pContents.split()



    listOflists=[pList,h6List,h5List,h4List,h3List,h2List,h1List]
    j=0
    for list in listOflists:
        j+=1
        i=0
        for word in list:
            i+=1
            if word not in wordSet:
                wordSet[word]=len(wordSet)+1
                try:
                    curr.execute("""INSERT INTO word VALUES (%s,%s);""", (wordSet[word],word[0:30]))
                except pymysql.err.IntegrityError:
                    pass
            wordID=wordSet[word]
            curr.execute("""INSERT INTO hits VALUES (%s,%s,%s,%s,false);""", (pageID,wordID,i,j))
    wordSet.update(newWordSet)
    conn.commit()
    print(len( indexed))

curr.execute('SELECT doc_id,doc_URL FROM document;')
URLtoID=dict()
for row in curr:
    URLtoID[row[1]]=row[0]

IDanchors=[]

for anchor in anchors:
    if anchor[1] in URLtoID:
        IDanchors.append((anchor[0],URLtoI^D[anchor[1]],anchor[2]))
    anchors.remove(anchor)

print(IDanchors)

for anchor in IDanchors:
    #print(anchor)
    if anchor[2] is not None:
        curr.execute("""INSERT INTO anchors_from VALUES (%s,%s,%s);""", (anchor[0],anchor[1],anchor[2][0:150]))
        anchortext=anchor[2].split()
        for word in anchortext:
            if word not in wordSet:
                wordSet[word]=len(wordSet)+1
                try:
                    curr.execute("""INSERT INTO word VALUES (%s,%s);""", (wordSet[word],word[0:30]))
                except pymysql.err.IntegrityError:
                    pass
                except pymysql.err.DataError:
                    pass
            wordID=wordSet[word]
            curr.execute("""INSERT INTO hits VALUES (%s,%s,0,0,true);""", (anchor[1],wordID))
conn.commit()
