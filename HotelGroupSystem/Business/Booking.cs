using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Business
{
    class Booking
    {
        #region Data Members
        //Booking is linked to guest already

        //booking reference
        private int bookingRef;

        //Rooms booked and total amount due
        private int roomsBooked;
        private decimal roomRate;
        private decimal totalDue;

        //Discount
        public Discount discount;

        //Rooms
        public Room room;
        public Collection<Room> rooms;

        //Check in and out dates
        private string checkInDate;
        private string checkOutDate;

        //Billing details
        private int creditCardNo;
        private string bankName;

        #endregion

        #region Property methods
        public int BookingRef
        {
            get { return bookingRef; }
            set { bookingRef = value; }
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

        public int CreditCardNo
        {
            get { return creditCardNo; }
            set { creditCardNo = value; }
        }

        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }
        
        #endregion

        #region Constructor
       public Booking()
        {

        }
        public Booking(int bRef, int rooms, decimal rate, decimal total, Discount discountPercentage, string checkIn, string checkOut, int creditCard, string bName)
        {
            bookingRef = bRef;
            roomsBooked = rooms;
            roomRate = rate;
            totalDue = total;
            discount = discountPercentage;
            checkInDate = checkIn;
            checkOutDate = checkOut;
            creditCardNo = creditCard;
            bankName = bName;
        }
        #endregion
    }
}
