using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGroupSystem.Business
{
    public class AvailableRooms
    {
        #region Declare variables
        private DateTime calendarDate;
        private int roomsAvailable;
        
        #endregion

        #region Property Methods
        public DateTime CalendarDate
        {
            get { return calendarDate; }
            set { calendarDate = value; }
        }
        public int RoomsAvailable
        {
            get { return roomsAvailable; }
            set { roomsAvailable = value; }
        }
        #endregion

        #region Constructor
        public AvailableRooms()
        {

        }
        #endregion
    }
}
