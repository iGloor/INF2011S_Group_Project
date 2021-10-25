CREATE TABLE [dbo].[Room] (
    [RoomID]     INT         IDENTITY (1, 1) NOT NULL,
    [RoomStatus] VARCHAR (1) NOT NULL,
    [RoomRateID] VARCHAR (1) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoomID] ASC)
);

