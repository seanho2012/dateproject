DROP TABLE IF EXISTS UserProfile
CREATE TABLE UserProfile(
    UserID BIGINT IDENTITY(1,1),
    UserName VARCHAR(100),
    LineProfile INT,
    Phone VARCHAR(20),
    Email VARCHAR(100),
    HomeAddress NVARCHAR(100)
)