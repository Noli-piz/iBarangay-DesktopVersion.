
namespace testing
{
    partial class frmAppointment
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
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.dtTimeStart = new System.Windows.Forms.DateTimePicker();
            this.rbDetails = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.cbDone = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.data1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(899, 93);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(329, 30);
            this.tbTitle.TabIndex = 0;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(899, 166);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(329, 30);
            this.tbName.TabIndex = 1;
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Location = new System.Drawing.Point(899, 242);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(329, 30);
            this.dtDate.TabIndex = 2;
            // 
            // dtTimeStart
            // 
            this.dtTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTimeStart.Location = new System.Drawing.Point(899, 317);
            this.dtTimeStart.Name = "dtTimeStart";
            this.dtTimeStart.Size = new System.Drawing.Size(143, 30);
            this.dtTimeStart.TabIndex = 3;
            // 
            // rbDetails
            // 
            this.rbDetails.Location = new System.Drawing.Point(899, 401);
            this.rbDetails.Name = "rbDetails";
            this.rbDetails.Size = new System.Drawing.Size(338, 127);
            this.rbDetails.TabIndex = 5;
            this.rbDetails.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1133, 606);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 35);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtTimeEnd
            // 
            this.dtTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTimeEnd.Location = new System.Drawing.Point(1085, 317);
            this.dtTimeEnd.Name = "dtTimeEnd";
            this.dtTimeEnd.Size = new System.Drawing.Size(143, 30);
            this.dtTimeEnd.TabIndex = 7;
            // 
            // cbDone
            // 
            this.cbDone.AutoSize = true;
            this.cbDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDone.Location = new System.Drawing.Point(899, 543);
            this.cbDone.Name = "cbDone";
            this.cbDone.Size = new System.Drawing.Size(161, 29);
            this.cbDone.TabIndex = 8;
            this.cbDone.Text = "Mark as Done.";
            this.cbDone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(894, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(894, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(894, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(894, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1048, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(894, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Details:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 25);
            this.label16.TabIndex = 16;
            this.label16.Text = "Appointments:";
            // 
            // data1
            // 
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data1.Location = new System.Drawing.Point(12, 93);
            this.data1.Name = "data1";
            this.data1.RowHeadersVisible = false;
            this.data1.RowHeadersWidth = 51;
            this.data1.RowTemplate.Height = 24;
            this.data1.Size = new System.Drawing.Size(876, 587);
            this.data1.TabIndex = 17;
            this.data1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1012, 606);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 693);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.data1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDone);
            this.Controls.Add(this.dtTimeEnd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rbDetails);
            this.Controls.Add(this.dtTimeStart);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbTitle);
            this.Name = "frmAppointment";
            this.Text = "frmAppointment";
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DateTimePicker dtTimeStart;
        private System.Windows.Forms.RichTextBox rbDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtTimeEnd;
        private System.Windows.Forms.CheckBox cbDone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.Button button1;
    }
}