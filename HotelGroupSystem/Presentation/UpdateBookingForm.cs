using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelGroupSystem.Presentation;
using HotelGroupSystem.Business;

namespace HotelGroupSystem.Presentation
{
    public partial class UpdateBookingForm : Form
    {
        #region Declare Variables

        #endregion

        #region Property Methods
        #endregion

        #region Constructor
        public UpdateBookingForm()
        {
            InitializeComponent();

            //Call hide fields method
            HideFields();

        }
        #endregion

        #region Events

        #endregion

        #region Utility Methods
        private void ShowAll()
        {
            //Hide the following:
            checkRefNoBtn.Hide();

            //Show the following:
            feedbackLabel.Show();
            bookDetailsLabel.Show();
            roomLabel.Show();
            roomTxt.Show();
            rateLabel.Show();
            rateTxt.Show();
            checkInLabel.Show();
            checkInTxt.Show();
            checkOutLabel.Show();
            checkOutTxt.Show();
            totalLabel.Show();
            totalTxt.Show();
            gDetailsLabel.Show();
            idLabel.Show();
            idTxt.Show();
            nameLabel.Show();
            nameTxt.Show();
            checkDatesBtn.Show();
            calculateAmountBtn.Show();
            bDetailsUpdateBtn.Show();
            cancelBtn.Show();
            deleteBtn.Show();
            discountCodeLabel.Show();
            discountCodeTxt.Show();
        }

        private void HideFields()
        {
            //Show the following:
            refNoLabel.Show();
            refNumberTxt.Show();
            checkRefNoBtn.Show();

            //Hide the following:
            feedbackLabel.Hide();
            bookDetailsLabel.Hide();
            roomLabel.Hide();
            roomTxt.Hide();
            rateLabel.Hide();
            rateTxt.Hide();
            checkInLabel.Hide();
            checkInTxt.Hide();
            checkOutLabel.Hide();
            checkOutTxt.Hide();
            totalLabel.Hide();
            totalTxt.Hide();
            gDetailsLabel.Hide();
            idLabel.Hide();
            idTxt.Hide();
            nameLabel.Hide();
            nameTxt.Hide();
            checkDatesBtn.Hide();
            calculateAmountBtn.Hide();
            bDetailsUpdateBtn.Hide();
            cancelBtn.Hide();
            deleteBtn.Hide();

        }
        #endregion

        private void UpdateBookingForm_Load(object sender, EventArgs e)
        {

        }

        private void checkRefNoBtn_Click(object sender, EventArgs e)
        {
            //if statement if there is a booking number call show call method and populate textboxes
            ShowAll();
        }
    }
}
