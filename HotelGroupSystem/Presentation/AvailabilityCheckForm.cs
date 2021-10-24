using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelGroupSystem.Presentation
{
    public partial class AvailabilityCheckForm : Form
    {
        //When loaded from availability check menu strip homeForm
        //UpdateBtn and newBookingBtn are hiden
        //Only check availability shown when loaded
        //If rooms are available, UpdateBtn and newBookingBtn become visable 
        //If UpdateBtn or newBookingBtn are clicked:
        //dates are loaded onto new forms 
        //Upon closing, date and max room is passed back to relevant form

        //If loaded from update/ new booking form,
        // Only the relevant button update/new are shown once availability check is complete
        //Upon closing, date and max room is passed back to relevant form

        #region Declare Variables

        UpdateBookingForm updateBookingForm;
        HomePageForm createBookingForm;

        //Pass info to form 2
        public static string setValueForCheckIn = "";
        public static string setValueForCheckOut = "";
        
        #endregion

        #region Constructor
        public AvailabilityCheckForm()
        {
            InitializeComponent();
            HideFeedback();

            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
        }
        #endregion

        #region Methods

        public void HideFeedback()
        {
            feedbackLabel.Hide();
            feedbackLabel2.Hide();
            checkInLabel.Hide();
            checkOutLabel.Hide();
            newBookingBtn.Hide();
            updateBookingBtn.Hide();
        }

        public void ShowFeedback()
        {
            feedbackLabel.Show();
            feedbackLabel2.Show();
            checkInLabel.Show();
            checkOutLabel.Show();
            newBookingBtn.Show();
            updateBookingBtn.Show();
        }

        public void GetDetails()
        {
            setValueForCheckIn = monthCalendar1.SelectionStart.Date.ToShortDateString();
            setValueForCheckOut = monthCalendar1.SelectionEnd.Date.ToShortDateString();
            //Rooms which are available:
        }

        public void DisplayDetails()
        {
            GetDetails();

            checkInLabel.Text = setValueForCheckIn;
            checkOutLabel.Text = setValueForCheckOut;

            ShowFeedback();
        }

        public void sendDates2NewBookingForm()
        {
            //if no newBookingForm open


        }

       #endregion
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            DisplayDetails();
        }

        private void newBookingBtn_Click(object sender, EventArgs e)
        {
            //createBookingForm.bookingFormClosed == false
            //Application.OpenForms.OfType<HomePageForm>().Count() == 1
            if (Application.OpenForms.OfType<HomePageForm>().Count() == 1)
            {
                GetDetails();

                HomePageForm.ActiveForm.Update();
                HomePageForm.ActiveForm.Focus();
               
                //createBookingForm.Focus();

                //Close this form
                this.Close();
            }
            else 
            {
                GetDetails();

                //Open new booking form
                createBookingForm = new HomePageForm();
                createBookingForm.Show();

                //Close this form
                this.Close();
            }
           
        }

        private void updateBookingBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UpdateBookingForm>().Count() == 1) //if update form open
            {
                GetDetails();

                //Update existing form
                UpdateBookingForm.ActiveForm.Update();
                UpdateBookingForm.ActiveForm.Focus();
            }
            else //if update form not open
            {
                GetDetails();

                //Open new booking form
                updateBookingForm = new UpdateBookingForm();
                updateBookingForm.Show();
            }
            //Close this form
            this.Close();
        }

        private void AvailabilityCheckForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
