CREATE TABLE [dbo].[BookingCalendar]
(
    [BookingCalendarID] INT NOT NULL PRIMARY KEY,
	[CalendarID] INT NOT NULL,
	[RoomID] INT NOT NULL,
	[BookingID] INT
)
