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
        private string season;
        private decimal rate;
        private DateTime seasonStart;
        private DateTime seasonEnd;
        #endregion

        #region Property Methods
        public int RoomRateID
        {
            get { return roomRateID; }
            set { roomRateID = value; }
        }

        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public string Season
        {
            get { return season; }
            set { season = value; }
        }

        public DateTime SeasonStart
        {
            get { return seasonStart; }
            set { seasonStart = value; }
        }

        public DateTime SeasonEnd
        {
            get { return seasonEnd; }
            set { seasonEnd = value; }
        }

        #endregion

        #region Constructor
        public RoomRate()
        {

        }
        public RoomRate(int rateId, decimal seasonRate, string s, DateTime start, DateTime end)
        {
            roomRateID = rateId;
            rate = seasonRate;
            season = s;
            seasonStart = start;
            seasonEnd = end;
        }
        #endregion
    }
}