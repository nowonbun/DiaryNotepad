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
            // DEBUG
            dataEntities = new List<DataEntity>();
            for (int i = 0; i < 100; i++)
            {
                dataEntities.Add(DataEntity.CreateEntity("test" + i));
            }
        }

        public void SetStripMessage(String msg)
        {
            MainWindow.Controls["statusStrip"].InvokeControl((obj) =>
            {
                StatusStrip strip = obj as StatusStrip;
                strip.Items["toolStripStatusLabel"].Text = msg;
            });
        }
        public ListForm GetListForm()
        {
            return MainWindow.Controls["ListForm"] as ListForm;
        }
        public MemoForm GetMemoForm()
        {
            return MainWindow.Controls["MemoForm"] as MemoForm;
        }
        public ImageListForm GetImageListForm()
        {
            return MainWindow.Controls["ImageListForm"] as ImageListForm;
        }
        public List<DataEntity> GetDataEntities()
        {
            return this.dataEntities;
        }
    }
}
