CREATE TABLE [dbo].[Discount]
(
	[DiscountID] INT NOT NULL PRIMARY KEY,
	[DiscountCode] VARCHAR(10) NOT NULL,
	[DiscountPercent] DECIMAL NOT NULL
)
