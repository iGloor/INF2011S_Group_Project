using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;
using HotelGroupSystem.Data;

namespace HotelGroupSystem.Data
{
    class BookingDB: DB
    {
        #region Data Members
        private string table1 = "Bookings";
        private string sqlLocal1 = "SELECT * FROM Bookings";
        private Collection<Booking> bookings;
        #endregion

        #region Property Method: Collection
        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }
        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            bookings = new Collection<Booking>();
            //FillDataSet(sqlLocal1, table1);
            //Add2Collection(table1);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        private void Add2Collection(string table)
        {
            DataRow myRow = null;
            Booking booking;

            foreach(DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if(!(myRow.RowState == DataRowState.Deleted))
                {
                    booking = new Booking();
                   // booking.GuestID = Convert.ToString(myRow["ID"]).TrimEnd();
                }
            }
        }
        #endregion
    }
}
