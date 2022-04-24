SET IDENTITY_INSERT [dbBankGM].[dbo].[Events] ON
GO

INSERT INTO [dbBankGM].[dbo].[Events] (EventID, [Description])
VALUES
    (0, 'Trace'),
    (1, 'UserAction')
GO

SET IDENTITY_INSERT [dbBankGM].[dbo].[Events] OFF
GO


SET IDENTITY_INSERT [dbBankGM].[dbo].[Users] ON
GO

INSERT INTO [dbBankGM].[dbo].[Users] (Id, Username, Privileges, PassHash)
VALUES
    (-100, 'TaskService', 'ServicePrivelege', 'NO PASS')
GO

SET IDENTITY_INSERT [dbBankGM].[dbo].[Users] OFF
GO