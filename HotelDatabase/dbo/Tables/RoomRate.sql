CREATE TABLE [dbo].[RoomRate] (
    [RoomRateID] INT          IDENTITY (1, 1) NOT NULL,
    [RoomRate]   DECIMAL (18) NOT NULL,
    [Season]     VARCHAR (1)  NOT NULL,
    PRIMARY KEY CLUSTERED ([RoomRateID] ASC)
);

