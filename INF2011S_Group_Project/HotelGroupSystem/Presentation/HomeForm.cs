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

namespace HotelGroupSystem.Presentation
{
    public partial class HomeForm : Form
    {
        #region Declare Variables
        UpdateBookingForm updateBookingForm;
        HomePageForm createBookingForm;
        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public HomeForm()
        {
            InitializeComponent();
            //Call hide calendar method
            HideCalendar();
            
        }
        #endregion

        #region Events
        #endregion

        #region Utility Methods

        private void ShowCalendar()
        {
            checkLabel.Show();
            dateTimePicker1.Show();
            availableSummary.Show();
            checkBtn.Show();
        }

        private void HideCalendar()
        {
            //Hide the following
            checkLabel.Hide();
            dateTimePicker1.Hide();
            availableSummary.Hide();
            checkBtn.Hide();
        }
        #endregion

        private void updateBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open update bookings form
            updateBookingForm = new UpdateBookingForm();
            updateBookingForm.Show();
        }

        private void newBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open new bookings form
            createBookingForm = new HomePageForm();
            createBookingForm.Show();
        }

        private void availabilityCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show Calendar method
            ShowCalendar();
        }
    }
}
