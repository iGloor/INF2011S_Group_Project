using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Business;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace HotelGroupSystem.Data
{
    class RoomDB: DB
    {
        #region Data Members
        private string table3 = "Room";
        private string sqlLocal3 = "SELECT * FROM Room";
        private Collection<Room> rooms;
        #endregion

        #region Property Method: Collection
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }
        #endregion

        #region Constructor
        public RoomDB() : base()
        {
            //instantiate guest collection
            rooms = new Collection<Room>();
            //fill data set
            FillDataSet(sqlLocal3, table3);
            Add2Collection(table3);
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
            Room room;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    room= new Room();

                    //Obtain each Room attribute from the specific field in the row in the table
                    room.RoomState = (Room.RoomStatus)(myRow["RoomState"]);
                    room.SeasonalRate = (Room.RateSeason)(myRow["Rate"]);
                    //add booking to bookings collection
                    rooms.Add(room);

                }
            }
        }

        private void FillRow(DataRow aRow, Room aRoom, DB.DBOperation operation)
        {

            if (operation == DB.DBOperation.Add)
            {
                //aRow["GuestID"] = aGuest.getGuestID;  //NOTE square brackets to indicate index of collections of fields in row.
            }

        }

       private int FindRow(Room aRoom, string table)
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
                    if (aRoom.RoomNumber == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["RoomNumber"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }

        #endregion

        #region Build Parameters, Create Commands & Update database
        /*private void Build_INSERT_Parameters(Room aRoom)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@RoomNumber", SqlDbType.SmallInt, 5, "RoomNumber");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@GuestID", SqlDbType.NVarChar, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);


            param = new SqlParameter("@Age", SqlDbType.SmallInt, 100, "Age");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Address", SqlDbType.NVarChar, 10, "Address");
            daMain.InsertCommand.Parameters.Add(param);

        }*/


        private void Build_UPDATE_Parameters(Room aRoom)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);


            //create and add update room status parameter
            param = new SqlParameter("@RoomStatus", SqlDbType.SmallInt, 5, "RoomStatus");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //create and add update room rate paramete
            param = new SqlParameter("@RoomRate", SqlDbType.SmallMoney, 15, "RoomRate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the booking reference of record that needs to change with the original guestID of the record
            param = new SqlParameter("@Original_RoomNumber", SqlDbType.NVarChar, 15, "RoomNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

        }

 /*       private void Build_DELETE_Parameters()
        {
            //Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@BookingReference", SqlDbType.NVarChar, 15, "BookingReference");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }
 */
 /*       private void Create_INSERT_Command(Guest aGuest)
        {
            //Command used to insert values into the Bookings table..

            daMain.InsertCommand = new SqlCommand("INSERT into Bookings (GuestID, BookingReference, RoomsBooked, RoomRate, TotalDue, CheckInDate, CheckOutDate) VALUES (@GuestID, @BookingReference, @RoomsBooked, @RoomRate, @TotalDue, @CheckInDate,CheckOutDate)", cnMain);
            Build_INSERT_Parameters(aGuest);
        }*/

        private void Create_UPDATE_Command(Room aRoom)
        {
            //Command that must be used to insert values into bookings table
            //The GuestID and BookingReference cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE Room SET RoomRate =@RoomRate, RoomStatus =@RoomStatus " + "WHERE RoomNumber = @Original_RoomNumber", cnMain);
            Build_UPDATE_Parameters(aRoom);
        }

 /*       private string Create_DELETE_Command(Guest aGuest)
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
        }*/

        //update data source
        public bool UpdateDataSource(Room aRoom)
        {
            bool success = true;
            
            Create_UPDATE_Command(aRoom);

            success = UpdateDataSource(sqlLocal3, table3);
            return success;
        }

        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Room aRoom, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table3;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aRoom, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    //Add to the dataset
                    break;
                case DB.DBOperation.Update:
                    // Find row to update
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aRoom, dataTable)];
                    //Fill this row for the update operation by calling the FillRow method
                    FillRow(aRow, aRoom, operation);
                    break;
                case DB.DBOperation.Delete:
                    //find row and delete it
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aRoom, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion
    }
}
