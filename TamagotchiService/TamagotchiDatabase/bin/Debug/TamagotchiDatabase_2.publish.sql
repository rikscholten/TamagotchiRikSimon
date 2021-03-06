﻿/*
Deployment script for TamagotchiRikSimon

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TamagotchiRikSimon"
:setvar DefaultFilePrefix "TamagotchiRikSimon"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
PRINT N'Dropping unnamed constraint on [dbo].[Tamagot]...';


GO
ALTER TABLE [dbo].[Tamagot] DROP CONSTRAINT [DF__Tamagot__Leeftij__36B12243];


GO
PRINT N'Dropping unnamed constraint on [dbo].[Tamagot]...';


GO
ALTER TABLE [dbo].[Tamagot] DROP CONSTRAINT [DF__Tamagot__Honger__37A5467C];


GO
PRINT N'Dropping unnamed constraint on [dbo].[Tamagot]...';


GO
ALTER TABLE [dbo].[Tamagot] DROP CONSTRAINT [DF__Tamagot__Slaap__38996AB5];


GO
PRINT N'Dropping unnamed constraint on [dbo].[Tamagot]...';


GO
ALTER TABLE [dbo].[Tamagot] DROP CONSTRAINT [DF__Tamagot__Verveli__398D8EEE];


GO
PRINT N'Dropping unnamed constraint on [dbo].[Tamagot]...';


GO
ALTER TABLE [dbo].[Tamagot] DROP CONSTRAINT [DF__Tamagot__Gezondh__3A81B327];


GO
PRINT N'Starting rebuilding table [dbo].[Tamagot]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Tamagot] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Naam]       VARCHAR (50) NOT NULL,
    [Leeftijd]   INT          DEFAULT 0 NOT NULL,
    [Honger]     INT          DEFAULT 0 NOT NULL,
    [Slaap]      INT          DEFAULT 0 NOT NULL,
    [Verveling]  INT          DEFAULT 0 NOT NULL,
    [Gezondheid] INT          DEFAULT 100 NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Tamagot])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tamagot] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Tamagot] ([Id], [Naam], [Leeftijd], [Honger], [Slaap], [Verveling], [Gezondheid])
        SELECT   [Id],
                 [Naam],
                 [Leeftijd],
                 [Honger],
                 [Slaap],
                 [Verveling],
                 [Gezondheid]
        FROM     [dbo].[Tamagot]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tamagot] OFF;
    END

DROP TABLE [dbo].[Tamagot];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Tamagot]', N'Tamagot';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO
