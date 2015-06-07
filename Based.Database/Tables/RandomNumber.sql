CREATE TABLE dbo.RandomNumber
(
  RowID INT,
  Value INT UNIQUE,
  PRIMARY KEY (RowID, Value)
);