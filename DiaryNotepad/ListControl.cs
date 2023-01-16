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
            SetScroll();
            boldfont = new Font(new FontFamily("Arial"), 10, FontStyle.Bold);
            nomalfont = new Font(new FontFamily("Arial"), 6);
        }

        public Image Draw()
        {
            int bitmapHeight = service.GetDataEntitiesCount() * 60;
            if (bitmapHeight < this.Height)
            {
                bitmapHeight = this.Height;
            }
            this.bitmap = new Bitmap(this.Width, bitmapHeight);
            using (Graphics g = Graphics.FromImage(this.bitmap))
            {
                g.Clear(Color.White);
                int height = 0;
                int hover = CalcMouseHover();
                for (int i = 0; i < service.GetDataEntitiesCount(); i++)
                {
                    var entity = service.GetDataEntities(i);
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

                    if (i == hover && IsHoverXBox())
                    {
                        g.FillRectangle(Brushes.Red, this.Width - 30, height, 15, 15);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.DarkRed, this.Width - 30, height, 15, 15);
                    }
                    g.DrawString("X", boldfont, Brushes.White, this.Width - 30, height);
                    height += 15;
                    g.DrawString(entity.TitleView, boldfont, Brushes.Black, 10, height);
                    height += 30;
                    g.DrawString(entity.CreateDate, nomalfont, Brushes.Black, 100, height);
                    height += 15;
                    g.DrawLine(Pens.DarkGray, 0, height, 200, height);
                }
            }
            return this.bitmap;
        }

        private float CalcScroll(float reverse = -1f)
        {
            // 9를 빼는 거는 스크롤 최대 아래가 max의 9를 빼는 값
            // 버퍼 전체 길이(가장 밑은 공백이 아니고 길이 만큼 보이는 최대 높이가 된다.)를 스크롤 높이만큼 나눈다.
            // 그럼 1만다 어느 위치인지 알겠지.. 거기다 현재 스크롤 위치를 곱한다.
            // (Bitmap 높이(buffer) - 파넬 높이) / ((스크롤 높이 - 9) * 스크롤 위치) * -1
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

        private bool IsHoverXBox()
        {
            // TODO: 여기서부터 계산한다.
            return false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int newSelected = ((int)CalcScroll(1f) + e.Location.Y) / 60;
            this.selected = newSelected < service.GetDataEntitiesCount() ? newSelected : this.selected;
            if(IsHoverXBox())
            {

            }
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

        public new void Invalidate()
        {
            SetScroll();
            base.Invalidate();
        }

        private void SetScroll()
        {
            vScrollBar1.Enabled = service.GetDataEntitiesCount() > 8;
            if (vScrollBar1.Enabled)
            {
                vScrollBar1.Maximum = (service.GetDataEntitiesCount() - 8);
                if (vScrollBar1.Maximum < 30)
                {
                    vScrollBar1.Maximum = 30;
                }
            }
        }
    }
}
