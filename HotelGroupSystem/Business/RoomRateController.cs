using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGroupSystem.Data;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Business
{
    class RoomRateController
    {
        #region Data Members
        RoomRateDB roomRateDB;
        Collection<RoomRate> roomRates;
        #endregion

        #region Properties
        public Collection<RoomRate> AllRoomRates
        {
            get
            {
                return roomRates;
            }
        }
        #endregion

        #region Constructor
        public RoomRateController()
        {
            roomRateDB = new RoomRateDB();
            roomRates = roomRateDB.AllRoomRates;
        }

        #endregion

        public decimal ComputeRateForPeriod(DateTime startDate, DateTime endDate)
        {
            decimal rate = 0;
            int counter = endDate.Subtract(startDate).Days;
            List<decimal> applicableRates = new List<decimal>();
            
            if((roomRates.Count == 0))
            {
                return rate;
            }

            for (int i = 0; i < counter; i++)
            {
                DateTime bookingDate = startDate.AddDays(i);
                foreach (RoomRate roomRate in roomRates)
                {
                    if(bookingDate >= roomRate.SeasonStart && bookingDate <= roomRate.SeasonEnd)
                    {
                        applicableRates.Add(roomRate.Rate);
                        break;
                    }
                }
            }
            rate = decimal.Round(applicableRates.Average(), 0);
            
            return rate;
        }

        #region Database Communication.
        public void DataMaintenance(RoomRate roomRate, DB.DBOperation operation)
        {
            int index = 0;
            index = FindIndex(roomRate);
            roomRates[index] = roomRate;
        }

        #endregion

        #region Searching through a collection

        //This method receives a booking ref as a parameter; finds the booking object in the collection of bookings and then returns this object
        public RoomRate Find(int roomRateID)
        {
            int index = 0;
            //check if it is the first booking
            bool found = (roomRates[index].RoomRateID == roomRateID); 
            int count = roomRates.Count;
            while (!(found) && (index < roomRates.Count - 1))  //if not "this" booking and you are not at the end of the list 
            {
                index = index + 1;
                found = (roomRates[index].RoomRateID == roomRateID);   // this will be TRUE if found
            }
            return roomRates[index];  // this is the one!  
        }

        public int FindIndex(RoomRate roomRate)
        {
            int counter = 0;
            bool found = false;
            found = (roomRate.RoomRateID == roomRates[counter].RoomRateID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < roomRates.Count - 1)
            {
                counter += 1;
                found = (roomRate.RoomRateID == roomRates[counter].RoomRateID);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion

    }
}
