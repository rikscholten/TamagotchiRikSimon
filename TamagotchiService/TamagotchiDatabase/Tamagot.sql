CREATE TABLE [dbo].[Tamagot]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Naam] VARCHAR(50) NOT NULL, 
    [GeboorteTijd] DATETIME NOT NULL DEFAULT  CURRENT_TIMESTAMP, 
    [Honger] INT NOT NULL DEFAULT 0, 
    [Slaap] INT NOT NULL DEFAULT 0, 
    [Verveling] INT NOT NULL DEFAULT 0, 
    [Gezondheid] INT NOT NULL DEFAULT 100,
	CHECK ([Honger]>=0 AND [Honger]<=100),
	[SterfTijd] DATETIME2 NULL, 
    [LastAction] DATETIME2 NULL DEFAULT CURRENT_TIMESTAMP-0.0003
    CHECK ([Honger]>=0 AND [Honger]<=100),
	CHECK ([Slaap]>=0 AND [Slaap]<=100),
	CHECK ([Verveling]>=0 AND [Verveling]<=100),
	CHECK ([Gezondheid]>=0 AND [Gezondheid]<=100)
)
