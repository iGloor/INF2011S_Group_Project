
namespace HotelGroupSystem.Presentation
{
    partial class BookingDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.refNoLabel = new System.Windows.Forms.Label();
            this.printBtn = new System.Windows.Forms.Button();
            this.faxRadBtn = new System.Windows.Forms.RadioButton();
            this.emailRadBtn = new System.Windows.Forms.RadioButton();
            this.postRadBtn = new System.Windows.Forms.RadioButton();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference number:";
            // 
            // refNoLabel
            // 
            this.refNoLabel.AutoSize = true;
            this.refNoLabel.Location = new System.Drawing.Point(232, 32);
            this.refNoLabel.Name = "refNoLabel";
            this.refNoLabel.Size = new System.Drawing.Size(46, 17);
            this.refNoLabel.TabIndex = 1;
            this.refNoLabel.Text = "label2";
            this.refNoLabel.Click += new System.EventHandler(this.refNoLabel_Click);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(34, 222);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(214, 36);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "Get Confirmation Letter";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // faxRadBtn
            // 
            this.faxRadBtn.AutoSize = true;
            this.faxRadBtn.Location = new System.Drawing.Point(34, 83);
            this.faxRadBtn.Name = "faxRadBtn";
            this.faxRadBtn.Size = new System.Drawing.Size(51, 21);
            this.faxRadBtn.TabIndex = 4;
            this.faxRadBtn.TabStop = true;
            this.faxRadBtn.Text = "Fax";
            this.faxRadBtn.UseVisualStyleBackColor = true;
            // 
            // emailRadBtn
            // 
            this.emailRadBtn.AutoSize = true;
            this.emailRadBtn.Location = new System.Drawing.Point(34, 122);
            this.emailRadBtn.Name = "emailRadBtn";
            this.emailRadBtn.Size = new System.Drawing.Size(63, 21);
            this.emailRadBtn.TabIndex = 5;
            this.emailRadBtn.TabStop = true;
            this.emailRadBtn.Text = "Email";
            this.emailRadBtn.UseVisualStyleBackColor = true;
            // 
            // postRadBtn
            // 
            this.postRadBtn.AutoSize = true;
            this.postRadBtn.Location = new System.Drawing.Point(34, 163);
            this.postRadBtn.Name = "postRadBtn";
            this.postRadBtn.Size = new System.Drawing.Size(57, 21);
            this.postRadBtn.TabIndex = 6;
            this.postRadBtn.TabStop = true;
            this.postRadBtn.Text = "Post";
            this.postRadBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(320, 222);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(127, 36);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // BookingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 366);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.postRadBtn);
            this.Controls.Add(this.emailRadBtn);
            this.Controls.Add(this.faxRadBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.refNoLabel);
            this.Controls.Add(this.label1);
            this.Name = "BookingDetails";
            this.Text = "Booking Details";
            this.Activated += new System.EventHandler(this.BookingDetails_Activated);
            this.Load += new System.EventHandler(this.BookingDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label refNoLabel;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.RadioButton faxRadBtn;
        private System.Windows.Forms.RadioButton emailRadBtn;
        private System.Windows.Forms.RadioButton postRadBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}