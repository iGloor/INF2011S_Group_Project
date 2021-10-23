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
    class CalendarDB: DB
    {
        #region Data Members
        private string table1 = "BookingCalendar";
        private string sqlLocal1 = "SELECT * FROM BookingCalendar";

        private Collection<BookingCalendar> allBookingCalendar;

        #endregion

        #region Property Method: Collection
        public Collection<BookingCalendar> AllBookingCalendar 
        {
            get
            {
                return allBookingCalendar;
            }
        }
        #endregion

        #region Constructor
        public CalendarDB() : base()
        {
            allBookingCalendar = new Collection<BookingCalendar>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
            
        }
        #endregion

        #region Utility Methods
        private void Add2Collection(string table)
        {
            DataRow myRow = null;
            BookingCalendar bookingCalendar;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if(!(myRow.RowState == DataRowState.Deleted))
                {
                    bookingCalendar = new BookingCalendar();
                    bookingCalendar.BookingCalendarID = Convert.ToInt32(myRow["BookingCalendarID"]);
                    bookingCalendar.RoomNumber = Convert.ToInt32(myRow["RoomNumber"]);
                    bookingCalendar.CalendarDate = Convert.ToDateTime(myRow["CalendarDate"]);
                    allBookingCalendar.Add(bookingCalendar);
                }

            }
        }
        #endregion

        #region Database Operations CRUD
        public void Connect2CalendarDatabase()
        {

        }
        public void DataSetChange(BookingCalendar anEmp, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
           
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        #endregion
    }
}
