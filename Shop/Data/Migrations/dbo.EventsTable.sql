﻿CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Guid] UNIQUEIDENTIFIER NOT NULL, 
    [stateGuid] UNIQUEIDENTIFIER NOT NULL, 
    [userGuid] UNIQUEIDENTIFIER NOT NULL, 
    [occurrenceDate] DATE NOT NULL
)
