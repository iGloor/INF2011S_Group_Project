using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Business
{
    class Calendar
    {
        #region Declare Variables

        private int calendarID;

        private DateTime date;
                
        #endregion

        #region Property Methods
        public DateTime aDate
        {
            get { return date; }
            set { date = value; }
        }

        #endregion

        #region Constructor
        public Calendar(DateTime aDate)
        {
            date = aDate;
        }
        #endregion
    }
}
