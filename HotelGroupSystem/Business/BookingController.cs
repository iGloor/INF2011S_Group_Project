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
            return bookingDB.UpdateDataSource();
        }
        #endregion

        #region Searching through a collection

        //This method receives a booking ref as a parameter; finds the booking object in the collection of bookings and then returns this object
        public Booking Find(int bookRef)
        {
            int index = 0;
            int found = 0;

            //check if it is the first guest  
            for (int i = 0; i < bookings.Count; i++)
            {

                if (bookRef == bookings[i].BookingRef)
                {
                    found += 1;
                    index = i;
                }

            }
            if (found == 1)
            {
                return bookings[index];
            }
            else { return null; }
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

        #region Generate Booking Reference
        // Instantiate random number generator.    
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; 

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        // Generates a random booking reference.  
        // 2-LowerCase + 3-Digits + 2-UpperCase  
        public string BookingRef()
        {
            var referenceBuilder = new StringBuilder();

            // 2-Letters lower case   
            referenceBuilder.Append(RandomString(2, true));

            // 3-Digits between 100 and 999  
            referenceBuilder.Append(RandomNumber(100, 999));

            // 2-Letters upper case  
            referenceBuilder.Append(RandomString(2));
            return referenceBuilder.ToString();

        }
        #endregion
    }
} 
