DROP TABLE IF EXISTS SchedulerColor
CREATE TABLE SchedulerColor(
    ColorID INT IDENTITY(1,1),
    ColorName NVARCHAR(MAX),
    ColorKey VARCHAR(20),
    CreatedDate DATETIME,
    CreatedUser VARCHAR(100),
    ModifiedDate DATETIME,
    ModifiedUser VARCHAR(100)
)