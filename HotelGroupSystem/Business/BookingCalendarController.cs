using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;
using HotelGroupSystem.Data;

namespace HotelGroupSystem.Business
{
    public class BookingCalendarController
    {
        #region Data Members

        CalendarDB calendarDB;
        Collection<BookingCalendar> allBookingCalendars;

        CalendarDB bookingCalendarDB;
        Collection<BookingCalendar> bookingCalendars;

        #endregion

        #region Properties
        public Collection<BookingCalendar> AllBookingCalendars
        {
            get
            {
                return allBookingCalendars;
            }
        }
        #endregion

        #region Constructor
        public BookingCalendarController()
        {
            //***instantiate the calendarDB object to communicate with the database
            calendarDB = new CalendarDB();
            allBookingCalendars = calendarDB.AllBookingCalendar;



        }
        #endregion

        #region Methods
        public void UpdateBookingCalendar(Booking booking)
        {
            BookingDB bookingDB = new BookingDB();
            bookingDB.DataSetChange(booking, DB.DBOperation.Update);
            bookingDB.UpdateBookingDataSource(booking);
        }
        public void RecordCalendarReservationsForBooking(int boookingId)
        {
            int assignedBookingCount = 0;
            bookingCalendarDB = new CalendarDB();
            bookingCalendars = bookingCalendarDB.AllBookingCalendar;

            BookingController bookingController = new BookingController();
            Booking booking = bookingController.FindById(boookingId);

            foreach (BookingCalendar bookingCalendar in allBookingCalendars)
            {
                if (bookingCalendar.BookingID == booking.BookingID)
                {
                    bookingCalendar.BookingID = 0;
                    UpdateBookingCalendar(bookingCalendar);
                }
            }
            int dateCounter = booking.CheckOutDate.Subtract(booking.CheckInDate).Days; 
            int roomCounter = booking.RoomsBooked - 1;

            for (int i = 0; i < dateCounter; i++)
            {
                assignedBookingCount = 0;
                foreach (BookingCalendar bookingCalendar in allBookingCalendars)
                {
                      if ((bookingCalendar.CalendarDate == booking.CheckInDate.AddDays(i))
                            && (bookingCalendar.BookingID == 0)
                            && (assignedBookingCount < booking.RoomsBooked))
                      {
                        assignedBookingCount++;
                        bookingCalendar.BookingID = booking.BookingID;
                        UpdateBookingCalendar(bookingCalendar);
                      }
                }
            }

           
            bookingCalendarDB.RetrieveAllBookingCalendar();
            bookingCalendars = bookingCalendarDB.AllBookingCalendar;
           // bookingCalendar = guests.First(x => x.Surname == guest.Surname && x.FirstName == guest.FirstName);
           
        }

        public void UpdateBookingCalendar(BookingCalendar bookingCalendar)
        {
            bookingCalendarDB.DataSetChange(bookingCalendar, DB.DBOperation.Update);
            bookingCalendarDB.UpdateBookingCalendarDataSource(bookingCalendar);
        }


        public List<AvailableRooms> GetRoomOccupancy(DateTime checkIn, DateTime checkOut)
        {
            List<AvailableRooms> occupancyReportList = null;

            if (allBookingCalendars.Count > 0)
            {
                occupancyReportList = new List<AvailableRooms>();

                foreach (BookingCalendar bookingCalendar in allBookingCalendars)
                {
                    if ((bookingCalendar.CalendarDate >= checkIn) && (bookingCalendar.CalendarDate < checkOut))
                    {
                        if (!(occupancyReportList.Any(x => x.CalendarDate == bookingCalendar.CalendarDate)))
                        {
                            AvailableRooms availableRooms = new AvailableRooms();

                            availableRooms.CalendarDate = bookingCalendar.CalendarDate;
                            availableRooms.RoomsAvailable = 0;
                            occupancyReportList.Add(availableRooms);
                        }

                        AvailableRooms firstAvailableRooms = occupancyReportList.First(x => x.CalendarDate == bookingCalendar.CalendarDate);
                        if (bookingCalendar.BookingID > 0)
                        {
                            firstAvailableRooms.RoomsAvailable++;
                        }
                    }
                }
            }
            return occupancyReportList;
        }
        public List<AvailableRooms> GetRoomsAvailable(DateTime checkIn, DateTime checkOut)
        {
            List<AvailableRooms> allAvailableRooms = null;

            if (allBookingCalendars.Count > 0)
            {
                allAvailableRooms = new List<AvailableRooms>();
                
                foreach(BookingCalendar bookingCalendar in allBookingCalendars)
                {
                    if((bookingCalendar.CalendarDate >= checkIn) && (bookingCalendar.CalendarDate < checkOut))
                    {
                        if (!(allAvailableRooms.Any(x => x.CalendarDate == bookingCalendar.CalendarDate)))
                        {
                            AvailableRooms availableRooms = new AvailableRooms();

                            availableRooms.CalendarDate = bookingCalendar.CalendarDate;
                            availableRooms.RoomsAvailable = 0;
                            allAvailableRooms.Add(availableRooms);
                        }

                        AvailableRooms firstAvailableRooms = allAvailableRooms.First(x => x.CalendarDate == bookingCalendar.CalendarDate);
                        if (bookingCalendar.BookingID == 0)
                        {
                            firstAvailableRooms.RoomsAvailable++;
                        }
                    }
                }
            }
            return allAvailableRooms;
        }
        #endregion 

        #region Database Communication
        //public void DatabaseMaintaince(BookingCalendar calendar, DB.DBOperation operation)

        #endregion
    }
}
