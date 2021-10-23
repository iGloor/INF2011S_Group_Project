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
        public List<AvailableRooms> GetRoomOccupancy(DateTime checkIn, DateTime checkOut)
        {
            List<AvailableRooms> occupancyReportList = null;

            if (allBookingCalendars.Count > 0)
            {
                occupancyReportList = new List<AvailableRooms>();

                foreach (BookingCalendar bookingCalendar in allBookingCalendars)
                {
                    if ((bookingCalendar.CalendarDate >= checkIn) && (bookingCalendar.CalendarDate <= checkOut))
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
                    if((bookingCalendar.CalendarDate >= checkIn) && (bookingCalendar.CalendarDate <= checkOut))
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
