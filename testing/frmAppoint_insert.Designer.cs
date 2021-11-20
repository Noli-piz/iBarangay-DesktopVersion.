
namespace testing
{
    partial class frmAppoint_insert
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
            this.dtStartDate = new MetroFramework.Controls.MetroDateTime();
            this.dtEndDate = new MetroFramework.Controls.MetroDateTime();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDone = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rbDetails = new System.Windows.Forms.RichTextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "MMMM dd, yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(191, 179);
            this.dtStartDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(196, 30);
            this.dtStartDate.TabIndex = 0;
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "MMMM dd, yyyy";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(191, 228);
            this.dtEndDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(196, 30);
            this.dtEndDate.TabIndex = 1;
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "hh:mm tt";
            this.dtStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(425, 179);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(167, 30);
            this.dtStartTime.TabIndex = 4;
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "hh:mm tt";
            this.dtEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(425, 228);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.ShowUpDown = true;
            this.dtEndTime.Size = new System.Drawing.Size(167, 30);
            this.dtEndTime.TabIndex = 5;
            this.dtEndTime.Value = new System.DateTime(2021, 11, 20, 15, 44, 0, 0);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(542, 638);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 35);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(236, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 28);
            this.label6.TabIndex = 26;
            this.label6.Text = "Details:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 28);
            this.label2.TabIndex = 25;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 28);
            this.label1.TabIndex = 24;
            this.label1.Text = "Title:";
            // 
            // cbDone
            // 
            this.cbDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDone.AutoSize = true;
            this.cbDone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDone.Location = new System.Drawing.Point(271, 599);
            this.cbDone.Name = "cbDone";
            this.cbDone.Size = new System.Drawing.Size(158, 32);
            this.cbDone.TabIndex = 23;
            this.cbDone.Text = "Mark as Done.";
            this.cbDone.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(675, 638);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 35);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rbDetails
            // 
            this.rbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDetails.Location = new System.Drawing.Point(241, 308);
            this.rbDetails.Name = "rbDetails";
            this.rbDetails.Size = new System.Drawing.Size(329, 277);
            this.rbDetails.TabIndex = 21;
            this.rbDetails.Text = "";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(241, 114);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(329, 34);
            this.tbName.TabIndex = 20;
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(241, 41);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(329, 34);
            this.tbTitle.TabIndex = 19;
            // 
            // frmAppoint_insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 711);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDone);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rbDetails);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.dtEndTime);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Name = "frmAppoint_insert";
            this.Text = "frmAppoint_insert";
            this.Load += new System.EventHandler(this.frmAppoint_insert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dtStartDate;
        private MetroFramework.Controls.MetroDateTime dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDone;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox rbDetails;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbTitle;
    }
}