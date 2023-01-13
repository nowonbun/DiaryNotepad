using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryNotepad
{
    class Service
    {
        private static Service singleton = null;
        public static Service GetInstance()
        {
            if (singleton == null)
            {
                singleton = new Service();
            }
            return singleton;
        }
        private MainForm MainWindow
        {
            get
            {
                return MainForm.GetInstance();
            }
        }

        private List<DataEntity> dataEntities = null;

        private Service()
        {
            dataEntities = new List<DataEntity>();
            //dataEntities.Add(DataEntity.CreateEntity("test"));
            // DEBUG
            /*for (int i = 0; i < 100; i++)
            {
                dataEntities.Add(DataEntity.CreateEntity("test" + i));
            }*/
        }

        public void SetStripMessage(String msg)
        {
            MainWindow.Controls["statusStrip"].InvokeControl((obj) =>
            {
                StatusStrip strip = obj as StatusStrip;
                strip.Items["toolStripStatusLabel"].Text = msg;
            });
        }
        public MainForm MainForm
        {
            get
            {
                return MainWindow;
            }
        }
        public ListForm istForm
        {
            get
            {
                return MainWindow.Controls["ListForm"] as ListForm;
            }
        }
        public MemoForm MemoForm
        {
            get
            {
                return MainWindow.Controls["MemoForm"] as MemoForm;
            }
        }
        public ImageListForm ImageListForm
        {
            get
            {
                return MainWindow.Controls["ImageListForm"] as ImageListForm;
            }
        }
        public List<DataEntity> DataEntities
        {
            get
            {
                return this.dataEntities;
            }
        }
    }
}
