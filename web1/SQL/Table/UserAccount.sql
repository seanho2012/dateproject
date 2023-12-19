DROP TABLE IF EXISTS LineProfile
CREATE TABLE LineProfile(
    LineProfileID BIGINT IDENTITY(1,1),
    UserID BIGINT,
    iss VARCHAR(200),
    sub VARCHAR(MAX),
    aud VARCHAR(20),
    exp VARCHAR(10),
    iat VARCHAR(10),
    nonce VARCHAR(MAX),
    amr VARCHAR(15),
    name NVARCHAR(20),
    picture VARCHAR(MAX),
    email VARCHAR(320),
)