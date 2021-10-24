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
// note: date needs to be passed and rate needs to be found to autofill rate and date textboxes

namespace HotelGroupSystem
{
    public partial class HomePageForm : Form
    {
        #region Declare Variables
        AvailabilityCheckForm availabilityCheckForm;
        BookingDetails bookingDetails;

        private GuestController guestController;

        private BookingController bookingController;

        private int guestId;

        public string duration;
        public string refNo;

        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public HomePageForm()
        {
            InitializeComponent();
            //booking controller

            

        }
        #endregion

        #region Utility Methods
        public decimal TotalAmountDue()
        {
            int rooms = Convert.ToInt32(roomTxt.Text);
            int rate = Convert.ToInt32(rateTxt.Text);
            int stay = Convert.ToInt32(duration);
            decimal total = rooms * rate * stay;
            totalTxt.Text = total.ToString();
            return total;
            
        }

        public string CreateBookingReference()
        {
            StringBuilder stringBuilder = new StringBuilder();
            refNo = stringBuilder.Append(surnameTxt.Text).Append(firstNameTxt.Text).ToString(0, 3);
            return refNo;
        }

        
        private void PopulateGuestDetails(Guest guest)
        {


            //check if guest is is database by using id textbox
            if (guest != null)
            {
                //guest = guestController.Find(Convert.ToInt32(guestIDtxt.Text));
                //if guest found, populate text boxes
                guestIdTxt.Text = Convert.ToString(guest.GuestID);
                firstNameTxt.Text = guest.FirstName;
                surnameTxt.Text = guest.Surname;
                phoneTxt.Text = guest.Phone;
                emailTxt.Text = guest.Email;
                addressTxt.Text = guest.Address;
            }
            else //if not in database
            {
                MessageBox.Show("The guest you entered is not in our database.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                        
        }
        //Store guest details
        private Guest StoreGuestDetails()
        {
            Guest guest = new Guest();
            if (guestIdTxt.Text.Length > 0)
            {
                guest.GuestID = Convert.ToInt32(guestIdTxt.Text);
            }
            guest.FirstName = Convert.ToString(firstNameTxt.Text);
            guest.Surname = Convert.ToString(surnameTxt.Text);
            guest.Address = Convert.ToString(addressTxt.Text);
            guest.Email = Convert.ToString(emailTxt.Text);
            guest.Phone = Convert.ToString(phoneTxt.Text);

            guestController = new GuestController();
            guest = guestController.RecordGuest(guest);
            return guest;
        }

        private Booking StoreBookingDetails()
        {
            Booking booking = new Booking();
            booking.ReferenceNumber = CreateBookingReference();
            booking.CheckInDate = Convert.ToDateTime(checkInTxt.Text);
            booking.CheckOutDate = Convert.ToDateTime(checkOutTxt.Text);
            booking.RoomRate = Convert.ToDecimal(rateTxt.Text);
            booking.RoomsBooked = Convert.ToInt32(roomTxt.Text);
            booking.Deposit = Convert.ToDecimal(totalTxt.Text);
            booking.GuestId = Convert.ToInt32(guestIdTxt.Text);
            booking.CreditCardNo = Convert.ToInt32(cardNoTxt.Text);
            booking.BankName = Convert.ToString(bankTxt.Text);

            bookingController = new BookingController();
            booking = bookingController.RecordBooking(booking);
            return booking;
        }
        #endregion

        private void confirmBookingBtn_Click(object sender, EventArgs e)
        {
            //Save guest to database
            Booking booking = StoreBookingDetails();
            

            //Show message box with reference number
            MessageBox.Show("Your booking has been saved, your reference number is ...");

            //Save booking details in database

            //Open booking details form
            bookingDetails = new BookingDetails();
            bookingDetails.Show();
        }

        private void checkGuestBtn_Click(object sender, EventArgs e)
        {
            firstNameTxt.Clear();
            surnameTxt.Clear();
            addressTxt.Clear();
            emailTxt.Clear();
            phoneTxt.Clear();
            //check if guest is is database by using id textbox
            //if guest found, populate text boxes
            //if not in database
            // MessageBox.Show("The guest you entered is not in our database");
            Guest guest = null;

            guestId = Convert.ToInt32(guestIdTxt.Text);
            GuestController guestController = new GuestController();
            guest = guestController.Find(guestId);
            
            

            PopulateGuestDetails(guest);

        }

        

        private void calcAmountBtn_Click(object sender, EventArgs e)
        {
            //Call method to calculate total amount due (rooms * rate)
            TotalAmountDue();
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
            roomTxt.Text = AvailabilityCheckForm.setValueForRooms;
            rateTxt.Text = AvailabilityCheckForm.setValueForRate;
            duration = AvailabilityCheckForm.setValueForDuration;
        }

        private void HomePageForm_Activated(object sender, EventArgs e)
        {
            checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
            checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
            roomTxt.Text = AvailabilityCheckForm.setValueForRooms;
            rateTxt.Text = AvailabilityCheckForm.setValueForRate;
            duration = AvailabilityCheckForm.setValueForDuration;
        }

        private void HomePageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveGuestBtn_Click(object sender, EventArgs e)
        {
            
            Guest guest = StoreGuestDetails();
            PopulateGuestDetails(guest);

        }
    }
}
