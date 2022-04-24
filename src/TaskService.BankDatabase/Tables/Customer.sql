CREATE TABLE [dbo].[Customer] (
    [CustomerID]            INT          IDENTITY (1, 1) NOT NULL,
    [AccountID]             INT          NOT NULL,
    [CustomerAddress2]      VARCHAR (30) NULL,
    [CustomerFirstName]     VARCHAR (30) NOT NULL,
    [CustomerMiddleInitial] CHAR (1)     NULL,
    [CustomerLastName]      VARCHAR (30) NOT NULL,
    [City]                  VARCHAR (20) NOT NULL,
    [State]                 CHAR (2)     NOT NULL,
    [ZipCode]               CHAR (10)    NOT NULL,
    [EmailAddress]          CHAR (40)    NOT NULL,
    [HomePhone]             VARCHAR (10) NOT NULL,
    [CellPhone]             VARCHAR (10) NOT NULL,
    [WorkPhone]             VARCHAR (10) NOT NULL,
    [SSN]                   VARCHAR (9)  NULL,
    [UserLoginID]           SMALLINT     NOT NULL,
    CONSTRAINT [pk_C_CustomerID] PRIMARY KEY CLUSTERED ([CustomerID] ASC),
    CONSTRAINT [fk_A_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([AccountID]),
    CONSTRAINT [fk_UL_C_UserLoginID] FOREIGN KEY ([UserLoginID]) REFERENCES [dbo].[UserLogins] ([UserLoginID])
);

