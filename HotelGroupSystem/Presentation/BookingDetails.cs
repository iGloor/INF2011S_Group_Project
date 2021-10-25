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
        public string bookingId;
        Booking booking;
        Guest guest;
        public int guestId;
        GuestController guestController;
        BookingController bookingController;
        #endregion
        public BookingDetails()
        {
            InitializeComponent();
        }

        public void GetConfirmationLetter()
        {
           

            MessageBox.Show("Reference Number: " + booking.ReferenceNumber + Environment.NewLine + "Guest Name: " + guest.FirstName + " " + guest.Surname, "Comfirmation Letter");
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            GetConfirmationLetter();
        }

        private void BookingDetails_Load(object sender, EventArgs e)
        {
            refNoLabel.Text = HomePageForm.bookingRefNo;
            bookingId = UpdateBookingForm.setBookingId;
            bookingController = new BookingController();
            booking = bookingController.FindById(Convert.ToInt32(bookingId));
            guestId = booking.GuestId;
            guestController = new GuestController();
            guest = guestController.Find(guestId);
        }

        private void BookingDetails_Activated(object sender, EventArgs e)
        {
            refNoLabel.Text = HomePageForm.bookingRefNo;
            bookingId = UpdateBookingForm.setBookingId;
            bookingController = new BookingController();
            booking = bookingController.FindById(Convert.ToInt32(bookingId));
            guestId = booking.GuestId;
            guestController = new GuestController();
            guest = guestController.Find(guestId);
        }
    }
}
