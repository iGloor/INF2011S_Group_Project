using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelGroupSystem.Presentation;
using HotelGroupSystem.Business;
using HotelGroupSystem.Data;

namespace HotelGroupSystem.Presentation
{
    public partial class BookingDetails : Form
    {
        #region Data Members

        public int currentBookingId;

        public static int formState = 0;


        Booking booking;
        Guest guest;
        public int guestId;
        GuestController guestController;
        BookingController bookingController;
        #endregion
        public BookingDetails()
        {
            InitializeComponent();
            currentBookingId = 0;
            refNoLabel.Show();

        }

        public void GetBookingId(Booking booking)
        {
            //refNoLabel.Text = Convert.ToInt32(booking.BookingID);
            refNoLabel.Show();
        }

        public void GetConfirmationLetter()
        {
            MessageBox.Show("Confirmation letter for reference Number " + booking.ReferenceNumber + "." + Environment.NewLine + "Guest Name: " + guest.FirstName + " " + guest.Surname + Environment.NewLine 
                + "Booking Details: " + Environment.NewLine + "Check in Date: " + booking.CheckInDate.ToString("yyyy/MM/dd") + Environment.NewLine + "Check out Date: " + booking.CheckOutDate.ToString("yyyy/MM/dd") + Environment.NewLine + 
                "Rooms Booked: " + booking.RoomsBooked + Environment.NewLine +"Average Room Rate: " + booking.RoomRate.ToString("C") + Environment.NewLine +
                "Deposit: " + booking.Deposit.ToString("C") + Environment.NewLine + "Banking Details:" + Environment.NewLine +
                "Credit Card Number: " + booking.CreditCardNo + Environment.NewLine + "Bank Name: " + booking.BankName, "Comfirmation Letter");
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            GetConfirmationLetter();
        }

        private void BookingDetails_Load(object sender, EventArgs e)
        {
            currentBookingId = BookingController.currentBookingId;
            
            bookingController = new BookingController();

            booking = bookingController.FindByCurrentBookingId();
            guestId = booking.GuestId;
            guestController = new GuestController();
            guest = guestController.Find(guestId);

            refNoLabel.Text = booking.ReferenceNumber;
            refNoLabel.Show();
        }

        private void BookingDetails_Activated(object sender, EventArgs e)
        {
            
        }

        private void refNoLabel_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            currentBookingId = 0;
        }
    }
}
