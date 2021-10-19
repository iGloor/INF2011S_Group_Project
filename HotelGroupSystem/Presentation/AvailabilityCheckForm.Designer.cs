
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
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(51, 69);
            this.monthCalendar1.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
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
            this.feedbackLabel.Location = new System.Drawing.Point(388, 43);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(66, 17);
            this.feedbackLabel.TabIndex = 2;
            this.feedbackLabel.Text = "feedback";
            // 
            // summaryView
            // 
            this.summaryView.HideSelection = false;
            this.summaryView.Location = new System.Drawing.Point(356, 79);
            this.summaryView.Name = "summaryView";
            this.summaryView.Size = new System.Drawing.Size(270, 207);
            this.summaryView.TabIndex = 3;
            this.summaryView.UseCompatibleStateImageBehavior = false;
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(94, 305);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(161, 40);
            this.checkBtn.TabIndex = 4;
            this.checkBtn.Text = "Check Availability";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // newBookingBtn
            // 
            this.newBookingBtn.Location = new System.Drawing.Point(356, 305);
            this.newBookingBtn.Name = "newBookingBtn";
            this.newBookingBtn.Size = new System.Drawing.Size(161, 40);
            this.newBookingBtn.TabIndex = 5;
            this.newBookingBtn.Text = "Create New Booking";
            this.newBookingBtn.UseVisualStyleBackColor = true;
            this.newBookingBtn.Click += new System.EventHandler(this.newBookingBtn_Click);
            // 
            // updateBookingBtn
            // 
            this.updateBookingBtn.Location = new System.Drawing.Point(541, 305);
            this.updateBookingBtn.Name = "updateBookingBtn";
            this.updateBookingBtn.Size = new System.Drawing.Size(161, 40);
            this.updateBookingBtn.TabIndex = 6;
            this.updateBookingBtn.Text = "Update Booking";
            this.updateBookingBtn.UseVisualStyleBackColor = true;
            this.updateBookingBtn.Click += new System.EventHandler(this.updateBookingBtn_Click);
            // 
            // AvailabilityCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateBookingBtn);
            this.Controls.Add(this.newBookingBtn);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.summaryView);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.availabilityLabel);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "AvailabilityCheckForm";
            this.Text = "Availability Check";
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
    }
}