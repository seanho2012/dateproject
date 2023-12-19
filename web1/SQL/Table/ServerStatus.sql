DROP TABLE IF EXISTS ServerStatus

CREATE TABLE ServerStatus(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    [Status] BIT,
    StartTime DATETIME,
    EndTime DATETIME,
    IsVaild BIT
)