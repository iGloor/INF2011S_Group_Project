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
    class BookingDB : DB
    {
        #region Data Members
        private string table1 = "Booking";
        private string sqlLocal1 = "SELECT * FROM Booking";

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
            RetrieveAllBookingsFromDB();
        }
        #endregion

        #region Utility Methods
        public void RetrieveAllBookings()
        {
            dsMain.Tables["Booking"].Clear();
            RetrieveAllBookingsFromDB();
        }

        public void RetrieveAllBookingsFromDB()
        {
            //fill data set
            bookings = new Collection<Booking>();

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
            Booking booking;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    booking = new Booking();
                    //Obtain each booking attribute from the specific field in the row in the table
                    booking.BookingID = Convert.ToInt32(myRow["BookingID"]);
                    booking.GuestId = Convert.ToInt32(myRow["GuestID"]);
                    booking.ReferenceNumber = Convert.ToString(myRow["ReferenceNumber"]);
                    booking.CheckInDate = Convert.ToDateTime(myRow["CheckIn"]);
                    booking.CheckOutDate = Convert.ToDateTime(myRow["CheckOut"]);
                    booking.RoomsBooked = Convert.ToInt32(myRow["RoomsBooked"]);
                    booking.RoomRate = Convert.ToDecimal(myRow["RoomRate"]);
                    booking.Deposit = Convert.ToDecimal(myRow["Deposit"]);
                    booking.DiscountId = Convert.ToInt32(myRow["DiscountID"]);
                    booking.BankName = Convert.ToString(myRow["BankName"]);
                    booking.CreditCardNo = Convert.ToInt32(myRow["CreditCardNumber"]);
                    booking.PaymentStatus = Convert.ToInt32(myRow["PaymentStatus"]);
                    //add booking to bookings collection
                    bookings.Add(booking);

                }
            }
        }

       

        private void FillRow(DataRow aRow, Booking aBooking, DB.DBOperation operation)
        {
            //Booking booking;

            if (operation == DB.DBOperation.Add)
            {
                aRow["BookingID"] = aBooking.BookingID;
                aRow["ReferenceNumber"] = aBooking.ReferenceNumber;  //NOTE square brackets to indicate index of collections of fields in row.
                
            }
            aRow["GuestID"] = aBooking.GuestId;
            aRow["DiscountID"] = aBooking.DiscountId;
            aRow["RoomsBooked"] = aBooking.RoomsBooked;
            aRow["RoomRate"] = aBooking.RoomRate;
            aRow["Deposit"] = aBooking.Deposit;
            aRow["CheckIn"] = aBooking.CheckInDate;
            aRow["CheckOut"] = aBooking.CheckOutDate;
            aRow["BankName"] = aBooking.BankName;
            aRow["CreditCardNumber"] = aBooking.CreditCardNo;
            aRow["PaymentStatus"] = aBooking.PaymentStatus;

        }

        private int FindRow(Booking aBooking, string table)
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
                    //check if booking id equal to what we are looking for
                   if (aBooking.ReferenceNumber == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ReferenceNumber"]))
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
        public void DataSetChange(Booking aBooking, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aBooking, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aBooking, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aBooking, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aBooking, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Booking aBooking)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ReferenceNumber", SqlDbType.VarChar, 10, "ReferenceNumber");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.VarChar, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomsBooked", SqlDbType.Int, 5, "RoomsBooked");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Deposit", SqlDbType.Decimal, 15, "Deposit");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckIn", SqlDbType.DateTime, 10, "CheckIn");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOut", SqlDbType.DateTime, 10, "CheckOut");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@DiscountID", SqlDbType.Int, 10, "DiscountID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomRate", SqlDbType.Decimal, 7, "RoomRate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@BankName", SqlDbType.VarChar, 100, "BankName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditCardNumber", SqlDbType.Int, 10, "CreditCardNumber");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@PaymentStatus", SqlDbType.Int, 10, "PaymentStatus");
            daMain.InsertCommand.Parameters.Add(param);
        }


        private void Build_UPDATE_Parameters(Booking aBooking)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ReferenceNumber", SqlDbType.VarChar, 10, "ReferenceNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.VarChar, 10, "GuestID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomsBooked", SqlDbType.Int, 5, "RoomsBooked");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Deposit", SqlDbType.Decimal, 15, "Deposit");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckIn", SqlDbType.DateTime, 10, "CheckIn");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOut", SqlDbType.DateTime, 10, "CheckOut");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@DiscountID", SqlDbType.Int, 10, "DiscountID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomRate", SqlDbType.Decimal, 7, "RoomRate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@BankName", SqlDbType.VarChar, 100, "BankName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditCardNumber", SqlDbType.Int, 10, "CreditCardNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@PaymentStatus", SqlDbType.Int, 10, "PaymentStatus");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Parameters()
        {
            //Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@ReferenceNumber", SqlDbType.VarChar, 10, "ReferenceNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@GuestID", SqlDbType.VarChar, 10, "GuestID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomsBooked", SqlDbType.Int, 5, "RoomsBooked");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@Deposit", SqlDbType.Decimal, 15, "Deposit");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckIn", SqlDbType.DateTime, 10, "CheckIn");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOut", SqlDbType.DateTime, 10, "CheckOut");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@DiscountID", SqlDbType.Int, 10, "DiscountID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomRate", SqlDbType.Decimal, 7, "RoomRate");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@BankName", SqlDbType.VarChar, 100, "BankName");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@CreditCardNumber", SqlDbType.Int, 10, "CreditCardNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);

            param = new SqlParameter("@PaymentStatus", SqlDbType.Int, 10, "PaymentStatus");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Booking aBooking)
        {
            //Command used to insert values into the Bookings table..

            daMain.InsertCommand = new SqlCommand("INSERT into Booking (GuestID, ReferenceNumber, RoomsBooked, PaymentStatus, RoomRate, Deposit, CheckIn, CheckOut, BankName, CreditCardNumber, DiscountID)" +
                " VALUES (@GuestID, @ReferenceNumber, @RoomsBooked, @PaymentStatus, @RoomRate, @Deposit, @CheckIn, @CheckOut, @BankName, @CreditCardNumber, @DiscountID)", cnMain);
            Build_INSERT_Parameters(aBooking);
        }

        private void Create_UPDATE_Command(Booking aBooking)
        {
            //Command that must be used to insert values into bookings table
            //The GuestID and BookingReference cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE Booking SET GuestID =@GuestID, ReferenceNumber =@ReferenceNumber, RoomsBooked =@RoomsBooked, RoomRate =@RoomRate, " +
                "Deposit =@Deposit, CheckIn =@CheckIn, CheckOut =@CheckOut, BankName =@BankName, PaymentStatus =@PaymentStatus, CreditCardNumber =@CreditCardNumber, DiscountID =@DiscountID " + "WHERE ReferenceNumber = @ReferenceNumber", cnMain);
            Build_UPDATE_Parameters(aBooking);
        }

        private string Create_DELETE_Command(Booking aBooking)
        {
            string errorString = null;
            //Command used to delete values from the Bookings table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Booking WHERE ReferenceNumber = @ReferenceNumber", cnMain);
  
            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }

        //update data source
        public bool UpdateDataSource(Booking aBooking)
        {
            bool success = true;
            Create_INSERT_Command(aBooking);
            Create_UPDATE_Command(aBooking);
            Create_DELETE_Command(aBooking);

            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool UpdateBookingDataSource(Booking booking)
        {
            bool success = true;
            Create_UPDATE_Command(booking);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        public bool InsertBookingDataSource(Booking booking)
        {
            bool success = true;
            Create_INSERT_Command(booking);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        
        public bool DeleteBookingDataSource(Booking booking)
        {
            bool success = true;
            Create_DELETE_Command(booking);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        #endregion
    }
}   
