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
        HomePageForm bookingForm;

        
        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public HomePageForm()
        {
            InitializeComponent();
            //booking controller
            //guest controller
        }
        #endregion

        #region Events
        #endregion

        #region Utility Methods
        #endregion

        private void confirmBookingBtn_Click(object sender, EventArgs e)
        {
            //Call reference number method

            //Show message box with reference number
            MessageBox.Show("Your booking has been saved, your reference number is ...");

            //Save booking details in database
        }

        private void checkGuestBtn_Click(object sender, EventArgs e)
        {
            //check if guest is is database by using id textbox
            //if not in database
            MessageBox.Show("The guest you entered is not in our database");
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

        }
    }
}
