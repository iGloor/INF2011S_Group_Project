CREATE TABLE [dbo].[Booking]
(
    [BookingID] INT NOT NULL PRIMARY KEY,
	[ReferenceNumber] INT NOT NULL,
	[GuestID] INT NOT NULL,
	[RoomsBooked] int NOT NULL,
	[CheckIn] DATETIME NOT NULL,
	[CheckOut] DATETIME NOT NULL,
	[RoomRateID] INT NOT NULL,
	[Deposit] DECIMAL NOT NULL,
	[DiscountID] INT NOT NULL,
	[BankName] VARCHAR(100) NOT NULL,
	[CreditCardNumber] INT NOT NULL
)
