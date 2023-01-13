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
        private Bitmap bitmap;
        private Point? mouseHover = null;
        private int selected = -1;
        public ListControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            service = Service.GetInstance();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            vScrollBar1.Enabled = service.DataEntities.Count > 8;
            if (vScrollBar1.Enabled)
            {
                vScrollBar1.Maximum = (service.DataEntities.Count - 8);
            }

            boldfont = new Font(new FontFamily("Arial"), 10, FontStyle.Bold);
            nomalfont = new Font(new FontFamily("Arial"), 6);
        }
        public Image Draw()
        {
            int bitmapHeight = service.DataEntities.Count * 60;
            if (bitmapHeight < this.Height)
            {
                bitmapHeight = this.Height;
            }
            this.bitmap = new Bitmap(this.Width, bitmapHeight);
            Graphics g = Graphics.FromImage(this.bitmap);
            g.Clear(Color.White);
            int height = 0;
            int hover = CalcMouseHover();
            for (int i = 0; i < service.DataEntities.Count; i++)
            {
                var entity = service.DataEntities[i];
                if (i == selected)
                {
                    if (i == hover)
                    {
                        g.FillRectangle(Brushes.DarkSlateGray, 0, height, this.Width, 60);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.SlateGray, 0, height, this.Width, 60);
                    }
                }
                else if (i == hover)
                {
                    g.FillRectangle(Brushes.LightGray, 0, height, this.Width, 60);
                }
                height += 15;
                g.DrawString(entity.TitleView, boldfont, Brushes.Black, new Point(10, height));
                height += 30;
                g.DrawString(entity.CreateDate, nomalfont, Brushes.Black, new Point(100, height));
                height += 15;
                g.DrawLine(Pens.DarkGray, new Point(0, height), new Point(200, height));
            }
            return this.bitmap;
        }
        private float CalcScroll(float reverse = -1f)
        {
            return ((((float)bitmap.Height - this.Height) / ((float)vScrollBar1.Maximum - 9f)) * (float)vScrollBar1.Value) * reverse;
        }
        private int CalcMouseHover()
        {
            if (mouseHover != null)
            {
                return ((int)CalcScroll(1f) + mouseHover.Value.Y) / 60;
            }
            return -1;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int newSelected = ((int)CalcScroll(1f) + e.Location.Y) / 60;
            this.selected = newSelected < service.DataEntities.Count ? newSelected : this.selected;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            mouseHover = e.Location;
            base.OnMouseMove(e);
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            mouseHover = null;
            base.OnMouseLeave(e);
            this.Invalidate();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                if (vScrollBar1.Value > 0)
                {
                    vScrollBar1.Value--;
                }
            }
            else
            {
                if (vScrollBar1.Value < vScrollBar1.Maximum - 9)
                {
                    vScrollBar1.Value++;
                }
            }
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            g.Clear(Color.White);
            g.DrawImage(Draw(), new PointF(0, CalcScroll()));
            g.DrawRectangle(Pens.DarkGray, 0, 0, this.Width - 16, this.Height - 1);
            base.OnPaint(pe);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
