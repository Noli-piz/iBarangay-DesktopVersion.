
namespace testing
{
    partial class frmTesting
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
            this.monthView1 = new WindowsFormsCalendar.MonthView();
            this.calendar1 = new WindowsFormsCalendar.Calendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthView1
            // 
            this.monthView1.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView1.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(13, 24);
            this.monthView1.Margin = new System.Windows.Forms.Padding(4);
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.SelectionMode = WindowsFormsCalendar.MonthViewSelection.Week;
            this.monthView1.Size = new System.Drawing.Size(425, 292);
            this.monthView1.TabIndex = 0;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView1.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            // 
            // calendar1
            // 
            this.calendar1.AllowDrop = true;
            this.calendar1.AllowItemEdit = false;
            this.calendar1.AllowItemResize = false;
            this.calendar1.AllowNew = false;
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar1.BackColor = System.Drawing.Color.LightGray;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar1.ItemsBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.calendar1.ItemsFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar1.ItemsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.calendar1.Location = new System.Drawing.Point(1, 4);
            this.calendar1.Margin = new System.Windows.Forms.Padding(4);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(928, 729);
            this.calendar1.TabIndex = 0;
            this.calendar1.Text = "calendar1";
            this.calendar1.LoadItems += new WindowsFormsCalendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.Click += new System.EventHandler(this.calendar1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.calendar1);
            this.panel1.Location = new System.Drawing.Point(445, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 737);
            this.panel1.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(49, 399);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(338, 95);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "New Appointment";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 773);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthView1);
            this.Name = "frmTesting";
            this.Text = "frmTesting";
            this.Load += new System.EventHandler(this.frmTesting_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private WindowsFormsCalendar.MonthView monthView1;
        private WindowsFormsCalendar.Calendar calendar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
    }
}