using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Business
{
    class Guest
    {
        #region Data Members
        //Guest Details
        private int guestID;
        private string firstName;
        private string surname;
        private string phone;
        private string address;
        private string email;
        
        //Booking 
        public Booking booking;
        #endregion

        #region Property methods
        //get and set guest id
        public int GuestID
        {
            set { guestID = value; }
            get { return guestID; }
        }

        //get and set guest phone number
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }

        //get and set guest's home address
        public string Address
        {
            set { address = value; }
            get { return address; }
        }

        //get and set guest name
        public string FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }
        
        public string Surname
        {
            set { surname = value; }
            get { return surname; }
        }

        //get and set guest name
        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        #endregion

        #region Constructor
        public Guest()
        {

        }

        public Guest(string fName, string sName, int id, string phoneNo, string address, string emailAd)
        {
            this.firstName = fName;
            this.surname = sName;
            this.guestID = id;
            this.phone = phoneNo;
            this.address = address;
            this.email = emailAd;
        }

        #endregion
    }
}