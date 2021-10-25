CREATE TABLE [dbo].[BookingCalendar] (
    [BookingCalendarID] INT IDENTITY (1, 1) NOT NULL,
    [CalendarID]        INT NOT NULL,
    [RoomID]            INT NOT NULL,
    [BookingID]         INT NULL,
    PRIMARY KEY CLUSTERED ([BookingCalendarID] ASC),
    CONSTRAINT [FK_BookingCalendar_Booking] FOREIGN KEY ([BookingID]) REFERENCES [dbo].[Booking] ([BookingID]),
    CONSTRAINT [FK_BookingCalendar_Calendar] FOREIGN KEY ([CalendarID]) REFERENCES [dbo].[Calendar] ([CalendarID]),
    CONSTRAINT [FK_BookingCalendar_Room] FOREIGN KEY ([RoomID]) REFERENCES [dbo].[Room] ([RoomID])
);

