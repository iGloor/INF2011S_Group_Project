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
        public string roomState;

        #endregion

        #region Property Methods
        public int RoomNumbers
        {
            get { return roomNumber; }
        }
        public string RoomState
        {
            get { return roomState; }
            set { roomState = value; }
        }
        
        #endregion

        #region Constructor
        public Room()
        {

        }
        public Room(int rNumber, string state)
        {
            roomNumber = rNumber;
            roomState = state;
        }
        #endregion

        #region Methods

        #endregion
    }
}
