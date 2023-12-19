DROP TABLE IF EXISTS Person
CREATE TABLE Person(
    PersonID BIGINT IDENTITY(1,1),
    FullName NVARCHAR(100),
    GenderCode VARCHAR(1),
    DateOfBirth DATETIME,
    BloodType VARCHAR(2),
    CreatedDate DATETIME,
    CreatedUser VARCHAR(100),
    ModifiedDate DATETIME,
    ModifiedUser VARCHAR(100)
)