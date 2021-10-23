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
        private string name;
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
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Email
        {
            set { email = value; }
            get
            {
                return email;
            }
        }
        #endregion

                #region Constructor
                public Guest()
        {

        }

        public Guest(string name, int id, string phoneNo, string address)
        {
            this.name = name;
            this.guestID = id;
            this.phone = phoneNo;
            this.address = address;
        }

        #endregion
    }
}