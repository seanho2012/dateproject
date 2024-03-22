DELETE FROM SchedulerColor
DBCC CHECKIDENT ('SchedulerColor', RESEED, 0);
INSERT INTO SchedulerColor (ColorName, ColorKey, CreatedDate, CreatedUser, ModifiedDate, ModifiedUser) 
SELECT N'藍色', 'blue', GETDATE(), 'System', GETDATE(), 'System'
UNION SELECT N'綠色', 'green', GETDATE(), 'System', GETDATE(), 'System'
UNION SELECT N'紅色', 'red', GETDATE(), 'System', GETDATE(), 'System'