CREATE TABLE UserProfile(
    UserID BIGINT,
    Account VARCHAR(100),
    [PassWord] VARCHAR(MAX),
    UserName VARCHAR(100)
)
CREATE TABLE SystemCode(
    SystemCode VARCHAR(MAX),
    CodeType VARCHAR(MAX),
    CodeName VARCHAR(MAX)
)
CREATE TABLE ServerStatus(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    [Status] BIT,
    StartTime DATETIME,
    EndTime DATETIME,
    IsVaild INT
)
DROP TABLE ServerStatus
INSERT INTO UserProfile VALUES(1,'Admin','1234','Admin')
INSERT INTO SystemCode VALUES('1','ServerStatus','Online')
INSERT INTO SystemCode VALUES('0','ServerStatus','Offline')
INSERT INTO ServerStatus ([Status],StartTime,EndTime,IsVaild)
VALUES(0,GETDATE(),NULL,1)
SELECT * FROM ServerStatus;
SELECT * FROM fnGetServerStatus()
exec spChangeServerStatus @ServerStatus='1'