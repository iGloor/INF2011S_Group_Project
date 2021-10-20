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
        private string discountCode;
        public enum DiscountPercentage
        {
            cancelDepositMade = 50,
            cancelNoDeposit = 10,
                noDiscount = 0
        }
        protected DiscountPercentage discountPercent;
        #endregion

        #region Property Methods
        public string DiscountCode
        {
            get { return discountCode; }
            set { discountCode = value; }
        }
        public DiscountPercentage DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }
        #endregion

        #region Constructor
        public Discount()
        {
            discountCode = "";
            discountPercent = Discount.DiscountPercentage.noDiscount;
        }
        #endregion

        #region Methods
        public virtual decimal GetDiscount()
        {
            if (discountPercent == DiscountPercentage.cancelDepositMade)
            {
                return 10 / 100;
            }
            else if (discountPercent == DiscountPercentage.cancelNoDeposit)
            {
                return 50/100 ;
            }
            else
            {
                  return 0;
            }
        }
        #endregion

    }
}
