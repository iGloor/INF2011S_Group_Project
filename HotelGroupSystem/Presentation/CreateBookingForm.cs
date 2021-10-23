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
// note: date needs to be passed and rate needs to be found to autofill rate and date textboxes

namespace HotelGroupSystem
{
    public partial class HomePageForm : Form
    {
        #region Declare Variables
        AvailabilityCheckForm availabilityCheckForm;
        BookingDetails bookingDetails;
        private Guest guest;
        private GuestController guestController;

        private int guestId;

        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public HomePageForm()
        {
            InitializeComponent();
            //booking controller

            //guest controller
            guestController = new GuestController();
            guestController.Find(guestId);
        }
        #endregion

        #region Events
        #endregion

        #region Utility Methods
        //Retrieve guest details

        private void PopulateGuestDetails(Guest guest)
        {

            guest = guestController.Find(Convert.ToInt32(guestIdTxt.Text));

            //check if guest is is database by using id textbox
            if (guest != null)
            {
                //guest = guestController.Find(Convert.ToInt32(guestIDtxt.Text));
                //if guest found, populate text boxes
                guestIdTxt.Text = Convert.ToString(guest.GuestID);
                firstNameTxt.Text = guest.FirstName;
                surnameTxt.Text = guest.Surname;
                phoneTxt.Text = guest.Phone;
                emailTxt.Text = guest.Email;
                addressTxt.Text = guest.Address;
            }
            else //if not in database
            {
                MessageBox.Show("The guest you entered is not in our database");
            }
                        
        }
        //Store guest details
        private void StoreGuestDetails()
        {
            firstNameTxt.Text = guest.FirstName;
            surnameTxt.Text = guest.Surname;
            addressTxt.Text = guest.Address;
            emailTxt.Text = guest.Email;
            phoneTxt.Text = guest.Phone;
        }
        #endregion

        private void confirmBookingBtn_Click(object sender, EventArgs e)
        {
            //Call reference number method

            //Show message box with reference number
            MessageBox.Show("Your booking has been saved, your reference number is ...");

            //Save booking details in database

            //Open booking details form
            bookingDetails = new BookingDetails();
            bookingDetails.Show();
        }

        private void checkGuestBtn_Click(object sender, EventArgs e)
        {
            //check if guest is is database by using id textbox
            //if guest found, populate text boxes
            //if not in database
            // MessageBox.Show("The guest you entered is not in our database");

            guestId = Convert.ToInt32(guestIdTxt.Text);
            GuestController guestController = new GuestController();
            guestController.Find(guestId);
            
            PopulateGuestDetails(guest);

        }

        private void calcAmountBtn_Click(object sender, EventArgs e)
        {
            //Call method to calculate total amount due (rooms * rate)
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
    }
}
