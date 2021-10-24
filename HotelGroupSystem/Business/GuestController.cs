﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HotelGroupSystem.Data;

namespace HotelGroupSystem.Business
{
    class GuestController
    {
        #region Data Members
        GuestDB guestDB;
        Collection<Guest> guests;
        #endregion

        #region Properties
        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }
        #endregion

        #region Constructor
        public GuestController()
        {
            //guestDB = new GuestDB();
            //guests = guestDB.AllGuests;
        }

        #endregion

        #region Methods
        
       
        #endregion

        #region Database Communication.

        public Guest RecordGuest(Guest guest)
        {
            guestDB = new GuestDB();
            guests = guestDB.AllGuests;

            if (guest.GuestID == 0)
            {
                guestDB.DataSetChange(guest, DB.DBOperation.Add);
                guestDB.InsertGuestDataSource(guest);
            }
            else
            {
                guestDB.DataSetChange(guest, DB.DBOperation.Update);
                guestDB.UpdateGuestDataSource(guest);
            }
            guestDB.RetrieveAllGuests();
            guests = guestDB.AllGuests;
            guest = guests.First(x => x.Surname == guest.Surname && x.FirstName == guest.FirstName);
            return guest;
        }

        public void DataMaintenance(Guest aGuest, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
           guestDB.DataSetChange(aGuest, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    guests.Add(aGuest);
                    break;
                case DB.DBOperation.Update:
                    index = FindIndex(aGuest);
                    guests[index] = aGuest;  // replace guest at this index with the updated guest
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);  // find the index of the specific guest in collection
                    guests.RemoveAt(index);  // remove that guest from the collection
                    break;

            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Guest guest)
        {
            //***call the BookingDB method that will commit the changes to the database
            return guestDB.UpdateDataSource(guest);
        }
        #endregion

        #region Searching through a collection

        //This method receives a Guest ID as a parameter; finds the booking object in the collection of guests and then returns this object
        public Guest Find(int gID)
        {
            GuestDB guestDB = new GuestDB();
            guests = guestDB.AllGuests;
            Guest foundGuest = null;
            if (guests.Any(x => x.GuestID == gID))
            {
                foundGuest = guests.First(x => x.GuestID == gID);
            }            
            return foundGuest;  
        }

        public int FindIndex(Guest aGuest)
        {
            int counter = 0;
            bool found = false;
            found = (aGuest.GuestID == guests[counter].GuestID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < guests.Count - 1)
            {
                counter += 1;
                found = (aGuest.GuestID == guests[counter].GuestID);
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
