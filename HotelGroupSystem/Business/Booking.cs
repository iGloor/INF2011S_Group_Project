using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGroupSystem.Business
{
    class Booking
    {
        #region Data Members
        //Guest id
        private string guestId;

        //Rooms booked and total amount due
        private int roomsBooked;
        private decimal roomRate;
        private decimal totalDue;

        //Check in and out dates
        private string checkInDate;
        private string checkOutDate;

        //booking reference
        private string bookingRef;

        #endregion

        #region Property methods
        
        public string GuestID
        {
            get { return guestId; } //Guest can only be viewed by booking class, set by guest class
        }

        public int RoomsBooked
        {
            get { return roomsBooked; }
            set { roomsBooked = value; }
        }

        public decimal RoomRate
        {
            get { return roomRate; }
            set { roomRate = value; }
        }

        public decimal TotalDue
        {
            get { return totalDue; }
            set { totalDue = value; }
        }

        public string CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }

        public string CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }

        public string BookingRef
        {
            get { return bookingRef; }
            set { bookingRef = value; }
        }
        #endregion

        #region Constructor
       public Booking()
        {

        }
        public Booking(string id, int rooms, decimal rate, decimal total, string checkIn, string checkOut)
        {
            guestId = id;
            roomsBooked = rooms;
            roomRate = rate;
            totalDue = total;
            checkInDate = checkIn;
            checkOutDate = checkOut;  

        }
        #endregion
    }
}
