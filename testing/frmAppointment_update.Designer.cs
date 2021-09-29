
namespace testing
{
    partial class frmAppointment_update
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDone = new System.Windows.Forms.CheckBox();
            this.dtTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.rbDetails = new System.Windows.Forms.RichTextBox();
            this.dtTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(164, 580);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 35);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 32;
            this.label6.Text = "Details:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(200, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Title:";
            // 
            // cbDone
            // 
            this.cbDone.AutoSize = true;
            this.cbDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDone.Location = new System.Drawing.Point(51, 517);
            this.cbDone.Name = "cbDone";
            this.cbDone.Size = new System.Drawing.Size(161, 29);
            this.cbDone.TabIndex = 26;
            this.cbDone.Text = "Mark as Done.";
            this.cbDone.UseVisualStyleBackColor = true;
            // 
            // dtTimeEnd
            // 
            this.dtTimeEnd.CustomFormat = "hh:mm tt";
            this.dtTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeEnd.Location = new System.Drawing.Point(237, 291);
            this.dtTimeEnd.Name = "dtTimeEnd";
            this.dtTimeEnd.ShowUpDown = true;
            this.dtTimeEnd.Size = new System.Drawing.Size(143, 30);
            this.dtTimeEnd.TabIndex = 25;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(285, 580);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 35);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rbDetails
            // 
            this.rbDetails.Location = new System.Drawing.Point(51, 375);
            this.rbDetails.Name = "rbDetails";
            this.rbDetails.Size = new System.Drawing.Size(338, 127);
            this.rbDetails.TabIndex = 23;
            this.rbDetails.Text = "";
            // 
            // dtTimeStart
            // 
            this.dtTimeStart.CustomFormat = "hh:mm tt";
            this.dtTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeStart.Location = new System.Drawing.Point(51, 291);
            this.dtTimeStart.Name = "dtTimeStart";
            this.dtTimeStart.ShowUpDown = true;
            this.dtTimeStart.Size = new System.Drawing.Size(143, 30);
            this.dtTimeStart.TabIndex = 22;
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(51, 216);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(329, 30);
            this.dtDate.TabIndex = 21;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(51, 140);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(329, 30);
            this.tbName.TabIndex = 20;
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(51, 67);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(329, 30);
            this.tbTitle.TabIndex = 19;
            // 
            // frmAppointment_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 665);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDone);
            this.Controls.Add(this.dtTimeEnd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.rbDetails);
            this.Controls.Add(this.dtTimeStart);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbTitle);
            this.Name = "frmAppointment_update";
            this.Text = "frmAppointment_update";
            this.Load += new System.EventHandler(this.frmAppointment_update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDone;
        private System.Windows.Forms.DateTimePicker dtTimeEnd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RichTextBox rbDetails;
        private System.Windows.Forms.DateTimePicker dtTimeStart;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbTitle;
    }
}