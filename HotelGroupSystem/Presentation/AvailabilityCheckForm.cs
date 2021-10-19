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
        #endregion

        public AvailabilityCheckForm()
        {
            InitializeComponent();

            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
        }

        private void FindDates()
        {
            string date1 = monthCalendar1.SelectionStart.Date.ToShortDateString();
            string date2 = monthCalendar1.SelectionEnd.Date.ToShortDateString();

            //if any rooms are available
            feedbackLabel.Show();
            feedbackLabel.Text = ("The following rooms are available from the " + date1 + " - " + date2);

            //if no rooms are available
            // summaryLabel.Text = ("No rooms are available between " + date1 + " to " + date2);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            FindDates();
        }

        private void newBookingBtn_Click(object sender, EventArgs e)
        {
            //Open new booking form
            createBookingForm = new HomePageForm();
            createBookingForm.Show();

            //Close this form
            this.Close();
        }

        private void updateBookingBtn_Click(object sender, EventArgs e)
        {
            //Update new booking form
            updateBookingForm = new UpdateBookingForm();
            updateBookingForm.Show();

            //Close this form
            this.Close();
        }
    }
}
