
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/09/2012 15:00:18
-- Generated from EDMX file: D:\Visual Studio Workspace\BDSA2012\Assignment40\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[OOAD].[FK_job_ibfk_1]', 'F') IS NOT NULL
    ALTER TABLE [OOAD].[job] DROP CONSTRAINT [FK_job_ibfk_1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[OOAD].[job]', 'U') IS NOT NULL
    DROP TABLE [OOAD].[job];
GO
IF OBJECT_ID(N'[OOAD].[user]', 'U') IS NOT NULL
    DROP TABLE [OOAD].[user];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'jobs'
CREATE TABLE [dbo].[jobs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [state] longtext  NULL,
    [subDate] datetime  NULL,
    [userId] int  NOT NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] longtext  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'jobs'
ALTER TABLE [dbo].[jobs]
ADD CONSTRAINT [PK_jobs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [userId] in table 'jobs'
ALTER TABLE [dbo].[jobs]
ADD CONSTRAINT [FK_job_ibfk_1]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_job_ibfk_1'
CREATE INDEX [IX_FK_job_ibfk_1]
ON [dbo].[jobs]
    ([userId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------