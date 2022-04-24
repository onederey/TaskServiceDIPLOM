
CREATE PROCEDURE sp_Customer_Details @AccountID INT
AS
SELECT c.CustomerFirstName + ' ' + c.CustomerMIddleInitial + ' ' + c.CustomerLastName AS Customer_Full_Name
FROM Customer c
JOIN Account a
ON c.AccountID = a.AccountId
WHERE a.AccountID = @AccountID;
