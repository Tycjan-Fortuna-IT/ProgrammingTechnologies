﻿CREATE TABLE [dbo].[Products]
(
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(255) NOT NULL,
	[price] DECIMAL NOT NULL,
	[pegi] INTEGER NOT NULL
)