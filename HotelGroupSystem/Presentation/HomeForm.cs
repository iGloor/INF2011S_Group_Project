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
    public partial class HomeForm : Form
    {
        #region Declare Variables
        UpdateBookingForm updateBookingForm;
        HomePageForm createBookingForm;
        AvailabilityCheckForm availabilityCheckForm;

        private BookingCalendar calendar;
        private BookingCalendarController bookingCalendarController;

        private Collection<BookingCalendar> allBookingCalendars;
        private DateTime checkIn;
        private DateTime checkOut;
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
            checkIn = monthCalendar1.SelectionStart.Date;
            checkOut = monthCalendar1.SelectionEnd.Date;
            bookingCalendarController = new BookingCalendarController();

            StringBuilder stringBuilder = new StringBuilder();

            List<AvailableRooms> occupancyReportList = bookingCalendarController.GetRoomOccupancy(checkIn, checkOut);
            foreach(AvailableRooms occupancy in occupancyReportList)
            {
                stringBuilder.Append(occupancy.CalendarDate.ToString("yyyy/MM/dd")).Append(" - ").Append(occupancy.RoomsAvailable.ToString()).AppendLine();
            }
            var message = string.Join(Environment.NewLine, occupancyReportList);
                MessageBox.Show( stringBuilder.ToString(), "Occupancy Report");

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

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {

        }
    }
}
