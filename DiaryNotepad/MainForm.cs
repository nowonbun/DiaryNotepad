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
    public partial class MainForm : Form
    {
        private static MainForm instance = null;
        private NewEntityPopup popup;

        public static MainForm GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("Main Form instance is not allocation.");
            }
            return instance;
        }

        private Service service = null;
        private ListForm listForm = null;
        private MemoForm memoForm = null;
        private ImageListForm imageListForm = null;

        public MainForm()
        {
            InitializeComponent();
            MainForm.instance = this;
            service = Service.GetInstance();
            popup = new NewEntityPopup();
            popup.MdiParent = service.MainForm;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Form> forms = new List<Form>(3);
            forms.Add(listForm = new ListForm());
            forms.Add(memoForm = new MemoForm());
            forms.Add(imageListForm = new ImageListForm());
            forms.ForEach(x =>
            {
                x.MdiParent = this;
                x.Show();
            });
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                this.Close();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            popup.Show();
            popup.Focus();
        }
    }
}
