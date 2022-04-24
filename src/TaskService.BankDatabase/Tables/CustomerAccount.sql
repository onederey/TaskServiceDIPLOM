CREATE TABLE [dbo].[CustomerAccount] (
    [AccountID]  INT NOT NULL,
    [CustomerID] INT NOT NULL,
    CONSTRAINT [fk_A_CA_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([AccountID]),
    CONSTRAINT [fk_C_CA_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

