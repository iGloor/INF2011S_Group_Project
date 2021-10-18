using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Data
{
    class GuestDB: DB
    {
        #region Data members
        //class data members
        private string table2 = "Guest";
        private string sqlLocal2 = "SELECT * FROM Guest";
        private Collection<Guest> guests;
        #endregion
    }
}
