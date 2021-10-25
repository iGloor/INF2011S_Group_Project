
namespace HotelGroupSystem.Presentation
{
    partial class HomeForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.availabilityCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeAnEnquiryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.occupancyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seasonalSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.availabilityCheckToolStripMenuItem,
            this.bookingsToolStripMenuItem,
            this.generateReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // availabilityCheckToolStripMenuItem
            // 
            this.availabilityCheckToolStripMenuItem.Name = "availabilityCheckToolStripMenuItem";
            this.availabilityCheckToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.availabilityCheckToolStripMenuItem.Text = "Availability Check";
            this.availabilityCheckToolStripMenuItem.Click += new System.EventHandler(this.availabilityCheckToolStripMenuItem_Click);
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBookingToolStripMenuItem,
            this.updateBookingToolStripMenuItem,
            this.makeAnEnquiryToolStripMenuItem});
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            // 
            // newBookingToolStripMenuItem
            // 
            this.newBookingToolStripMenuItem.Name = "newBookingToolStripMenuItem";
            this.newBookingToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.newBookingToolStripMenuItem.Text = "New Booking";
            this.newBookingToolStripMenuItem.Click += new System.EventHandler(this.newBookingToolStripMenuItem_Click);
            // 
            // updateBookingToolStripMenuItem
            // 
            this.updateBookingToolStripMenuItem.Name = "updateBookingToolStripMenuItem";
            this.updateBookingToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.updateBookingToolStripMenuItem.Text = "Update Booking";
            this.updateBookingToolStripMenuItem.Click += new System.EventHandler(this.updateBookingToolStripMenuItem_Click);
            // 
            // makeAnEnquiryToolStripMenuItem
            // 
            this.makeAnEnquiryToolStripMenuItem.Name = "makeAnEnquiryToolStripMenuItem";
            this.makeAnEnquiryToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.makeAnEnquiryToolStripMenuItem.Text = "Make an Enquiry";
            this.makeAnEnquiryToolStripMenuItem.Click += new System.EventHandler(this.makeAnEnquiryToolStripMenuItem_Click);
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.occupancyReportToolStripMenuItem,
            this.seasonalSummaryReportToolStripMenuItem});
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.generateReportToolStripMenuItem.Text = "Generate Report";
            // 
            // occupancyReportToolStripMenuItem
            // 
            this.occupancyReportToolStripMenuItem.Name = "occupancyReportToolStripMenuItem";
            this.occupancyReportToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.occupancyReportToolStripMenuItem.Text = "Occupancy Report";
            this.occupancyReportToolStripMenuItem.Click += new System.EventHandler(this.occupancyReportToolStripMenuItem_Click);
            // 
            // seasonalSummaryReportToolStripMenuItem
            // 
            this.seasonalSummaryReportToolStripMenuItem.Name = "seasonalSummaryReportToolStripMenuItem";
            this.seasonalSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.seasonalSummaryReportToolStripMenuItem.Text = "Seasonal Summary Report";
            this.seasonalSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.seasonalSummaryReportToolStripMenuItem_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(62, 109);
            this.monthCalendar1.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.monthCalendar1.MaxSelectionCount = 31;
            this.monthCalendar1.MinDate = new System.DateTime(2021, 12, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select dates for occupancy report:";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HomeForm";
            this.Text = "Phumla Kumnandi Hotel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem availabilityCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem occupancyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeAnEnquiryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seasonalSummaryReportToolStripMenuItem;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
    }
}