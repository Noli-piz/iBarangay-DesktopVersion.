
namespace testing
{
    partial class frmBlotterRec2Insert
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
            this.rbDetails = new System.Windows.Forms.RichTextBox();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRespondent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbComplainant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAssailant = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbWitness = new System.Windows.Forms.TextBox();
            this.data1 = new System.Windows.Forms.DataGridView();
            this.tbLocation = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSubmit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbDetails
            // 
            this.rbDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDetails.Location = new System.Drawing.Point(56, 495);
            this.rbDetails.Name = "rbDetails";
            this.rbDetails.Size = new System.Drawing.Size(831, 186);
            this.rbDetails.TabIndex = 39;
            this.rbDetails.Text = "";
            // 
            // dtTime
            // 
            this.dtTime.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTime.Location = new System.Drawing.Point(727, 274);
            this.dtTime.Name = "dtTime";
            this.dtTime.ShowUpDown = true;
            this.dtTime.Size = new System.Drawing.Size(160, 34);
            this.dtTime.TabIndex = 38;
            this.dtTime.Value = new System.DateTime(2021, 8, 11, 16, 36, 0, 0);
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.CustomFormat = "MMM dd, yyyy";
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(506, 274);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(192, 34);
            this.dtDate.TabIndex = 37;
            this.dtDate.Value = new System.DateTime(2021, 8, 12, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(56, 472);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Details:";
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(506, 202);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(381, 36);
            this.cbType.TabIndex = 35;
            // 
            // cbStatus
            // 
            this.cbStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(56, 408);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(358, 36);
            this.cbStatus.TabIndex = 34;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(723, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(502, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(502, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Type:";
            // 
            // tbRespondent
            // 
            this.tbRespondent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRespondent.Location = new System.Drawing.Point(506, 66);
            this.tbRespondent.Name = "tbRespondent";
            this.tbRespondent.Size = new System.Drawing.Size(381, 34);
            this.tbRespondent.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(502, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Respondent:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(502, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Assailant:";
            // 
            // tbComplainant
            // 
            this.tbComplainant.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComplainant.Location = new System.Drawing.Point(56, 66);
            this.tbComplainant.Name = "tbComplainant";
            this.tbComplainant.Size = new System.Drawing.Size(358, 34);
            this.tbComplainant.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Complainant:";
            // 
            // btnAddAssailant
            // 
            this.btnAddAssailant.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAssailant.Location = new System.Drawing.Point(60, 139);
            this.btnAddAssailant.Name = "btnAddAssailant";
            this.btnAddAssailant.Size = new System.Drawing.Size(168, 34);
            this.btnAddAssailant.TabIndex = 40;
            this.btnAddAssailant.Text = "Add Assailant";
            this.btnAddAssailant.UseVisualStyleBackColor = true;
            this.btnAddAssailant.Click += new System.EventHandler(this.btnAddAssailant_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(502, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 41;
            this.label10.Text = "Witness";
            // 
            // tbWitness
            // 
            this.tbWitness.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWitness.Location = new System.Drawing.Point(506, 137);
            this.tbWitness.Name = "tbWitness";
            this.tbWitness.Size = new System.Drawing.Size(381, 34);
            this.tbWitness.TabIndex = 42;
            // 
            // data1
            // 
            this.data1.AllowUserToAddRows = false;
            this.data1.AllowUserToDeleteRows = false;
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data1.Location = new System.Drawing.Point(60, 179);
            this.data1.MultiSelect = false;
            this.data1.Name = "data1";
            this.data1.ReadOnly = true;
            this.data1.RowHeadersVisible = false;
            this.data1.RowHeadersWidth = 51;
            this.data1.RowTemplate.Height = 24;
            this.data1.Size = new System.Drawing.Size(361, 200);
            this.data1.TabIndex = 43;
            // 
            // tbLocation
            // 
            this.tbLocation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocation.Location = new System.Drawing.Point(505, 344);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(382, 100);
            this.tbLocation.TabIndex = 44;
            this.tbLocation.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(560, 702);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnCancel.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.OverrideDefault.Back.ColorAngle = 0F;
            this.btnCancel.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnCancel.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnCancel.OverrideDefault.Border.ColorAngle = 145F;
            this.btnCancel.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCancel.OverrideDefault.Border.Rounding = 25;
            this.btnCancel.OverrideDefault.Border.Width = 1;
            this.btnCancel.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.Gray;
            this.btnCancel.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.Gray;
            this.btnCancel.OverrideDefault.Content.ShortText.ColorAngle = 145F;
            this.btnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnCancel.Size = new System.Drawing.Size(153, 50);
            this.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.btnCancel.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.btnCancel.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.btnCancel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCancel.StateCommon.Border.Rounding = 25;
            this.btnCancel.StateCommon.Border.Width = 1;
            this.btnCancel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Gray;
            this.btnCancel.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Gray;
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.StatePressed.Back.ColorAngle = 135F;
            this.btnCancel.StatePressed.Border.Color1 = System.Drawing.Color.Red;
            this.btnCancel.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.btnCancel.StatePressed.Border.ColorAngle = 135F;
            this.btnCancel.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StatePressed.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCancel.StatePressed.Border.Rounding = 25;
            this.btnCancel.StatePressed.Border.Width = 1;
            this.btnCancel.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Red;
            this.btnCancel.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Red;
            this.btnCancel.StateTracking.Back.ColorAngle = 45F;
            this.btnCancel.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnCancel.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnCancel.StateTracking.Border.ColorAngle = 45F;
            this.btnCancel.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCancel.StateTracking.Border.Rounding = 25;
            this.btnCancel.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnCancel.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(734, 702);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.OverrideDefault.Back.Color1 = System.Drawing.Color.Blue;
            this.btnSubmit.OverrideDefault.Back.Color2 = System.Drawing.Color.Blue;
            this.btnSubmit.OverrideDefault.Back.ColorAngle = 0F;
            this.btnSubmit.OverrideDefault.Border.Color1 = System.Drawing.Color.Blue;
            this.btnSubmit.OverrideDefault.Border.ColorAngle = 0F;
            this.btnSubmit.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubmit.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSubmit.OverrideDefault.Border.Rounding = 25;
            this.btnSubmit.OverrideDefault.Border.Width = 1;
            this.btnSubmit.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSubmit.OverrideDefault.Content.ShortText.ColorAngle = 145F;
            this.btnSubmit.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.OverrideDefault.Content.ShortText.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias;
            this.btnSubmit.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSubmit.Size = new System.Drawing.Size(153, 50);
            this.btnSubmit.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.btnSubmit.StateCommon.Back.Color2 = System.Drawing.Color.Blue;
            this.btnSubmit.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.btnSubmit.StateCommon.Border.Color1 = System.Drawing.Color.Blue;
            this.btnSubmit.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubmit.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSubmit.StateCommon.Border.Rounding = 25;
            this.btnSubmit.StateCommon.Border.Width = 1;
            this.btnSubmit.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSubmit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.StateCommon.Content.ShortText.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias;
            this.btnSubmit.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnSubmit.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnSubmit.StatePressed.Back.ColorAngle = 135F;
            this.btnSubmit.StatePressed.Border.ColorAngle = 135F;
            this.btnSubmit.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubmit.StatePressed.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSubmit.StatePressed.Border.Rounding = 25;
            this.btnSubmit.StatePressed.Border.Width = 1;
            this.btnSubmit.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Blue;
            this.btnSubmit.StatePressed.Content.ShortText.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias;
            this.btnSubmit.StateTracking.Back.ColorAngle = 45F;
            this.btnSubmit.StateTracking.Border.ColorAngle = 45F;
            this.btnSubmit.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubmit.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSubmit.StateTracking.Border.Rounding = 25;
            this.btnSubmit.StateTracking.Border.Width = 1;
            this.btnSubmit.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSubmit.StateTracking.Content.ShortText.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias;
            this.btnSubmit.TabIndex = 69;
            this.btnSubmit.Values.Text = "ADD";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmBlotterRec2Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 776);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.data1);
            this.Controls.Add(this.tbWitness);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAddAssailant);
            this.Controls.Add(this.rbDetails);
            this.Controls.Add(this.dtTime);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRespondent);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.tbComplainant);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBlotterRec2Insert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Blotter";
            this.Load += new System.EventHandler(this.frmAddNewBlotter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rbDetails;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRespondent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbComplainant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAssailant;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbWitness;
        private System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.RichTextBox tbLocation;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSubmit;
    }
}