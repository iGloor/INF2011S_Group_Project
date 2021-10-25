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
            RetrieveAllBookingCalendar();
            
        }
        #endregion

        #region Utility Methods
        public void RetrieveAllBookingCalendar()
        {
            if (dsMain.IsInitialized && dsMain.Tables.Count > 0
                && dsMain.Tables["BookingCalendar"].Rows.Count > 0) {
                dsMain.Tables["BookingCalendar"].Clear();
            }
            RetrieveAllBookingCalendarFromDB();
        }

        public void RetrieveAllBookingCalendarFromDB()
        {
            allBookingCalendar = new Collection<BookingCalendar>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

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
                    bookingCalendar.BookingID = Convert.ToInt32(myRow["BookingID"]);
                    allBookingCalendar.Add(bookingCalendar);
                }

            }
        }
        private void FillRow(DataRow aRow, BookingCalendar bookingCalendar, DB.DBOperation operation)
        {

            if (operation == DB.DBOperation.Add)
            {
                aRow["BookingCalendarID"] = bookingCalendar.BookingCalendarID;  //NOTE square brackets to indicate index of collections of fields in row.
            }
            aRow["CalendarDate"] = bookingCalendar.CalendarDate;
            aRow["BookingID"] = bookingCalendar.BookingID;
            aRow["RoomNumber"] = bookingCalendar.RoomNumber;
        }
        private int FindRow(BookingCalendar bookingCalendar , string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    ///check if guest id equal to what we are looking for
                    if (bookingCalendar.BookingCalendarID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["BookingCalendarID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void Connect2CalendarDatabase()
        {

        }
        public void DataSetChange(BookingCalendar bookingCalendar, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, bookingCalendar, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(bookingCalendar, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, bookingCalendar, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(bookingCalendar, dataTable)];
                    aRow.Delete();
                    break;
            }

        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Select_BookingCalendar_Command(BookingCalendar bookingCalendar)
        {
            //---Create Parameters to communicate with SQL Select
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@BookingCalendarID", SqlDbType.Int, 10, "BookingCalendarID");
            daMain.SelectCommand.Parameters.Add(param);
        }

        private void Build_UPDATE_Parameters(BookingCalendar bookingCalendar)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@BookingCalendarID", SqlDbType.Int, 10, "BookingCalendarID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@BookingID", SqlDbType.Int, 10, "BookingID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomNumber", SqlDbType.Int, 10, "RoomNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CalendarDate", SqlDbType.DateTime, 30, "CalendarDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Create_UPDATE_Command(BookingCalendar bookingCalendar)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE BookingCalendar SET BookingID =@BookingID, CalendarDate =@CalendarDate, RoomNumber =@RoomNumber " + "WHERE BookingCalendarID = @BookingCalendarID", cnMain);
            Build_UPDATE_Parameters(bookingCalendar);
        }
        

        public bool UpdateBookingCalendarDataSource(BookingCalendar bookingCalendar)
        {
            bool success = true;
            Create_UPDATE_Command(bookingCalendar);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }


        #endregion
    }
}
