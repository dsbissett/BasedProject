;WITH x AS 
(
  SELECT TOP (1000000) s1.[object_id]
  FROM sys.all_objects AS s1
  CROSS JOIN sys.all_objects AS s2
  ORDER BY s1.[object_id]
)
INSERT dbo.RandomNumber(RowID, Value)
SELECT
    r = ROW_NUMBER() OVER (ORDER BY [object_id]),
    n = ROW_NUMBER() OVER (ORDER BY NEWID())
FROM x
ORDER BY r;
