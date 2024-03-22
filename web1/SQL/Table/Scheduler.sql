DROP TABLE IF EXISTS Scheduler
CREATE TABLE Scheduler(
    SchedulerID BIGINT IDENTITY(1,1),
    StartTime DATETIME,
    EndTime DATETIME,
    Title NVARCHAR(20),
    [Description] NVARCHAR(MAX),
    [Location] NVARCHAR(MAX),
    ColorID INT,
    CreatedDate DATETIME,
    CreatedUser VARCHAR(100),
    ModifiedDate DATETIME,
    ModifiedUser VARCHAR(100)
)