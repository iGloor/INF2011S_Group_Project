using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGroupSystem.Business
{
    class RoomRate
    {
        #region Declare Variables
        //Primary Key
        private int roomRateID;

        private decimal seasonalRate;

        private string season;
        #endregion

        #region Property Methods
        public int RoomRateID
        {
            get { return roomRateID; }
        }

        public decimal SeasonalRate
        {
            get { return seasonalRate; }
            set { seasonalRate = value; }
        }
        #endregion

        #region Constructor
        public RoomRate()
        {

        }
        public RoomRate(int rateId, decimal seasonRate)
        {
            roomRateID = rateId;
            seasonalRate = seasonRate;
        }
        #endregion
    }
}