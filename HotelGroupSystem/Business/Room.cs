using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGroupSystem.Business
{
    class Room
    {
        #region Declare Variables
        //Room number
        private int roomNumber;

        //Room status
        public enum RoomStatus
        {
            Available = 0,
            Booked = 1
        }
        protected RoomStatus roomState;

        //Rate per night for each season
        public enum RateSeason
        {
            lowSeason = 550,
            midSeason = 750,
            highSeason = 995
        }
        protected RateSeason seasonalRate;
        #endregion

        #region Property Methods
        public int RoomNumber
        {
            get { return roomNumber; }
        }
        public RoomStatus RoomState
        {
            get { return roomState; }
            set { roomState = value; }
        }
        public RateSeason SeasonalRate
        {
            get { return seasonalRate; }
            set { seasonalRate = value; }
        }
        #endregion

        #region Constructor
        public Room()
        {

        }
        public Room(int rNumber, RoomStatus state, RateSeason seasonRate)
        {
            roomNumber = rNumber;
            roomState = state;
            seasonalRate = seasonRate;
        }
        #endregion

        #region Methods

        #endregion
    }
}
