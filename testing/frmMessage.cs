﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmMessage : Form
    {
        string id = "", Subject="", Message = "";
        public frmMessage(string id, string Subject, string Message)
        {
            InitializeComponent();

            this.id = id;
            this.Subject = Subject;
            this.Message = Message;
        }

        private void frmMessageTemplate_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Message;
        }
    }
}
