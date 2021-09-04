
------------------------------------------------------------------------
--- CREATE DATABASE

create database Coinday
GO

USE Coinday
go

------------------------------------------------------------------------
--- COINS

CREATE TABLE [dbo].[Coins](
    [Id]                INT IDENTITY(1, 1)	NOT NULL,
    [CoinName]          VARCHAR(5)			NOT NULL,
	[Status]			BIT					DEFAULT ((1)) NOT NULL,
    CHECK (LEN([CoinName]) > 2),
    CONSTRAINT [PK_Coins] PRIMARY KEY ([Id])
);

------------------------------------------------------------------------
--- CURRENCIES

CREATE TABLE [dbo].[Currencies](
    [Id]                INT IDENTITY(1, 1)	NOT NULL,
    [CurrencyName]      VARCHAR(5)			NOT NULL,
	[Status]			BIT					DEFAULT ((1)) NOT NULL,
    CHECK (LEN([CurrencyName]) > 2),
    CONSTRAINT [PK_Currencies] PRIMARY KEY ([Id])
);

------------------------------------------------------------------------
--- USERS

CREATE TABLE [dbo].[Users] (
    [Id]			INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]		VARCHAR (50)    NOT NULL,
    [LastName]		VARCHAR (50)    NOT NULL,
    [EMail]			VARCHAR (50)    NOT NULL,
    [PasswordHash]	VARBINARY (500) NOT NULL,
    [PasswordSalt]	VARBINARY (500) NOT NULL,
    [Status]		BIT             CONSTRAINT [DF__Users__Status__5070F446] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

------------------------------------------------------------------------
--- PURCHASES

CREATE TABLE [dbo].[Purchases] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [UserId]       INT				NOT NULL,
    [CoinId]       INT              NOT NULL,
    [CurrencyId]   INT              NOT NULL,
    [Quantity]     DECIMAL (18, 6)  NOT NULL,
    [UnitPrice]    DECIMAL (18, 6)  NOT NULL,
    [ExchangeRate] DECIMAL (18, 6)  DEFAULT ((1)) NOT NULL,
	[Status]	   BIT				DEFAULT ((1)) NOT NULL,
    [TradingDate]  DATE             DEFAULT (getdate()) NOT NULL,
    CHECK ([Quantity]>(0)),
    CHECK ([UnitPrice]>(0)),
    CHECK ([ExchangeRate]>(0)),
    CONSTRAINT [PK_Purchases] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Purchases_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Purchases_Coins] FOREIGN KEY ([CoinId]) REFERENCES [dbo].[Coins] ([Id]),
    CONSTRAINT [FK_Purchases_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id])
);

------------------------------------------------------------------------
--- SALES

CREATE TABLE [dbo].[Sales] (
    [Id]                INT                 IDENTITY (1, 1) NOT NULL,
    [UserId]            INT				    NOT NULL,
    [CoinId]            INT                 NOT NULL,
    [CurrencyId]        INT                 NOT NULL,
    [Quantity]          DECIMAL (18, 6)     NOT NULL,
    [UnitPrice]         DECIMAL (18, 6)     NOT NULL,
    [SaleUnitPrice]     DECIMAL (18, 6)     NOT NULL,
    [ExchangeRate]      DECIMAL (18, 6)     DEFAULT ((1)) NOT NULL,
	[Status]			BIT					DEFAULT ((1)) NOT NULL,
    [TradingDate]       DATE                DEFAULT (getdate()) NOT NULL,
    CHECK ([Quantity]>(0)),
    CHECK ([UnitPrice]>(0)),
    CHECK ([SaleUnitPrice]>(0)),
    CHECK ([ExchangeRate]>(0)),
    CONSTRAINT [PK_Sales] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sales_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Sales_Coins] FOREIGN KEY ([CoinId]) REFERENCES [dbo].[Coins] ([Id]),
    CONSTRAINT [FK_Sales_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id])
);

------------------------------------------------------------------------
--- OPERATION CLAIMS

CREATE TABLE [dbo].[OperationClaims] (
    [Id]		INT IDENTITY (1, 1) NOT NULL,
    [Name]		VARCHAR (30) NOT NULL,
	[Status]	BIT DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO OperationClaims (Name) VALUES ('admin')
GO
INSERT INTO OperationClaims (Name) VALUES ('user')
GO

------------------------------------------------------------------------
--- USER OPERATION CLAIMS

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [UserId]  INT NOT NULL,
    [ClaimId] INT NOT NULL,
    [Status]  BIT CONSTRAINT [DF__UserOpera__Statu__5535A963] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY ([ClaimId]) REFERENCES [dbo].[OperationClaims] ([Id]),
    CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

------------------------------------------------------------------------
--- USERS
-- User Triggers 
GO
CREATE TRIGGER SetDefaultUserClaim ON dbo.Users 
AFTER INSERT AS
	BEGIN
		INSERT INTO UserOperationClaims (UserId, ClaimId) (SELECT I.Id, 2 AS ClaimId FROM inserted AS I)
	END
GO

CREATE TRIGGER DeleteUserOpereationClaimByUserId ON dbo.Users
AFTER DELETE AS
	BEGIN 
		DELETE FROM UserOperationClaims WHERE UserId = (SELECT D.Id FROM deleted AS D)
	END
