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

-- Task CBR
INSERT INTO dbo.ServiceTasks 
    (TaskID, [IsEnabled],[TaskType],[Branch],
     [TaskName],[LastWorkTime],[TaskStartTime],
     [TaskEndTime],[Dependency],[FilePath],
     [FieldsCount],[FieldsSeparator],[Params],
     [ModifiedBy],[AuthoriziedBy],[Description],[ManualStart])
VALUES
    (0, 1, 1, 0,
     'CurrentCBRRates', null, '2022-05-01 01:00:00',
     '2022-05-01 23:59:00', '', null,
     null, null, null,
     'Andrej', 'Andrej', 'CBR Rates', 0)


