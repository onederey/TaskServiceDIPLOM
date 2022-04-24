CREATE TABLE [dbo].[ServiceTasks] (
    [TaskID]          INT            NOT NULL,
    [IsEnabled]       BIT            NOT NULL,
    [TaskType]        INT            NULL,
    [Branch]          INT            NULL,
    [TaskName]        NVARCHAR (50)  NOT NULL,
    [LastWorkTime]    DATETIME       NULL,
    [TaskStartTime]   DATETIME       NOT NULL,
    [TaskEndTime]     DATETIME       NOT NULL,
    [Dependency]      NVARCHAR (100) NOT NULL,
    [FilePath]        NVARCHAR (50)  NULL,
    [FieldsCount]     INT            NULL,
    [FieldsSeparator] NVARCHAR (5)   NULL,
    [Params]          NVARCHAR(300)  NULL,
    [ModifiedBy]      NVARCHAR (50)  NOT NULL,
    [AuthoriziedBy]   NVARCHAR (50)  NOT NULL,
    [Description]     NVARCHAR (250) NULL,
    [ManualStart]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([TaskID] ASC),
    FOREIGN KEY ([Branch]) REFERENCES [dbo].[Branches] ([BranchCode]),
    FOREIGN KEY ([TaskType]) REFERENCES [dbo].[TaskTypes] ([Id])
);

