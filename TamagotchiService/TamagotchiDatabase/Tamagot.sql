﻿CREATE TABLE [dbo].[Tamagot]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Naam] VARCHAR(50) NOT NULL, 
    [Leeftijd] INT NOT NULL DEFAULT 0, 
    [Honger] INT NOT NULL DEFAULT 0, 
    [Slaap] INT NOT NULL DEFAULT 0, 
    [Verveling] INT NOT NULL DEFAULT 0, 
    [Gezondheid] INT NOT NULL DEFAULT 100
)
