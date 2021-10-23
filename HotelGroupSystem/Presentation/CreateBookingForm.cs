using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelGroupSystem.Presentation;
using HotelGroupSystem.Business;
// note: date needs to be passed and rate needs to be found to autofill rate and date textboxes

namespace HotelGroupSystem
{
    public partial class HomePageForm : Form
    {
        #region Declare Variables
        AvailabilityCheckForm availabilityCheckForm;
        BookingDetails bookingDetails;
        GuestController guestController;
        BookingController bookingController;
        Booking booking;
        Guest guest;
        
        
        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public HomePageForm()
        {
            InitializeComponent();
            guestController = new GuestController();
            //guest controller
            bookingController = new BookingController(); ;
           

        }
        #endregion

        #region Events
        #endregion

        #region Utility Methods
        #endregion

        private void confirmBookingBtn_Click(object sender, EventArgs e)
        {
            //Call reference number method

            booking = new Booking();

            booking.CheckInDate = checkInTxt.Text;
            booking.CheckOutDate = checkOutTxt.Text;
            booking.RoomsBooked = Convert.ToInt32(roomTxt.Text);           
            booking.RoomRate = Convert.ToDecimal(rateTxt.Text);
            //booking.discount = discountCodeTxt.Text;

            booking.TotalDue = Convert.ToDecimal(totalTxt.Text);
            booking.CreditCardNo = Convert.ToInt32(cardNoTxt.Text);
            booking.BankName = bankTxt.Text;
            booking.BookingRef = bookingController.RandomNumber(1, 100);//testing reference num
            

            //Show message box with reference number
            MessageBox.Show("Your booking has been saved, your reference number is " + booking.BookingRef);

            //Save booking details in database
            bookingController.DataMaintenance(booking, DB.DBOperation.Add);
            bookingController.FinalizeChanges(booking);

            //Open booking details form
            bookingDetails = new BookingDetails();
            bookingDetails.Show();
        }

        private void checkGuestBtn_Click(object sender, EventArgs e)
        {

            guest = guestController.Find(Convert.ToInt32(guestIDtxt.Text));

            //check if guest is is database by using id textbox
            if (guest != null)
            {
                //guest = guestController.Find(Convert.ToInt32(guestIDtxt.Text));
                //if guest found, populate text boxes
                guestIDtxt.Text = Convert.ToString(guest.GuestID);
                nameTxt.Text = guest.Name;
                phoneTxt.Text = Convert.ToString(guest.Phone);
                emailTxt.Text = guest.Email;
                addressTxt.Text = guest.Address;
            }
            else //if not in database
            {
                MessageBox.Show("The guest you entered is not in our database");
            }

           // guest = null;

        }

        private void calcAmountBtn_Click(object sender, EventArgs e)
        {
            //Call method to calculate total amount due (rooms * rate)
            double rate = Convert.ToDouble(rateTxt.Text);
            int rooms = Convert.ToInt32(roomTxt.Text);
            totalTxt.Text = Convert.ToString(rooms * rate);
        }

        private void checkDatesBtn_Click(object sender, EventArgs e)
        {
            //Open availability check form
            availabilityCheckForm = new AvailabilityCheckForm();
            availabilityCheckForm.Show();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
            checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
        }

        private void HomePageForm_Activated(object sender, EventArgs e)
        {
            checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
            checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
        }

        private void HomePageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void guestID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
