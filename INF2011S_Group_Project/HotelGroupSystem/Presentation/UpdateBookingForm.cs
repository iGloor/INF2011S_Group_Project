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
            dateLabel.Show();
            dateTxt.Show();
            totalLabel.Show();
            totalTxt.Show();
            gDetailsLabel.Show();
            nameLabel.Show();
            nameTxt.Show();
            phoneLabel.Show();
            phoneTxt.Show();
            emailLabel.Show();
            emailTxt.Show();
            addressLabel.Show();
            addressTxt.Show();
            billDetailsLabel.Show();
            cardNoLabel.Show();
            cardNoTxt.Show();
            bankLabel.Show();
            bankTxt.Show();
            bDetailsUpdateBtn.Show();
            cancelBtn.Show();
            saveAllBtn.Show();
            deleteBtn.Show();
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
            dateLabel.Hide();
            dateTxt.Hide();
            totalLabel.Hide();
            totalTxt.Hide();
            gDetailsLabel.Hide();
            nameLabel.Hide();
            nameTxt.Hide();
            phoneLabel.Hide();
            phoneTxt.Hide();
            emailLabel.Hide();
            emailTxt.Hide();
            addressLabel.Hide();
            addressTxt.Hide();
            billDetailsLabel.Hide();
            cardNoLabel.Hide();
            cardNoTxt.Hide();
            bankLabel.Hide();
            bankTxt.Hide();
            bDetailsUpdateBtn.Hide();
            cancelBtn.Hide();
            saveAllBtn.Hide();
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
