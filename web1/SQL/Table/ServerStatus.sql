DROP TABLE IF EXISTS ServerStatus

CREATE TABLE ServerStatus(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    [Status] BIT,
    StartTime DATETIME,
    EndTime DATETIME,
    IsVaild BIT,
    CreatedDate DATETIME,
    CreatedUser VARCHAR(100),
    ModifiedDate DATETIME,
    ModifiedUser VARCHAR(100)
)