CREATE TABLE [dbo].[Booking] (
    [BookingID]        INT           IDENTITY (1, 1) NOT NULL,
    [ReferenceNumber]  INT           NOT NULL,
    [GuestID]          INT           NOT NULL,
    [RoomsBooked]      INT           NOT NULL,
    [CheckIn]          DATETIME      NOT NULL,
    [CheckOut]         DATETIME      NOT NULL,
    [RoomRateID]       INT           NOT NULL,
    [Deposit]          DECIMAL (18)  NOT NULL,
    [DiscountID]       INT           NOT NULL,
    [BankName]         VARCHAR (100) NOT NULL,
    [CreditCardNumber] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([BookingID] ASC),
    CONSTRAINT [FK_Booking_Discount] FOREIGN KEY ([DiscountID]) REFERENCES [dbo].[Discount] ([DiscountID]),
    CONSTRAINT [FK_Booking_Guest] FOREIGN KEY ([GuestID]) REFERENCES [dbo].[Guest] ([GuestID]),
    CONSTRAINT [FK_Booking_RoomRate] FOREIGN KEY ([RoomRateID]) REFERENCES [dbo].[RoomRate] ([RoomRateID])
);

