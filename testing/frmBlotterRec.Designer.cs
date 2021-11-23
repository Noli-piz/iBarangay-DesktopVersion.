
namespace testing
{
    partial class frmBlotterRec
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.data1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnActive = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.lblActiveCases = new System.Windows.Forms.Label();
            this.lblSettledCases = new System.Windows.Forms.Label();
            this.lblScheduledCases = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(505, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 37);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(624, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 37);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1076, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Add new Blotter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn_AddBlotter_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(12, 49);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(329, 34);
            this.tbSearch.TabIndex = 1;
            // 
            // data1
            // 
            this.data1.AllowUserToAddRows = false;
            this.data1.AllowUserToDeleteRows = false;
            this.data1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.data1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.data1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.data1.BackgroundColor = System.Drawing.Color.White;
            this.data1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data1.DefaultCellStyle = dataGridViewCellStyle7;
            this.data1.EnableHeadersVisualStyles = false;
            this.data1.Location = new System.Drawing.Point(22, 147);
            this.data1.Name = "data1";
            this.data1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.data1.RowHeadersVisible = false;
            this.data1.RowHeadersWidth = 51;
            this.data1.RowTemplate.Height = 24;
            this.data1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data1.Size = new System.Drawing.Size(1032, 653);
            this.data1.TabIndex = 4;
            this.data1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnGenerate_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1076, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 145);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(1076, 358);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 145);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(1076, 569);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(190, 145);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // btnActive
            // 
            this.btnActive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActive.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActive.Location = new System.Drawing.Point(1076, 298);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(190, 31);
            this.btnActive.TabIndex = 8;
            this.btnActive.Text = "Active Cases";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1076, 509);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(190, 31);
            this.button5.TabIndex = 9;
            this.button5.Text = "Settled Cases";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(1076, 720);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(190, 31);
            this.button6.TabIndex = 10;
            this.button6.Text = "Scheduled Cases";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // lblActiveCases
            // 
            this.lblActiveCases.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblActiveCases.AutoSize = true;
            this.lblActiveCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveCases.Location = new System.Drawing.Point(1088, 235);
            this.lblActiveCases.Name = "lblActiveCases";
            this.lblActiveCases.Size = new System.Drawing.Size(41, 44);
            this.lblActiveCases.TabIndex = 11;
            this.lblActiveCases.Text = "0";
            // 
            // lblSettledCases
            // 
            this.lblSettledCases.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSettledCases.AutoSize = true;
            this.lblSettledCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettledCases.Location = new System.Drawing.Point(1088, 449);
            this.lblSettledCases.Name = "lblSettledCases";
            this.lblSettledCases.Size = new System.Drawing.Size(41, 44);
            this.lblSettledCases.TabIndex = 12;
            this.lblSettledCases.Text = "0";
            // 
            // lblScheduledCases
            // 
            this.lblScheduledCases.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblScheduledCases.AutoSize = true;
            this.lblScheduledCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduledCases.Location = new System.Drawing.Point(1088, 658);
            this.lblScheduledCases.Name = "lblScheduledCases";
            this.lblScheduledCases.Size = new System.Drawing.Size(41, 44);
            this.lblScheduledCases.TabIndex = 13;
            this.lblScheduledCases.Text = "0";
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "ID",
            "Compliant",
            "Assailant(resident)",
            "Assailant(non-resident)"});
            this.cbCategory.Location = new System.Drawing.Point(347, 50);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(152, 33);
            this.cbCategory.TabIndex = 14;
            // 
            // frmBlotterRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1285, 804);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.lblScheduledCases);
            this.Controls.Add(this.lblSettledCases);
            this.Controls.Add(this.lblActiveCases);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.data1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBlotterRec";
            this.Text = "frmBlotterRec";
            this.Load += new System.EventHandler(this.frmBlotterRec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblActiveCases;
        private System.Windows.Forms.Label lblSettledCases;
        private System.Windows.Forms.Label lblScheduledCases;
        private System.Windows.Forms.ComboBox cbCategory;
    }
}