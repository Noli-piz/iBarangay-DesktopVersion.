
namespace testing
{
    partial class frmBlotterRec3Update
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
            this.data1 = new System.Windows.Forms.DataGridView();
            this.boxpanel = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.tbEnterName = new System.Windows.Forms.TextBox();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.tbSearch1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            this.SuspendLayout();
            // 
            // data1
            // 
            this.data1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.data1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data1.Location = new System.Drawing.Point(45, 144);
            this.data1.Name = "data1";
            this.data1.ReadOnly = true;
            this.data1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.data1.RowHeadersVisible = false;
            this.data1.RowHeadersWidth = 51;
            this.data1.RowTemplate.Height = 24;
            this.data1.Size = new System.Drawing.Size(731, 512);
            this.data1.TabIndex = 21;
            this.data1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnGenerate_CellClick);
            // 
            // boxpanel
            // 
            this.boxpanel.AutoScroll = true;
            this.boxpanel.BackColor = System.Drawing.Color.White;
            this.boxpanel.ColumnCount = 1;
            this.boxpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.boxpanel.Location = new System.Drawing.Point(797, 144);
            this.boxpanel.Margin = new System.Windows.Forms.Padding(1);
            this.boxpanel.Name = "boxpanel";
            this.boxpanel.RowCount = 1;
            this.boxpanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.boxpanel.Size = new System.Drawing.Size(413, 512);
            this.boxpanel.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(794, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Enter name for non-residents";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(794, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Assailant";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search name for residents";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(966, 673);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOkay.Location = new System.Drawing.Point(1086, 673);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(90, 36);
            this.btnOkay.TabIndex = 16;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(1118, 71);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(90, 36);
            this.btnEnter.TabIndex = 15;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // tbEnterName
            // 
            this.tbEnterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEnterName.Location = new System.Drawing.Point(797, 77);
            this.tbEnterName.Name = "tbEnterName";
            this.tbEnterName.Size = new System.Drawing.Size(315, 30);
            this.tbEnterName.TabIndex = 14;
            // 
            // btnSearch1
            // 
            this.btnSearch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch1.Location = new System.Drawing.Point(410, 71);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(90, 36);
            this.btnSearch1.TabIndex = 13;
            this.btnSearch1.Text = "Search";
            this.btnSearch1.UseVisualStyleBackColor = true;
            // 
            // tbSearch1
            // 
            this.tbSearch1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSearch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch1.Location = new System.Drawing.Point(45, 77);
            this.tbSearch1.Name = "tbSearch1";
            this.tbSearch1.Size = new System.Drawing.Size(348, 30);
            this.tbSearch1.TabIndex = 11;
            this.tbSearch1.TextChanged += new System.EventHandler(this.tbSearch1_TextChanged);
            // 
            // frmBlotterRec3Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 719);
            this.Controls.Add(this.data1);
            this.Controls.Add(this.boxpanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tbEnterName);
            this.Controls.Add(this.btnSearch1);
            this.Controls.Add(this.tbSearch1);
            this.Name = "frmBlotterRec3Update";
            this.Text = "frmBlotterRec3Update";
            this.Load += new System.EventHandler(this.frmBlotterRec3Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.TableLayoutPanel boxpanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox tbEnterName;
        private System.Windows.Forms.Button btnSearch1;
        private System.Windows.Forms.TextBox tbSearch1;
    }
}