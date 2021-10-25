CREATE TABLE [dbo].[Discount] (
    [DiscountID]      INT          IDENTITY (1, 1) NOT NULL,
    [DiscountCode]    VARCHAR (10) NOT NULL,
    [DiscountPercent] DECIMAL (18) NOT NULL,
    PRIMARY KEY CLUSTERED ([DiscountID] ASC)
);

