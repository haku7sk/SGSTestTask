CREATE TABLE Operations (
    ID UUID PRIMARY KEY,
    ContainerID UUID,
    StartDate TIMESTAMP,
    EndDate TIMESTAMP,
    OperationType VARCHAR(100),
    OperatorName VARCHAR(200),
    InspectionPlace VARCHAR(200),
    FOREIGN KEY (ContainerID) REFERENCES Containers(ID)
);