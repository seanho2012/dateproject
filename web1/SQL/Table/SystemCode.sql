DROP TABLE IF EXISTS SystemCode
CREATE TABLE SystemCode(
    SystemCode VARCHAR(MAX),
    CodeType VARCHAR(MAX),
    CodeName NVARCHAR(MAX),
    CreatedDate DATETIME,
    CreatedUser VARCHAR(100),
    ModifiedDate DATETIME,
    ModifiedUser VARCHAR(100)
)