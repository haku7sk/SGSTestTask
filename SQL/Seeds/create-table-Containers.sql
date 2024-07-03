CREATE TABLE Containers (
    ID UUID PRIMARY KEY,
    Number INT,
    Type VARCHAR(100),
    Length NUMERIC(10, 2),
    Width NUMERIC(10, 2),
    Height NUMERIC(10, 2),
    Weight NUMERIC(10, 2),
    IsEmpty BOOLEAN,
    DateReceived TIMESTAMP
);