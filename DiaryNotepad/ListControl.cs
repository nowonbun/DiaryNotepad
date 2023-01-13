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
    public partial class ListControl : UserControl
    {
        private Service service = null;
        private Font boldfont = null;
        private Font nomalfont = null;
        private Rectangle background;
        private Bitmap bitmap;
        private Timer timer = null;


        public ListControl()
        {
            InitializeComponent();
            service = Service.GetInstance();
            vScrollBar1.Maximum = service.GetDataEntities().Count - 8 + 9;
            vScrollBar1.Enabled = service.GetDataEntities().Count > 8;

            boldfont = new Font(new FontFamily("Arial"), 10, FontStyle.Bold);
            nomalfont = new Font(new FontFamily("Arial"), 6);
            background = new Rectangle(0, 0, this.Width + 20, this.Height);

            Draw();
        }
        public void Draw()
        {
            this.bitmap = new Bitmap(this.Width + 20, service.GetDataEntities().Count * 60 + 1);
            Graphics g = Graphics.FromImage(this.bitmap);
            g.Clear(Color.White);
            int height = 0;
            g.DrawLine(Pens.DarkGray, new Point(0, 0), new Point(200, 0));
            service.GetDataEntities().ForEach(x =>
            {
                height += 20;
                g.DrawString(x.TitleView, boldfont, Brushes.Black, new Point(10, height));
                height += 25;
                g.DrawString(x.CreateDate, nomalfont, Brushes.Black, new Point(100, height));
                height += 15;
                g.DrawLine(Pens.DarkGray, new Point(0, height), new Point(200, height));
            });
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            g.Clear(Color.White);
            float height = (float)vScrollBar1.Value * -60f;
            g.DrawImage(bitmap, new PointF(0, height));
            base.OnPaint(pe);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            Console.WriteLine();
            base.OnClick(e);
        }
    }
}
