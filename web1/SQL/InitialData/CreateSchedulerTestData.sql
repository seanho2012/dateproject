DELETE FROM Scheduler
DBCC CHECKIDENT ('Scheduler', RESEED, 0);
INSERT INTO Scheduler (StartTime, EndTime, Title, Description, Location, ColorID, CreatedDate, CreatedUser, ModifiedDate, ModifiedUser) 
SELECT GETDATE(), DATEADD(MINUTE, 60, GETDATE()), N'行程1', N'描述1', N'地點1', 1, GETDATE(), 'System', GETDATE(), 'System'
UNION SELECT DATEADD(MINUTE, 180, GETDATE()), DATEADD(MINUTE, 240, GETDATE()), N'行程2', N'描述2', N'地點2', 2, GETDATE(), 'System', GETDATE(), 'System'
UNION SELECT DATEADD(MINUTE, 300, GETDATE()), DATEADD(MINUTE, 360, GETDATE()), N'行程3', N'描述3', N'地點3', 3, GETDATE(), 'System', GETDATE(), 'System'