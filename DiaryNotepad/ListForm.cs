using System;
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

        public ListForm()
        {
            InitializeComponent();
            service = Service.GetInstance();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public new void Invalidate()
        {
            base.Invalidate();
            this.listControl1.Invalidate();
        }
    }
}
