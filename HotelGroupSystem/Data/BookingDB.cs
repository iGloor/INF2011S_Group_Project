﻿using System;
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
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
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

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    booking = new Booking();
                    booking.GuestID = Convert.ToInt32(myRow["GuestID"]);

                    //Obtain each booking attribute from the specific field in the row in the table
                    booking.BookingRef = Convert.ToInt32(myRow["BookingReference"]);
                    booking.CheckInDate = Convert.ToString(myRow["CheckInDate"]).TrimEnd();
                    booking.CheckOutDate = Convert.ToString(myRow["CheckOutDate"]).TrimEnd();
                    booking.RoomsBooked = Convert.ToInt32(myRow["RoomsBooked"]);
                    //booking.RoomRate = Convert.ToDecimal(myRow["RoomRateID"]);
                    booking.TotalDue = Convert.ToDecimal(myRow["TotalDue"]);

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
                aRow["BookingReference"] = aBooking.BookingRef;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["GuestID"] = aBooking.GuestID;
            }

            aRow["RoomsBooked"] = aBooking.RoomsBooked;
            //aRow["RoomRateID"] = aBooking.RoomRate;
            //aRow["TotalDue"] = aBooking.TotalDue;
            aRow["CheckInDate"] = Convert.ToDateTime(aBooking.CheckInDate);
            aRow["CheckOutDate"] = Convert.ToDateTime(aBooking.CheckOutDate);

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
                   if (aBooking.BookingRef == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["BookingReference"]))
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
            aRow = dsMain.Tables[dataTable].NewRow();
            FillRow(aRow, aBooking,operation);
            //Add to the dataset
            dsMain.Tables[dataTable].Rows.Add(aRow);
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters()
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@BookingReference", SqlDbType.Int, 15, "BookingReference");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@GuestID", SqlDbType.Int, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);


            param = new SqlParameter("@RoomsBooked", SqlDbType.SmallInt, 100, "RoomsBooked");
            daMain.InsertCommand.Parameters.Add(param);

           /* param = new SqlParameter("@TotalDue", SqlDbType.Money, 15, "TotalDue");
            daMain.InsertCommand.Parameters.Add(param);*/

            param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 10, "CheckInDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 10, "CheckOutDate");
            daMain.InsertCommand.Parameters.Add(param);

            /*param = new SqlParameter("@RoomRateID", SqlDbType.Money, 10, "RoomRateID");
            daMain.InsertCommand.Parameters.Add(param);*/
        }

        #region commented out code
         private void Build_UPDATE_Parameters()
         {
             //---Create Parameters to communicate with SQL UPDATE
             SqlParameter param = default(SqlParameter);

             param = new SqlParameter("@RoomsBooked", SqlDbType.SmallInt, 10, "RoomsBooked");
             param.SourceVersion = DataRowVersion.Current;
             daMain.UpdateCommand.Parameters.Add(param);

             //create and add update check in date parameter
             param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 15, "CheckInDate");
             param.SourceVersion = DataRowVersion.Current;
             daMain.UpdateCommand.Parameters.Add(param);

             param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 15, "CheckOutDate");
             param.SourceVersion = DataRowVersion.Current;
             daMain.UpdateCommand.Parameters.Add(param);

             //testing the booking reference of record that needs to change with the original booking reference of the record
             param = new SqlParameter("@Original_BookingReference", SqlDbType.NVarChar, 15, "BookingReference");
             param.SourceVersion = DataRowVersion.Original;
             daMain.UpdateCommand.Parameters.Add(param);

         }

         private void Build_DELETE_Parameters()
         {
             //Create Parameters to communicate with SQL DELETE
             SqlParameter param;
             param = new SqlParameter("@BookingReference", SqlDbType.NVarChar, 15, "BookingReference");
             param.SourceVersion = DataRowVersion.Original;
             daMain.DeleteCommand.Parameters.Add(param);
         }
        #endregion

        private void Create_INSERT_Command()
        {
            //Command used to insert values into the Bookings table..

            daMain.InsertCommand = new SqlCommand("INSERT into Bookings (GuestID, BookingReference, RoomsBooked, CheckInDate, CheckOutDate) VALUES (@guestID, @BookingReference, @RoomsBooked, @CheckInDate, @CheckOutDate)", cnMain);
            //daMain.InsertCommand = new SqlCommand("INSERT into Bookings (GuestID, BookingReference, RoomsBooked, RoomRate, TotalDue, CheckInDate, CheckOutDate) VALUES (@GuestID, @BookingReference, @RoomsBooked, @RoomRate, @TotalDue, @CheckInDate,CheckOutDate)", cnMain);
            Build_INSERT_Parameters();
        }
        #region

          private void Create_UPDATE_Command()
          {
              //Command that must be used to insert values into bookings table
              //The GuestID and BookingReference cannot be changed

              daMain.UpdateCommand = new SqlCommand("UPDATE Bookings SET RoomsBooked =@RoomsBooked, CheckInDate =@CheckInDate, CheckOutDate =@CheckOutDate " + "WHERE BookingReference = @Original_BookingReference", cnMain);
              Build_UPDATE_Parameters();
          }

          private string Create_DELETE_Command()
          {
              string errorString = null;
              //Command used to delete values from the Bookings table
              daMain.DeleteCommand = new SqlCommand("DELETE FROM Bookings WHERE BookingReference = @BookingReference", cnMain);

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
        #endregion
        //update data source
        public bool UpdateDataSource()
        {
            bool success = true;
            Create_INSERT_Command();
            Create_UPDATE_Command();
            Create_DELETE_Command();

            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        #endregion
    }
}   
