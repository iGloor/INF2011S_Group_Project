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
    public partial class UpdateBookingForm : Form
    {
        #region Declare Variables
        AvailabilityCheckForm availabilityCheckForm;
        BookingDetails bookingDetails;

        BookingController bookingController;
        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public UpdateBookingForm()
        {
            InitializeComponent();
            HideFields();
        }
        #endregion

        #region Events

        #endregion

        #region Utility Methods
        
        public void PopulateBooking(Booking booking)
        {
            if (refNumberTxt.Text == booking.ReferenceNumber)
            {   // booking.BookingRef = 
                booking.CheckInDate = Convert.ToDateTime(checkInTxt.Text);
                booking.CheckOutDate = Convert.ToDateTime(checkOutTxt.Text);
                booking.RoomsBooked = Convert.ToInt32(roomTxt.Text);
                booking.RoomRate = Convert.ToDecimal(rateTxt.Text);
                booking.Deposit = Convert.ToDecimal(totalTxt.Text);
            }
            else //if not in database
            {
                MessageBox.Show("The guest you entered is not in our database.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowAll()
        {
            //Hide the following:
            checkRefNoBtn.Hide();
            enquireBtn.Hide();

            //Show the following:
            feedbackLabel.Show();
            bookDetailsLabel.Show();
            roomLabel.Show();
            roomTxt.Show();
            rateLabel.Show();
            rateTxt.Show();
            checkInLabel.Show();
            checkInTxt.Show();
            checkOutLabel.Show();
            checkOutTxt.Show();
            totalLabel.Show();
            totalTxt.Show();
            gDetailsLabel.Show();
            idLabel.Show();
            idTxt.Show();
            nameLabel.Show();
            nameTxt.Show();
            checkDatesBtn.Show();
            calculateAmountBtn.Show();
            bDetailsUpdateBtn.Show();
            cancelBtn.Show();
            deleteBtn.Show();
            discountCodeLabel.Show();
            discountCodeTxt.Show();
        }

        private void HideFields()
        {
            //Show the following:
            refNoLabel.Show();
            refNumberTxt.Show();
            checkRefNoBtn.Show();

            //Hide the following:
            feedbackLabel.Hide();
            bookDetailsLabel.Hide();
            roomLabel.Hide();
            roomTxt.Hide();
            rateLabel.Hide();
            rateTxt.Hide();
            checkInLabel.Hide();
            checkInTxt.Hide();
            checkOutLabel.Hide();
            checkOutTxt.Hide();
            totalLabel.Hide();
            totalTxt.Hide();
            gDetailsLabel.Hide();
            idLabel.Hide();
            idTxt.Hide();
            nameLabel.Hide();
            nameTxt.Hide();
            checkDatesBtn.Hide();
            calculateAmountBtn.Hide();
            bDetailsUpdateBtn.Hide();
            cancelBtn.Hide();
            deleteBtn.Hide();
            discountCodeLabel.Hide();
            discountCodeTxt.Hide();

        }
        #endregion

        private void UpdateBookingForm_Load(object sender, EventArgs e)
        {
            checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
            checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
            roomTxt.Text = AvailabilityCheckForm.setValueForRooms;
            rateTxt.Text = AvailabilityCheckForm.setValueForRate;
        }

        private void checkRefNoBtn_Click(object sender, EventArgs e)
        {
            //if statement if there is a booking number call show call method and populate textboxes
            ShowAll();
        }

        private void checkDatesBtn_Click(object sender, EventArgs e)
        {
            //Open availability check form
            availabilityCheckForm = new AvailabilityCheckForm();
            availabilityCheckForm.Show();
        }

        private void UpdateBookingForm_Activated(object sender, EventArgs e)
        {
            checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
            checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
            roomTxt.Text = AvailabilityCheckForm.setValueForRooms;
            rateTxt.Text = AvailabilityCheckForm.setValueForRate;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //Close form
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //Delete from database

        }

        private void bDetailsUpdateBtn_Click(object sender, EventArgs e)
        {
            //Update booking in database
            //Open booking details form
            bookingDetails = new BookingDetails();
            bookingDetails.Show();
        }

        private void calculateAmountBtn_Click(object sender, EventArgs e)
        {
            int rooms = Convert.ToInt32(roomTxt.Text);
            int rate = Convert.ToInt32(rateTxt.Text);
            int total = rooms * rate;
            totalTxt.Text = total.ToString();
        }

        private void enquireBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment and confirmation status", "Booking equiry");
        }
    }
}
