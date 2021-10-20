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
        AvailabilityCheckForm availabilityCheckForm;
        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public HomeForm()
        {
            InitializeComponent();
                       
        }
        #endregion

        #region Events
        #endregion

        #region Utility Methods

        

      
      
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
            //Open Availability form
            availabilityCheckForm = new AvailabilityCheckForm();
            availabilityCheckForm.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

        }

        private void occupancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data", "Occupancy Report");
        }

        private void seasonalSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data" ,"Seasonal Summary Report");
        }

        private void makeAnEnquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open update booking form
            updateBookingForm = new UpdateBookingForm();
            updateBookingForm.Show();
        }
    }
}
