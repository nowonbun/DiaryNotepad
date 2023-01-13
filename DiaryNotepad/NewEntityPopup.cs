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
    public partial class NewEntityPopup : Form
    {
        private Service service = null;

        public NewEntityPopup()
        {
            InitializeComponent();
            service = Service.GetInstance();
        }
        public void Init()
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "undefined title";
            }
            service.DataEntities.Add(DataEntity.CreateEntity(textBox1.Text));
        }
    }
}
