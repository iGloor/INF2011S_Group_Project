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
    public partial class UpdateBookingForm : Form
    {
        #region Declare Variables
        AvailabilityCheckForm availabilityCheckForm;
        BookingDetails bookingDetails;

        BookingController bookingController;
        public int guestId;
        public string duration;

        private string referenceNo;

        public static int setBookingId = 0;
        public static string referenceNumber = " ";

        public static int formState = 0;
            

        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public UpdateBookingForm()
        {
            InitializeComponent();
            HideFields();
            bookingIdTxt.Hide();
        }
        #endregion



        #region Utility Methods
        private void PopulateGuestDetails(Guest guest)
        {
            //check if guest is is database by using id textbox
            if (guest != null)
            {
                if(guest.GuestID == Convert.ToInt32(idTxt.Text))
                {
                    nameTxt.Text = guest.FirstName;
                }
            }
            else //if not in database
            {
                MessageBox.Show("The guest you entered is not in our database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Booking StoreBookingDetails()
        {
            Booking booking = new Booking();

            booking.BookingID = Convert.ToInt32(bookingIdTxt.Text);
            booking.GuestId = Convert.ToInt32(idTxt.Text);
            booking.ReferenceNumber = Convert.ToString(refNumberTxt.Text);
            booking.CheckInDate = Convert.ToDateTime(checkInTxt.Text);
            booking.CheckOutDate = Convert.ToDateTime(checkOutTxt.Text);
            booking.RoomRate = Convert.ToDecimal(rateTxt.Text);
            booking.RoomsBooked = Convert.ToInt32(roomTxt.Text);
            booking.Deposit = Convert.ToDecimal(totalTxt.Text);
            booking.BankName = Convert.ToString(bankTxt.Text);
            booking.CreditCardNo = Convert.ToInt32(cardTxt.Text);
            
            bookingController = new BookingController();
            booking = bookingController.RecordBooking(booking);
            return booking;
        }

        public decimal TotalAmountDue()
        {
            int rooms = Convert.ToInt32(roomTxt.Text);
            int rate = Convert.ToInt32(rateTxt.Text);
            int stay = Convert.ToInt32(duration);
            decimal total = rooms * rate * stay;
            totalTxt.Text = total.ToString();
            return total;

        }
        public void PopulateBooking(Booking booking)
        {
            if (refNumberTxt.Text == booking.ReferenceNumber)
            {
                bookingIdTxt.Text = booking.BookingID.ToString();
                idTxt.Text = booking.GuestId.ToString();
                checkInTxt.Text = booking.CheckInDate.ToString("yyyy/MM/dd");
                checkOutTxt.Text = booking.CheckOutDate.ToString("yyyy/MM/dd");
                roomTxt.Text = booking.RoomsBooked.ToString();
                rateTxt.Text = booking.RoomRate.ToString();
                totalTxt.Text = booking.Deposit.ToString();
                bankTxt.Text = booking.BankName.ToString();
                cardTxt.Text = booking.CreditCardNo.ToString();
               
            }
            else //if not in database
            {
                MessageBox.Show("The guest you entered is not in our database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowAll()
        {
            //Hide the following:
            checkRefNoBtn.Hide();
            enquireBtn.Hide();

            //Show the following:
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
            bankLabel.Show();
            bankTxt.Show();
            cardTxt.Show();
            cardNoLabel.Show();
        }

        private void HideFields()
        {
            //Show the following:
            refNoLabel.Show();
            refNumberTxt.Show();
            checkRefNoBtn.Show();

            //Hide the following:
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
            bankLabel.Hide();
            bankTxt.Hide();
            cardTxt.Hide();
            cardNoLabel.Hide();

        }
        #endregion

        private void UpdateBookingForm_Load(object sender, EventArgs e)
        {
            setBookingId = 0;
            if (formState == 1)
            {
                checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
                checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
                roomTxt.Text = AvailabilityCheckForm.setValueForRooms;
                rateTxt.Text = AvailabilityCheckForm.setValueForRate;
                duration = AvailabilityCheckForm.setValueForDuration;
                formState = 0;
            }
        }

        private void checkRefNoBtn_Click(object sender, EventArgs e)
        {
            
            Booking booking  = null;
            referenceNo = refNumberTxt.Text;
            BookingController bookingController = new BookingController();
            booking = bookingController.Find(referenceNo);
            if (!(booking == null))
            {
                ShowAll();
                PopulateBooking(booking);
                Guest guest = null;
                guestId = Convert.ToInt32(idTxt.Text);
                GuestController guestController = new GuestController();
                guest = guestController.Find(guestId);
                PopulateGuestDetails(guest);
            }
            else
            {
                MessageBox.Show("There is no booking with the reference number " + referenceNo + ".", "Error", MessageBoxButtons.OK);
            }
           
        }

        private void checkDatesBtn_Click(object sender, EventArgs e)
        {
            formState = 1;
            //Open availability check form
            availabilityCheckForm = new AvailabilityCheckForm();
            availabilityCheckForm.Show();
        }

        private void UpdateBookingForm_Activated(object sender, EventArgs e)
        {
            setBookingId = 0;
            if (formState == 1)
            {
                checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
                checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
                roomTxt.Text = AvailabilityCheckForm.setValueForRooms;
                rateTxt.Text = AvailabilityCheckForm.setValueForRate;
                duration = AvailabilityCheckForm.setValueForDuration;
                formState = 0;
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //Close form
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Booking booking = StoreBookingDetails();

            DialogResult result = MessageBox.Show("Are you sure you want to cancel booking?", "Cancel Booking", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BookingController bookingController = new BookingController();
                bookingController.DeleteBooking(booking);
                this.Close();
            }
        }

        private void bDetailsUpdateBtn_Click(object sender, EventArgs e)
        {
            //Update booking in database
            Booking booking = StoreBookingDetails();
            
            setBookingId = booking.BookingID;
            referenceNumber = booking.ReferenceNumber;

            BookingCalendarController bookingCalendarController = new BookingCalendarController();
            bookingCalendarController.RecordCalendarReservationsForBooking(booking.BookingID);

            this.Close();
                //Open booking details form
            bookingDetails = new BookingDetails();
            bookingDetails.Show();
        }

        private void calculateAmountBtn_Click(object sender, EventArgs e)
        {
            TotalAmountDue();
        }

        private void enquireBtn_Click(object sender, EventArgs e)
        {
            Booking booking = null;

            referenceNo = refNumberTxt.Text;
            BookingController bookingController = new BookingController();
            booking = bookingController.Find(referenceNo);
            if (booking == null)
            {
                MessageBox.Show("There is no booking with the reference number " + referenceNo + ".", "Error", MessageBoxButtons.OK);
            }
            else
            {
                if(booking.PaymentStatus == 0)
                {
                    MessageBox.Show("Payment has not been received for reference number " + booking.ReferenceNumber + ".", "Booking Payment equiry");
                }
                else
                {
                    MessageBox.Show("Payment has been made for reference number " + booking.ReferenceNumber + ".", "Booking Payment equiry");
                }
            }
            
        }
    }
}
