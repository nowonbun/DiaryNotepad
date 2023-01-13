using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryNotepad
{
    [Serializable]
    class DataEntity
    {
        public static DataEntity CreateEntity(String title)
        {
            var entity = new DataEntity();
            entity.title = title;
            entity.SetCreateDate();
            return entity;
        }

        private String title;
        private DateTime? createdate;
        private DateTime? updatedate;

        private DataEntity()
        {

        }
        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                SetUpdateDate();
            }
        }
        public String TitleView
        {
            get
            {
                int i = 0;
                int count = 0;
                bool over = false;
                char[] c = title.ToArray();
                for (; i < c.Length; i++)
                {
                    if (c[i] >= 128)
                    {
                        count += 2;
                    }
                    else
                    {
                        count++;
                    }
                    if (count >= 18)
                    {
                        over = true;
                        break;
                    }
                }
                return title.Substring(0, i) + (over ? "..." : "");
            }
        }
        public String CreateDate
        {
            get;
            private set;
        }
        public String Updatedate
        {
            get;
            private set;
        }
        public int ByteLength
        {
            get
            {
                return ASCIIEncoding.UTF8.GetByteCount(title);
            }
        }
        public void SetCreateDate()
        {
            createdate = DateTime.Now;
            CreateDate = createdate?.ToString("yyyy/MM/dd HH:mm");
        }
        public void SetUpdateDate()
        {
            updatedate = DateTime.Now;
            Updatedate = updatedate?.ToString("yyyy/MM/dd HH:mm");
        }
    }
}
