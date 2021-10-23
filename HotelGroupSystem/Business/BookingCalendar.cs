using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Business
{
    public class BookingCalendar
    {
        #region Declare Variables

        private int bookingCalendarID;

        
        private DateTime calendarDate;
        private int roomNumber;
        private int bookingID;

        #endregion

        #region Property Methods
        public int BookingCalendarID
        {
            get { return bookingCalendarID; }
            set { bookingCalendarID = value; }
        }
        public DateTime CalendarDate
        {
            get { return calendarDate; }
            set { calendarDate = value; }
        }
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }
        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }
        #endregion

        #region Constructor

        #endregion

        #region Searching through a collection
       // public Collection<Calendar> FindByDate(Collection<Calendar> calendars, DateTime dateRange)
        
           // Collection<Calendar> matches = new Collection<Calendar>();

            //foreach (Calendar c in calendars)
            
               // if (bookingcalendar.aDate == dateRange)
                
                    //matches.Add(c);
                
            
            //return matches;
        
        #endregion

        #region Methods
        //Get rooms available for dates
        public void RoomsAvailable(DateTime startDate, DateTime endDate)
        {
            

        }
        //Update Rooms avaiable when booking made
        public void SaveDate()
        {

        }
        #endregion
    }
}
