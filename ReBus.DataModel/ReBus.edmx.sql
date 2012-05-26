
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2012 01:45:47
-- Generated from EDMX file: D:\projects\rebus\ReBus.DataModel\ReBus.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ReBus];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BusLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Buses] DROP CONSTRAINT [FK_BusLine];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_TransactionAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriptionAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subscriptions] DROP CONSTRAINT [FK_SubscriptionAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketBus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketBus];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriptionLine_Subscription]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriptionLine] DROP CONSTRAINT [FK_SubscriptionLine_Subscription];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriptionLine_Line]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriptionLine] DROP CONSTRAINT [FK_SubscriptionLine_Line];
GO
IF OBJECT_ID(N'[dbo].[FK_BusStopLine_BusStop]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusStopLine] DROP CONSTRAINT [FK_BusStopLine_BusStop];
GO
IF OBJECT_ID(N'[dbo].[FK_BusStopLine_Line]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusStopLine] DROP CONSTRAINT [FK_BusStopLine_Line];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO
IF OBJECT_ID(N'[dbo].[Lines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lines];
GO
IF OBJECT_ID(N'[dbo].[Buses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buses];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[Subscriptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subscriptions];
GO
IF OBJECT_ID(N'[dbo].[TicketCost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketCost];
GO
IF OBJECT_ID(N'[dbo].[SubscriptionCosts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubscriptionCosts];
GO
IF OBJECT_ID(N'[dbo].[BusStops]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusStops];
GO
IF OBJECT_ID(N'[dbo].[SubscriptionLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubscriptionLine];
GO
IF OBJECT_ID(N'[dbo].[BusStopLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusStopLine];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [GUID] uniqueidentifier  NOT NULL DEFAULT newid(),
    [PasswordHash] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Credit] decimal(18,2)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [Type] int  NOT NULL,
    [AssociatedGUID] uniqueidentifier  NULL,
    [AccountGUID] uniqueidentifier  NOT NULL,
    [Created] datetime  NOT NULL
);
GO

-- Creating table 'Lines'
CREATE TABLE [dbo].[Lines] (
    [GUID] uniqueidentifier  NOT NULL DEFAULT newid(),
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Buses'
CREATE TABLE [dbo].[Buses] (
    [GUID] uniqueidentifier  NOT NULL DEFAULT newid(),
    [LineGUID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [GUID] uniqueidentifier  NOT NULL DEFAULT newid(),
    [AccountGUID] uniqueidentifier  NOT NULL,
    [Created] datetime  NOT NULL,
    [BusGUID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Subscriptions'
CREATE TABLE [dbo].[Subscriptions] (
    [GUID] uniqueidentifier  NOT NULL DEFAULT newid(),
    [AccountGUID] uniqueidentifier  NOT NULL,
    [Start] datetime  NOT NULL,
    [End] datetime  NOT NULL,
    [Created] datetime  NOT NULL
);
GO

-- Creating table 'TicketCost'
CREATE TABLE [dbo].[TicketCost] (
    [Cost] decimal(18,2)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'SubscriptionCosts'
CREATE TABLE [dbo].[SubscriptionCosts] (
    [Lines] int  NOT NULL,
    [Cost] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'BusStops'
CREATE TABLE [dbo].[BusStops] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Latitude] nvarchar(max)  NOT NULL,
    [Longitude] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SubscriptionLine'
CREATE TABLE [dbo].[SubscriptionLine] (
    [Subscriptions_GUID] uniqueidentifier  NOT NULL,
    [Lines_GUID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BusStopLine'
CREATE TABLE [dbo].[BusStopLine] (
    [BusStops_Id] int  NOT NULL,
    [Lines_GUID] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GUID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [GUID] in table 'Lines'
ALTER TABLE [dbo].[Lines]
ADD CONSTRAINT [PK_Lines]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'Buses'
ALTER TABLE [dbo].[Buses]
ADD CONSTRAINT [PK_Buses]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [PK_Subscriptions]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [Id] in table 'TicketCost'
ALTER TABLE [dbo].[TicketCost]
ADD CONSTRAINT [PK_TicketCost]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Lines] in table 'SubscriptionCosts'
ALTER TABLE [dbo].[SubscriptionCosts]
ADD CONSTRAINT [PK_SubscriptionCosts]
    PRIMARY KEY CLUSTERED ([Lines] ASC);
GO

-- Creating primary key on [Id] in table 'BusStops'
ALTER TABLE [dbo].[BusStops]
ADD CONSTRAINT [PK_BusStops]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Subscriptions_GUID], [Lines_GUID] in table 'SubscriptionLine'
ALTER TABLE [dbo].[SubscriptionLine]
ADD CONSTRAINT [PK_SubscriptionLine]
    PRIMARY KEY NONCLUSTERED ([Subscriptions_GUID], [Lines_GUID] ASC);
GO

-- Creating primary key on [BusStops_Id], [Lines_GUID] in table 'BusStopLine'
ALTER TABLE [dbo].[BusStopLine]
ADD CONSTRAINT [PK_BusStopLine]
    PRIMARY KEY NONCLUSTERED ([BusStops_Id], [Lines_GUID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LineGUID] in table 'Buses'
ALTER TABLE [dbo].[Buses]
ADD CONSTRAINT [FK_BusLine]
    FOREIGN KEY ([LineGUID])
    REFERENCES [dbo].[Lines]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusLine'
CREATE INDEX [IX_FK_BusLine]
ON [dbo].[Buses]
    ([LineGUID]);
GO

-- Creating foreign key on [AccountGUID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_TransactionAccount]
    FOREIGN KEY ([AccountGUID])
    REFERENCES [dbo].[Accounts]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionAccount'
CREATE INDEX [IX_FK_TransactionAccount]
ON [dbo].[Transactions]
    ([AccountGUID]);
GO

-- Creating foreign key on [AccountGUID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketAccount]
    FOREIGN KEY ([AccountGUID])
    REFERENCES [dbo].[Accounts]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketAccount'
CREATE INDEX [IX_FK_TicketAccount]
ON [dbo].[Tickets]
    ([AccountGUID]);
GO

-- Creating foreign key on [AccountGUID] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [FK_SubscriptionAccount]
    FOREIGN KEY ([AccountGUID])
    REFERENCES [dbo].[Accounts]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubscriptionAccount'
CREATE INDEX [IX_FK_SubscriptionAccount]
ON [dbo].[Subscriptions]
    ([AccountGUID]);
GO

-- Creating foreign key on [BusGUID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketBus]
    FOREIGN KEY ([BusGUID])
    REFERENCES [dbo].[Buses]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketBus'
CREATE INDEX [IX_FK_TicketBus]
ON [dbo].[Tickets]
    ([BusGUID]);
GO

-- Creating foreign key on [Subscriptions_GUID] in table 'SubscriptionLine'
ALTER TABLE [dbo].[SubscriptionLine]
ADD CONSTRAINT [FK_SubscriptionLine_Subscription]
    FOREIGN KEY ([Subscriptions_GUID])
    REFERENCES [dbo].[Subscriptions]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Lines_GUID] in table 'SubscriptionLine'
ALTER TABLE [dbo].[SubscriptionLine]
ADD CONSTRAINT [FK_SubscriptionLine_Line]
    FOREIGN KEY ([Lines_GUID])
    REFERENCES [dbo].[Lines]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubscriptionLine_Line'
CREATE INDEX [IX_FK_SubscriptionLine_Line]
ON [dbo].[SubscriptionLine]
    ([Lines_GUID]);
GO

-- Creating foreign key on [BusStops_Id] in table 'BusStopLine'
ALTER TABLE [dbo].[BusStopLine]
ADD CONSTRAINT [FK_BusStopLine_BusStop]
    FOREIGN KEY ([BusStops_Id])
    REFERENCES [dbo].[BusStops]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Lines_GUID] in table 'BusStopLine'
ALTER TABLE [dbo].[BusStopLine]
ADD CONSTRAINT [FK_BusStopLine_Line]
    FOREIGN KEY ([Lines_GUID])
    REFERENCES [dbo].[Lines]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusStopLine_Line'
CREATE INDEX [IX_FK_BusStopLine_Line]
ON [dbo].[BusStopLine]
    ([Lines_GUID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------