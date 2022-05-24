﻿CREATE TABLE [dbo].[Logs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Event] INT NOT NULL,
	[Description] NVARCHAR(1000) NOT NULL,
	[DateTime] DATETIME NOT NULL,
	[UserID] INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	[Application] NVARCHAR(50) NOT NULL,
	FOREIGN KEY ([Event]) REFERENCES [dbo].[Events] ([EventId])
)
