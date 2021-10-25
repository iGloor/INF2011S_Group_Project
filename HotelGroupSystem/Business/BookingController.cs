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

        public static int currentBookingId;
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
           // bookingDB = new BookingDB();
           // bookings = bookingDB.AllBookings;
        }

        #endregion

        #region Database Communication.
        public Booking RecordBooking(Booking booking)
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
           
            if (booking.BookingID == 0)
            {
                bookingDB.DataSetChange(booking, DB.DBOperation.Add);
                bookingDB.InsertBookingDataSource(booking);
            }
            else
            {
                bookingDB.DataSetChange(booking, DB.DBOperation.Update);
                bookingDB.UpdateBookingDataSource(booking);
            }
            bookingDB.RetrieveAllBookings();
            bookings = bookingDB.AllBookings;
            booking = bookings.First(x => x.ReferenceNumber == booking.ReferenceNumber);
            currentBookingId = booking.BookingID;
            return booking;
        }

        public void DeleteBooking(Booking booking)
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;

            if (!(booking.BookingID == 0))
            {
                bookingDB.DataSetChange(booking, DB.DBOperation.Delete);
                bookingDB.DeleteBookingDataSource(booking);
            }
            
        }


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
            
            BookingDB bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
            Booking foundBooking = null;
            if (bookings.Any(x => x.ReferenceNumber.Equals(bookRef, StringComparison.OrdinalIgnoreCase)))
            {
                foundBooking = bookings.First(x => x.ReferenceNumber.Equals(bookRef, StringComparison.OrdinalIgnoreCase));
                currentBookingId = foundBooking.BookingID;
            }
            return foundBooking;
        }

        public Booking FindById(int bookingId)
        {

            BookingDB bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
            Booking foundBooking = null;
            if (bookings.Any(x => x.BookingID == bookingId))
            {
                foundBooking = bookings.First(x => x.BookingID == bookingId);
                currentBookingId = foundBooking.BookingID;
            }
            return foundBooking;
        }

        public Booking FindByCurrentBookingId()
        {
            int bookingId = currentBookingId;

            BookingDB bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
            Booking foundBooking = null;
            if (bookings.Any(x => x.BookingID == bookingId))
            {
                foundBooking = bookings.First(x => x.BookingID == bookingId);
            }
            return foundBooking;
        }

        public int FindIndex(Booking aBooking)
        {
            int counter = 0;
            bool found = false;
            found = (aBooking.ReferenceNumber == bookings[counter].ReferenceNumber);   //using a Boolean Expression to initialise found
            while (!(found) & counter < bookings.Count - 1)
            {
                counter += 1;
                found = (aBooking.ReferenceNumber == bookings[counter].ReferenceNumber);
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
