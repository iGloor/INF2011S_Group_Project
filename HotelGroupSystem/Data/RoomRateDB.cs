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
    class RoomRateDB :DB
    {
        #region Data Members
        private string roomRateTable = "RoomRate";
        private string roomRateSql = "SELECT * FROM RoomRate";

        private Collection<RoomRate> roomRates;
        #endregion

        #region Property method: Collection
        public Collection<RoomRate> AllRoomRates
        {
            get
            {
                return roomRates;
            }
        }
        #endregion

        #region Constructor
        public RoomRateDB() : base()
        {
            roomRates = new Collection<RoomRate>();
            FillDataSet(roomRateSql, roomRateTable);
            AddToRoomRateCollection(roomRateTable);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        private void AddToRoomRateCollection(string table)
        {
            DataRow myRow = null;
            RoomRate roomRate;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    roomRate = new RoomRate();
                    //Obtain each booking attribute from the specific field in the row in the table
                    roomRate.RoomRateID = Convert.ToInt32(myRow["RoomRateID"]);
                    roomRate.Season = Convert.ToString(myRow["Season"]);
                    roomRate.Rate = Convert.ToDecimal(myRow["RoomRate"]);
                    roomRate.SeasonStart = Convert.ToDateTime(myRow["SeasonStart"]);
                    roomRate.SeasonEnd = Convert.ToDateTime(myRow["SeasonEnd"]);
                    //add booking to bookings collection
                    roomRates.Add(roomRate);

                }
            }
        }


        #endregion
    }
}
