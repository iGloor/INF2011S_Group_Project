CREATE TABLE [dbo].[Guest] (
    [GuestID] INT         IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (1) NOT NULL,
    [Address] VARCHAR (1) NOT NULL,
    [Email]   VARCHAR (1) NOT NULL,
    [Phone]   INT         NULL,
    PRIMARY KEY CLUSTERED ([GuestID] ASC)
);

