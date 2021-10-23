using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGroupSystem.Business
{
    class Discount
    {
        #region Declare Variables
        private int discountID;
        private string discountCode;
        private decimal discountPercent;
        #endregion

        #region Property Methods
        public string DiscountCode
        {
            get { return discountCode; }
            set { discountCode = value; }
        }
        public decimal DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }
        #endregion

        #region Constructor
        public Discount()
        {
            discountCode = "";
            discountPercent = 0;
        }
        #endregion

        #region Methods
        public virtual decimal GetDiscount()
        {
            return 0;
        }
        #endregion

    }
}
