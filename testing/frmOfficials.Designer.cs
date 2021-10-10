
namespace testing
{
    partial class frmOfficials
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
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            this.SuspendLayout();
            // 
            // data1
            // 
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data1.Location = new System.Drawing.Point(12, 154);
            this.data1.Name = "data1";
            this.data1.RowHeadersWidth = 51;
            this.data1.RowTemplate.Height = 24;
            this.data1.Size = new System.Drawing.Size(1093, 434);
            this.data1.TabIndex = 0;
            this.data1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data1_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(950, 67);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Official";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOfficials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 616);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.data1);
            this.Name = "frmOfficials";
            this.Text = "frmOfiicials";
            this.Load += new System.EventHandler(this.frmOfficials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.Button btnAdd;
    }
}