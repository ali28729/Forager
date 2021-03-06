DROP SCHEMA IF EXISTS Forager;
CREATE SCHEMA Forager;
USE Forager;

CREATE TABLE Document(
doc_ID INT PRIMARY KEY,
doc_URL VARCHAR(150) UNIQUE NOT NULL,
pageRank FLOAT,
doc_Title VARCHAR(100)
);

CREATE TABLE Word(
word_ID INT PRIMARY KEY,
word VARCHAR(30) UNIQUE NOT NULL
);

CREATE TABLE Topic(
topic_ID INT PRIMARY KEY AUTO_INCREMENT,
topid_Desc VARCHAR(30) NOT NULL
);

CREATE TABLE default_User(
user_ID INT PRIMARY KEY AUTO_INCREMENT,
IP_address VARCHAR(15)
);

CREATE TABLE registered_User(
user_ID INT PRIMARY KEY REFERENCES defaultUser(userID),
Fname VARCHAR(15),
Minit VARCHAR(1),
Lname VARCHAR(15),
login_ID VARCHAR(20) NOT NULL,
user_Pass VARCHAR(20) NOT NULL,
is_Admin BOOL,
email_ID VARCHAR(30)
);

CREATE TABLE Advertisement(
ad_ID INT PRIMARY KEY AUTO_INCREMENT,
image_URL VARCHAR(50) NOT NULL
);

CREATE TABLE User_Session(
user_ID INT REFERENCES default_User(user_ID),
Session_ID INT,
start_Time DATETIME,
end_Time DATETIME,
CONSTRAINT user_session_pk PRIMARY KEY(user_ID,Session_ID)
);

CREATE TABLE Anchors_From(
source_ID INT REFERENCES Document(doc_ID) ON DELETE CASCADE,
target_ID INT REFERENCES Document(doc_ID) ON DELETE CASCADE,
anchor_Text VARCHAR(150)
);

CREATE TABLE Hits(
doc_ID INT REFERENCES Document(doc_ID) ON DELETE CASCADE,
word_ID INT REFERENCES Word(word_ID) ON DELETE CASCADE,
w_Position INT,
font_Size INT,
is_Anchor BOOL
);

CREATE TABLE doc_Accessed(
Session_ID INT NOT NULL REFERENCES User_Session(Session_ID),
doc_ID INT  NOT NULL REFERENCES Document(doc_ID) 
);

CREATE TABLE Likes(
user_ID INT NOT NULL REFERENCES default_User(user_ID),
topic_ID INT NOT NULL REFERENCES Topic(topic_ID)
);

CREATE TABLE doc_Belongs_To(
doc_ID INT NOT NULL REFERENCES document(doc_ID),
topic_ID INT NOT NULL REFERENCES Topic(topic_ID) 
);

CREATE TABLE ad_Belongs_To(
ad_ID INT NOT NULL REFERENCES Advertisement(ad_ID),
topic_ID INT NOT NULL REFERENCES Topic(topic_ID) 
);
