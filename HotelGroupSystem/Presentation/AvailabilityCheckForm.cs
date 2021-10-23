using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelGroupSystem.Business;
using HotelGroupSystem.Data;

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
        //Declare forms
        UpdateBookingForm updateBookingForm;
        HomePageForm createBookingForm;

        //Declare calendar variables
        private BookingCalendar calendar;
        private BookingCalendarController bookingCalendarController;

        private Collection<BookingCalendar> allBookingCalendars;

        //Pass info to form 2
        public static string setValueForCheckIn = "";
        public static string setValueForCheckOut = "";

        DateTime checkInDate;
        DateTime checkOutDate;

        #endregion

        #region Property Methods
       
        #endregion

        #region Constructor
        public AvailabilityCheckForm()
        {
            InitializeComponent();
            HideFeedback();

            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;

            bookingCalendarController = new BookingCalendarController();
            bookingCalendarController.GetRoomsAvailable(checkInDate, checkOutDate);

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

            checkInDate = monthCalendar1.SelectionStart.Date;
            checkOutDate = monthCalendar1.SelectionEnd.Date;
            //Rooms which are available:
        }

        public void DisplayDetails()
        {
            GetDetails();

            checkInLabel.Text = setValueForCheckIn;
            checkOutLabel.Text = setValueForCheckOut;

            ShowFeedback();
        }

        public void setUpBookingCalendarListView()
        {
            ListViewItem bookingCalendarDetails;
            allBookingCalendars = null;
            summaryView.Clear();

            List<AvailableRooms> allAvailableRooms = bookingCalendarController.GetRoomsAvailable(checkInDate, checkOutDate);

            summaryView.View = View.Details;


            allBookingCalendars = bookingCalendarController.AllBookingCalendars;

            summaryView.Columns.Add("Date ", 80, HorizontalAlignment.Left);
            summaryView.Columns.Add("Available Rooms ", 110, HorizontalAlignment.Left);

            foreach (AvailableRooms availableRooms in allAvailableRooms)
            {
                bookingCalendarDetails = new ListViewItem(availableRooms.CalendarDate.ToString("yyyy/MM/dd"));
                bookingCalendarDetails.SubItems.Add(availableRooms.RoomsAvailable.ToString());
                summaryView.Items.Add(bookingCalendarDetails);
                
            }
            summaryView.Refresh();
            summaryView.GridLines = true;
        }

        //Populate employee object method
        private void SetDates()
        {

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

            setUpBookingCalendarListView();
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

        private void summaryView_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (monthCalendar1_DateSelected. SelectedItems.Count > 0)   // if you selected an item 
           // {
               // employee = employeeController.Find(employeeListView.SelectedItems[0].Text);  //selected student becoms current student
                                                                                             // Show the details of the selected student in the controls
               // PopulateTextBoxes(employee);
            //}
        }
    }
}

