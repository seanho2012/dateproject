DROP TABLE IF EXISTS UserProfile
CREATE TABLE UserProfile(
    UserID BIGINT IDENTITY(1,1),
    PersonID BIGINT,
    UserName NVARCHAR(100),
    Phone VARCHAR(20),
    Email VARCHAR(100),
    HomeAddress NVARCHAR(100),
    CreatedDate DATETIME,
    CreatedUser VARCHAR(100),
    ModifiedDate DATETIME,
    ModifiedUser VARCHAR(100)
)