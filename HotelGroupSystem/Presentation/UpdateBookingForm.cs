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
        BookingController bookingController = new BookingController();
        Booking booking;
        Guest guest;
        GuestController guestController = new GuestController();
        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public UpdateBookingForm()
        {
            InitializeComponent();
            HideFields();
            //Booking class
            Booking booking;
        }
        #endregion

        #region Events

        #endregion

        #region Utility Methods
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
        }

        private void checkRefNoBtn_Click(object sender, EventArgs e)
        {

            //if statement if there is a booking number call show call method and populate textboxes
            booking = bookingController.Find(Convert.ToInt32(refNumberTxt.Text));

            
            if (booking != null)
            {

                guest = guestController.Find(booking.GuestID);

                idTxt.Text = Convert.ToString(booking.GuestID);
                nameTxt.Text = Convert.ToString(guest.Name);
                checkInTxt.Text = Convert.ToString(booking.CheckInDate);
                checkOutTxt.Text = Convert.ToString(booking.CheckOutDate);
                roomTxt.Text = Convert.ToString(booking.RoomsBooked);
                rateTxt.Text = Convert.ToString(booking.RoomRate);
                totalTxt.Text = Convert.ToString(booking.TotalDue);

                ShowAll();
            }
            else { 
                //maybe a message box saying no booking found
            }

            
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
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //Close form
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //Delete from database
            bookingController.DataMaintenance(booking, DB.DBOperation.Delete);
            bookingController.FinalizeChanges(booking);
            

        }

        private void bDetailsUpdateBtn_Click(object sender, EventArgs e)
        {
            //Update booking in database
            booking.CheckInDate = checkInTxt.Text;
            booking.CheckOutDate = checkOutTxt.Text;
            //booking.discount = discountCodeTxt.Text;
            booking.RoomRate = Convert.ToDecimal(rateTxt.Text);

            booking.RoomsBooked = Convert.ToInt32(roomTxt.Text);
            booking.GuestID = Convert.ToInt32(idTxt.Text);

            bookingController.DataMaintenance(booking, DB.DBOperation.Update);
            bookingController.FinalizeChanges(booking);
            //Open booking details form
            bookingDetails = new BookingDetails();
            bookingDetails.Show();
        }

        private void calculateAmountBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void enquireBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment and confirmation status", "Booking equiry");
        }
    }
}
