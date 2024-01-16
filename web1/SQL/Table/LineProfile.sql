DROP TABLE IF EXISTS LineProfile
CREATE TABLE LineProfile(
    LineProfileID BIGINT IDENTITY(1,1),
    sub VARCHAR(MAX),
    aud VARCHAR(20),
    name NVARCHAR(20),
    picture VARCHAR(MAX),
    email VARCHAR(320),
    UserID BIGINT,
    CreatedDate DATETIME,
    CreatedUser VARCHAR(100),
    ModifiedDate DATETIME,
    ModifiedUser VARCHAR(100)
)
-- INSERT INTO LineProfile (sub,aud,name,picture,email,UserID,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser) VALUES
-- (
--     'U0e6dda4339a3416bfab6a066b39d60bc'
--     , '2002213577'
--     , '何擎'
--     , 'https://profile.line-scdn.net/0h4n2hovL0a0EPEXihG-0UFjNUZSx4P20Jd3MgIH0XYCMiIy8QYSBxJCkVMXl3IXgfMCN3J38VMyQh'
--     , 'seanho2012@gmail.com'
--     , 1
--     , GETDATE()
--     , 'System'
--     , GETDATE()
--     , 'System'
-- )