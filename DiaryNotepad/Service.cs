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
        private ListForm listForm = null;
        private MemoForm memoForm = null;
        private ImageListForm imageListForm = null;

        private Service()
        {
            dataEntities = new List<DataEntity>();
            //dataEntities.Add(DataEntity.CreateEntity("test"));
            // DEBUG
            /*for (int i = 0; i < 15; i++)
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

        public ListForm ListForm
        {
            get
            {
                if (listForm == null)
                {
                    listForm = MainWindow.MdiChildren.Where(x => "ListForm".Equals(x.Name)).First() as ListForm;
                }
                return listForm;
            }
        }

        public MemoForm MemoForm
        {
            get
            {
                if (memoForm == null)
                {
                    memoForm = MainWindow.MdiChildren.Where(x => "MemoForm".Equals(x.Name)).First() as MemoForm;
                }
                return memoForm;
            }
        }

        public ImageListForm ImageListForm
        {
            get
            {
                if (imageListForm == null)
                {
                    imageListForm = MainWindow.MdiChildren.Where(x => "ImageListForm".Equals(x.Name)).First() as ImageListForm;
                }
                return imageListForm;
            }
        }

        public void AddDataEntities(DataEntity entity)
        {
            this.dataEntities.Insert(0, entity);
        }

        public DataEntity GetDataEntities(int index)
        {
            return this.dataEntities[index];
        }

        public int GetDataEntitiesCount()
        {
            return this.dataEntities.Count;
        }

        public void Refresh()
        {
            ListForm.Invalidate();
        }
    }
}
