-- 1.1 Query

SELECT Name, City
FROM Person
WHERE City IN (
    SELECT City
    FROM Person
    GROUP BY City
    HAVING COUNT(*) > 1
);



-- 1.2 CRUD – output (atomic query)

UPDATE Person
SET City = @NewCity
OUTPUT 
    deleted.Name, 
    deleted.City, 
    GETDATE()
INTO Log (Name, City, ModifiedDate)
WHERE Name = @Name;

