
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2014 02:01:33
-- Generated from EDMX file: C:\Users\hoanh\Google Drive\pluralsight\postgres-src\postgres.net\4-postgres-dotnet-developers-exercise-files\membership\testEFSqlServer4\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [vlab];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Infoes'
CREATE TABLE [dbo].[Infoes] (
    [InfoId] int IDENTITY(1,1) NOT NULL,
    [EmployeeId] int  NOT NULL,
    [Age] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [InfoId] in table 'Infoes'
ALTER TABLE [dbo].[Infoes]
ADD CONSTRAINT [PK_Infoes]
    PRIMARY KEY CLUSTERED ([InfoId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'Infoes'
ALTER TABLE [dbo].[Infoes]
ADD CONSTRAINT [FK_EmployeeInfo]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeInfo'
CREATE INDEX [IX_FK_EmployeeInfo]
ON [dbo].[Infoes]
    ([EmployeeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------