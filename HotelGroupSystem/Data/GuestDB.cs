using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HotelGroupSystem.Business;
using System.Data;
using System.Data.SqlClient;

namespace HotelGroupSystem.Data
{
    class GuestDB: DB
    {
        #region Data members
        //class data members
        private string table2 = "Guest";
        private string sqlLocal2 = "SELECT * FROM Guest";
        private Collection<Guest> guests;
        #endregion

        #region Property Method: Collection
        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }
        #endregion

        #region Constructor
        public GuestDB() : base()
        {
            //instantiate guest collection
            guests = new Collection<Guest>();
            //fill data set
            FillDataSet(sqlLocal2, table2);
            Add2Collection(table2);
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
            Guest guest;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    guest = new Guest();

                    //Obtain each guest attribute from the specific field in the row in the table
                    guest.GuestID = Convert.ToInt32(myRow["GuestID"]);
                    guest.Name = Convert.ToString(myRow["Name"]).TrimEnd();

                    guest.Phone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    guest.Phone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    //guest.getAge = Convert.ToInt32(myRow["Age"]);
                    guest.Address = Convert.ToString(myRow["Address"]).TrimEnd();
                    guest.Email = Convert.ToString(myRow["Email"]).TrimEnd();

                    //add booking to bookings collection
                    guests.Add(guest);

                }
            }
        }

        private void FillRow(DataRow aRow, Guest aGuest, DB.DBOperation operation)
        {

            if (operation == DB.DBOperation.Add)
            {
                //aRow["GuestID"] = aGuest.getGuestID;  //NOTE square brackets to indicate index of collections of fields in row.
            }

           // aRow["Name"] = aGuest.getName;
            //aRow["Phone"] = aGuest.getPhone;
            //aRow["Address"] = aGuest.getAddress;
            //aRow["Age"] = aGuest.getAge;

        }

        private int FindRow(Guest aGuest, string table)
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
                    //check if guest id equal to what we are looking for
                    //if (aGuest.getGuestID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["GuestID"]))
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
        public void DataSetChange(Guest aGuest, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table2;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aGuest, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aGuest, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Guest aGuest)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 15, "Name");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@GuestID", SqlDbType.NVarChar, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);


            param = new SqlParameter("@Age", SqlDbType.SmallInt, 100, "Age");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Address", SqlDbType.NVarChar, 10, "Address");
            daMain.InsertCommand.Parameters.Add(param);

        }


        private void Build_UPDATE_Parameters(Guest aGuest)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 15, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //create and add update PHONE parameter
            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //create and add update address paramete
            param = new SqlParameter("@Address", SqlDbType.NVarChar, 15, "Address");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the booking reference of record that needs to change with the original guestID of the record
            param = new SqlParameter("@Original_GuestID", SqlDbType.NVarChar, 15, "GuestID");
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

        private void Create_INSERT_Command(Guest aGuest)
        {
            //Command used to insert values into the Bookings table..

            daMain.InsertCommand = new SqlCommand("INSERT into Bookings (GuestID, BookingReference, RoomsBooked, RoomRate, TotalDue, CheckInDate, CheckOutDate) VALUES (@GuestID, @BookingReference, @RoomsBooked, @RoomRate, @TotalDue, @CheckInDate,CheckOutDate)", cnMain);
            Build_INSERT_Parameters(aGuest);
        }

        private void Create_UPDATE_Command(Guest aGuest)
        {
            //Command that must be used to insert values into bookings table
            //The GuestID and BookingReference cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE Bookings SET Address =@Address, Name =@Name, Phone =@Phone " + "WHERE GuestID = @Original_GuestID", cnMain);
            Build_UPDATE_Parameters(aGuest);
        }

        private string Create_DELETE_Command(Guest aGuest)
        {
            string errorString = null;
            //Command used to delete values from the Guest table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Guest WHERE GuestID = @GuestID", cnMain);

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
        public bool UpdateDataSource(Guest aGuest)
        {
            bool success = true;
            Create_INSERT_Command(aGuest);
            Create_UPDATE_Command(aGuest);
            Create_DELETE_Command(aGuest);

            success = UpdateDataSource(sqlLocal2, table2);
            return success;
        }

        #endregion
    }
}
