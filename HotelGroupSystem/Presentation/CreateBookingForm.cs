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
        public string referenceBuilder;

        public static int setBookingId;

        public static string bookingRefNo = " ";

        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public HomePageForm()
        {
            InitializeComponent();
                       

        }
        #endregion

        #region Generate Booking Reference
        // Instantiate random number generator.    
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        // Generates a random booking reference.  
        // 2-LowerCase + 3-Digits + 2-UpperCase  
        public string BookingRef()
        {
            var referenceBuilder = new StringBuilder();

            // 2-Letters lower case   
            referenceBuilder.Append(RandomString(2, true));

            // 3-Digits between 100 and 999  
            referenceBuilder.Append(RandomNumber(100, 999));

            // 2-Letters upper case  
            referenceBuilder.Append(RandomString(2));

            return referenceBuilder.ToString();
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
            booking.ReferenceNumber = BookingRef();
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
            //Save bookingS to database
            Booking booking = StoreBookingDetails();
           
            setBookingId = booking.BookingID;
            //referenceNumber = booking.ReferenceNumber;

            BookingCalendarController bookingCalendarController = new BookingCalendarController();
            bookingCalendarController.RecordCalendarReservationsForBooking(booking.BookingID);


            BookingRef();
            //Show message box with reference number
            MessageBox.Show("Your booking has been saved!" + Environment.NewLine + "Your reference number is: " + booking.ReferenceNumber, "Please note", MessageBoxButtons.OK);

            this.Close();
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
            setBookingId = 0;
            checkInTxt.Text = AvailabilityCheckForm.setValueForCheckIn;
            checkOutTxt.Text = AvailabilityCheckForm.setValueForCheckOut;
            roomTxt.Text = AvailabilityCheckForm.setValueForRooms;
            rateTxt.Text = AvailabilityCheckForm.setValueForRate;
            duration = AvailabilityCheckForm.setValueForDuration;
        }

        private void HomePageForm_Activated(object sender, EventArgs e)
        {
            setBookingId = 0;
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
