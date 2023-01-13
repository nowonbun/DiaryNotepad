﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryNotepad
{
    public partial class ListForm : Form
    {
        private Service service = null;
        private NewEntityPopup popup;

        public ListForm()
        {
            InitializeComponent();
            service = Service.GetInstance();
            popup = new NewEntityPopup();
            popup.MdiParent = service.MainForm;
        }
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            popup.Show();
            popup.Focus();
        }
    }
}
