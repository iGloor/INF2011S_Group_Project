using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Business
{
    public class Booking
    {
        #region Data Members
        //Primary key
        private int bookingID;

        //booking reference
        private string referenceNumber;

        //Guest link
        private int guestId;

        //Rooms booked and total amount due
        private int roomsBooked;
        private decimal roomRate;
        private decimal deposit;

        //Discount
        public int discountId;

        //Check in and out dates
        private DateTime checkInDate;
        private DateTime checkOutDate;

        //Billing details
        private int creditCardNo;
        private int paymentStatus;
        private string bankName;

        #endregion

        #region Property methods
        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }
        public string ReferenceNumber
        {
            get { return referenceNumber; }
            set { referenceNumber = value; }
        }

        public int GuestId
        {
            get { return guestId; }
            set { guestId = value; }
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

        public decimal Deposit
        {
            get { return deposit; }
            set { deposit = value; }
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

        public int DiscountId
        {
            get { return discountId; }
            set { discountId = value; }
        }

        public int CreditCardNo
        {
            get { return creditCardNo; }
            set { creditCardNo = value; }
        }

        public int PaymentStatus
        {
            get { return paymentStatus; }
            set { paymentStatus = value; }
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
        public Booking(int bId, string bRef, int gId, int rooms, int payStatus, decimal rate, decimal total, int discountid, DateTime checkIn, DateTime checkOut, int creditCard, string bName)
        {
            bookingID = bId;
            referenceNumber = bRef;
            guestId = gId;
            roomsBooked = rooms;
            paymentStatus = payStatus;
            roomRate = rate;
            deposit = total;
            discountId = discountid;
            checkInDate = checkIn;
            checkOutDate = checkOut;
            creditCardNo = creditCard;
            bankName = bName;
        }
        #endregion
    }
}
