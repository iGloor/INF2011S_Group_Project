using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGroupSystem.Business
{
    class Guest
    {
        #region Data Members
        private int guestID;
        private string name;
        private string billingStatus;
        private decimal bill;
        private string phone;
        private string address;
        private decimal discount;
        private int age;
        //booking data member
        #endregion

        #region Property methods
        //get and set guest id
        public int getGuestID
        {
            set { guestID = value; }
            get { return guestID; }
        }

        //get billing status
        public string getBillingStatus
        {
            set { billingStatus = value; }
            get { return billingStatus; }
        }

        //get guest billing
        public decimal getBill
        {
            set { bill = value; }
            get { return bill; }
        }

        //get and set guest phone number
        public string getPhone
        {
            set { phone = value; }
            get { return phone; }
        }

        //get and set guest's home address
        public string getAddress
        {
            set { address = value; }
            get { return address; }
        }

        //get and set discount
        public decimal getDiscount
        {
            set { discount = value; }
            get { return discount; }
        }

        //get and set guest name
        public string getName
        {
            set { name = value; }
            get { return name; }
        }

        //get and set age of guest
        public int getAge
        {
            set { age = value; }
            get { return age; }
        }
        #endregion

        #region Constructor
        public Guest()
        {
            name = "";
            address = "";
            guestID = 0;
            phone = "";
            discount = 0;
            billingStatus = "None";
            bill = 0;
        }
        #endregion
    }
}