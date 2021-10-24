
namespace HotelGroupSystem.Presentation
{
    partial class AvailabilityCheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.availabilityLabel = new System.Windows.Forms.Label();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.summaryView = new System.Windows.Forms.ListView();
            this.checkBtn = new System.Windows.Forms.Button();
            this.newBookingBtn = new System.Windows.Forms.Button();
            this.updateBookingBtn = new System.Windows.Forms.Button();
            this.checkInLabel = new System.Windows.Forms.Label();
            this.checkOutLabel = new System.Windows.Forms.Label();
            this.feedbackLabel2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(51, 69);
            this.monthCalendar1.MaxDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.MaxSelectionCount = 31;
            this.monthCalendar1.MinDate = new System.DateTime(2021, 12, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // availabilityLabel
            // 
            this.availabilityLabel.AutoSize = true;
            this.availabilityLabel.Location = new System.Drawing.Point(97, 43);
            this.availabilityLabel.Name = "availabilityLabel";
            this.availabilityLabel.Size = new System.Drawing.Size(158, 17);
            this.availabilityLabel.TabIndex = 1;
            this.availabilityLabel.Text = "Check Room Availability";
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.Location = new System.Drawing.Point(356, 26);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(96, 17);
            this.feedbackLabel.TabIndex = 2;
            this.feedbackLabel.Text = "For the dates:";
            // 
            // summaryView
            // 
            this.summaryView.HideSelection = false;
            this.summaryView.Location = new System.Drawing.Point(345, 76);
            this.summaryView.Name = "summaryView";
            this.summaryView.Size = new System.Drawing.Size(357, 207);
            this.summaryView.TabIndex = 3;
            this.summaryView.UseCompatibleStateImageBehavior = false;
            this.summaryView.SelectedIndexChanged += new System.EventHandler(this.summaryView_SelectedIndexChanged);
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(94, 323);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(161, 40);
            this.checkBtn.TabIndex = 4;
            this.checkBtn.Text = "Check Availability";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // newBookingBtn
            // 
            this.newBookingBtn.Location = new System.Drawing.Point(356, 323);
            this.newBookingBtn.Name = "newBookingBtn";
            this.newBookingBtn.Size = new System.Drawing.Size(161, 40);
            this.newBookingBtn.TabIndex = 5;
            this.newBookingBtn.Text = "Create Booking";
            this.newBookingBtn.UseVisualStyleBackColor = true;
            this.newBookingBtn.Click += new System.EventHandler(this.newBookingBtn_Click);
            // 
            // updateBookingBtn
            // 
            this.updateBookingBtn.Location = new System.Drawing.Point(541, 323);
            this.updateBookingBtn.Name = "updateBookingBtn";
            this.updateBookingBtn.Size = new System.Drawing.Size(161, 40);
            this.updateBookingBtn.TabIndex = 6;
            this.updateBookingBtn.Text = "Update Booking";
            this.updateBookingBtn.UseVisualStyleBackColor = true;
            this.updateBookingBtn.Click += new System.EventHandler(this.updateBookingBtn_Click);
            // 
            // checkInLabel
            // 
            this.checkInLabel.AutoSize = true;
            this.checkInLabel.Location = new System.Drawing.Point(356, 56);
            this.checkInLabel.Name = "checkInLabel";
            this.checkInLabel.Size = new System.Drawing.Size(46, 17);
            this.checkInLabel.TabIndex = 7;
            this.checkInLabel.Text = "label1";
            // 
            // checkOutLabel
            // 
            this.checkOutLabel.AutoSize = true;
            this.checkOutLabel.Location = new System.Drawing.Point(512, 56);
            this.checkOutLabel.Name = "checkOutLabel";
            this.checkOutLabel.Size = new System.Drawing.Size(103, 17);
            this.checkOutLabel.TabIndex = 8;
            this.checkOutLabel.Text = "checkOutLabel";
            // 
            // feedbackLabel2
            // 
            this.feedbackLabel2.AutoSize = true;
            this.feedbackLabel2.Location = new System.Drawing.Point(450, 56);
            this.feedbackLabel2.Name = "feedbackLabel2";
            this.feedbackLabel2.Size = new System.Drawing.Size(20, 17);
            this.feedbackLabel2.TabIndex = 9;
            this.feedbackLabel2.Text = "to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Maximum rooms available for the period: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // AvailabilityCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.feedbackLabel2);
            this.Controls.Add(this.checkOutLabel);
            this.Controls.Add(this.checkInLabel);
            this.Controls.Add(this.updateBookingBtn);
            this.Controls.Add(this.newBookingBtn);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.summaryView);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.availabilityLabel);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "AvailabilityCheckForm";
            this.Text = "Availability Check";
            this.Load += new System.EventHandler(this.AvailabilityCheckForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label availabilityLabel;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.ListView summaryView;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Button newBookingBtn;
        private System.Windows.Forms.Button updateBookingBtn;
        private System.Windows.Forms.Label checkInLabel;
        private System.Windows.Forms.Label checkOutLabel;
        private System.Windows.Forms.Label feedbackLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}