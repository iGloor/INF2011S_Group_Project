﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelGroupSystem.Presentation
{
    public partial class BookingDetails : Form
    {
        
        public BookingDetails()
        {
            InitializeComponent();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reference Number: " + Environment.NewLine + "Guest Name: ", "Comfirmation Letter");
        }
    }
}
