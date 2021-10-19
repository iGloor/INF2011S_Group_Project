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
    class BookingController
    {
        #region Data Members
        BookingDB bookingDB;
        Collection<Booking> bookings;
        #endregion

        #region Properties
        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }
        #endregion

        #region Constructor
        public BookingController()
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
        }
        
        #endregion

        #region Database Communication.
        public void DataMaintenance(Booking aBooking, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            bookingDB.DataSetChange(aBooking, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    bookings.Add(aBooking);
                    break;
                case DB.DBOperation.Update:
                    index = FindIndex(aBooking);
                    bookings[index] = aBooking;  // replace booking at this index with the updated booking
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aBooking);  // find the index of the specific booking in collection
                    bookings.RemoveAt(index);  // remove that booking from the collection
                    break;

            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Booking booking)
        {
            //***call the BookingDB method that will commit the changes to the database
            return bookingDB.UpdateDataSource(booking);
        }
        #endregion

        #region Searching through a collection

        //This method receives a booking ref as a parameter; finds the booking object in the collection of bookings and then returns this object
        public Booking Find(string bookRef)
        {
            int index = 0;
            //check if it is the first booking
            bool found = (bookings[index].BookingRef == bookRef); 
            int count = bookings.Count;
            while (!(found) && (index < bookings.Count - 1))  //if not "this" booking and you are not at the end of the list 
            {
                index = index + 1;
                found = (bookings[index].BookingRef == bookRef);   // this will be TRUE if found
            }
            return bookings[index];  // this is the one!  
        }

        public int FindIndex(Booking aBooking)
        {
            int counter = 0;
            bool found = false;
            found = (aBooking.BookingRef == bookings[counter].BookingRef);   //using a Boolean Expression to initialise found
            while (!(found) & counter < bookings.Count - 1)
            {
                counter += 1;
                found = (aBooking.BookingRef == bookings[counter].BookingRef);
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
