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
        //Primary key
        private int bookingID;

        //booking reference
        private int bookingRef;

        //Guest link
        private Guest guest;

        //Rooms booked and total amount due
        private int roomsBooked;
        private decimal roomRate;
        private decimal totalDue;

        //Discount
        public Discount discount;

        //Check in and out dates
        private DateTime checkInDate;
        private DateTime checkOutDate;

        //Billing details
        private int creditCardNo;
        private string bankName;

        #endregion

        #region Property methods
        public int BookingID
        {
            get { return bookingID; }
        }
        public int BookingRef
        {
            get { return bookingRef; }
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

        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }

        public DateTime CheckOutDate
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
        public Booking(int bId, int bRef, int rooms, decimal rate, decimal total, Discount discountPercentage, DateTime checkIn, DateTime checkOut, int creditCard, string bName)
        {
            bookingID = bId;
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
