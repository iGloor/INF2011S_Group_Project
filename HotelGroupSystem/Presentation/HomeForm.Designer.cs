
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
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.availableSummary = new System.Windows.Forms.ListView();
            this.checkBtn = new System.Windows.Forms.Button();
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
            this.updateBookingToolStripMenuItem});
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            // 
            // newBookingToolStripMenuItem
            // 
            this.newBookingToolStripMenuItem.Name = "newBookingToolStripMenuItem";
            this.newBookingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newBookingToolStripMenuItem.Text = "New Booking";
            this.newBookingToolStripMenuItem.Click += new System.EventHandler(this.newBookingToolStripMenuItem_Click);
            // 
            // updateBookingToolStripMenuItem
            // 
            this.updateBookingToolStripMenuItem.Name = "updateBookingToolStripMenuItem";
            this.updateBookingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.updateBookingToolStripMenuItem.Text = "Update Booking";
            this.updateBookingToolStripMenuItem.Click += new System.EventHandler(this.updateBookingToolStripMenuItem_Click);
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.generateReportToolStripMenuItem.Text = "Generate Report";
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.Location = new System.Drawing.Point(255, 67);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(158, 17);
            this.checkLabel.TabIndex = 1;
            this.checkLabel.Text = "Check Room Availability";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(45, 120);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(251, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // availableSummary
            // 
            this.availableSummary.HideSelection = false;
            this.availableSummary.Location = new System.Drawing.Point(380, 120);
            this.availableSummary.Name = "availableSummary";
            this.availableSummary.Size = new System.Drawing.Size(232, 145);
            this.availableSummary.TabIndex = 3;
            this.availableSummary.UseCompatibleStateImageBehavior = false;
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(144, 306);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(152, 36);
            this.checkBtn.TabIndex = 4;
            this.checkBtn.Text = "Check Availability";
            this.checkBtn.UseVisualStyleBackColor = true;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.availableSummary);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.Label checkLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView availableSummary;
        private System.Windows.Forms.Button checkBtn;
    }
}