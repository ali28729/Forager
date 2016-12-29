from bs4 import BeautifulSoup,Comment
from os import listdir
from urllib.parse import urljoin
import string

basePath=r'C://Users//Sohaib//Desktop//HTMLPages//'
pageList= listdir(basePath)
baseURL='https://en.wikipedia.org/wiki/'

for page in pageList:
    pageID=page.replace('.html','')
    soup =BeautifulSoup(open(basePath+page, "rb"),"html.parser")
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


    h1List = h1Contents.split()
    h2List = h2Contents.split()
    h3List = h3Contents.split()
    h4List = h4Contents.split()
    h5List = h5Contents.split()
    h6List = h6Contents.split()
    pList = pContents.split()
    print(h1List)
    print(h2List)
    print(h3List)
    print(h4List)
    print(h5List)
    print(h6List)
    print(pList)
