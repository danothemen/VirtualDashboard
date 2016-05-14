using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualDashboard
{
    public class Gauge
    {
        private int x = 0;
        private int y = 0;
        private int ModeCode;
        private int Width;
        private String Label;
        private int Min;
        private int Max;

        private int value = 0;

        private Point start;

        public Gauge(int xx, int yy, int modeCode,int width,String label,int min, int max)
        {
            x = xx;
            y = yy;
            ModeCode = modeCode;
            Width = width;
            Label = label;
            Min = min;
            Max = max;
            start = new Point(xx + Width/2, yy + Width/2);
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawArc(Pens.Black, new Rectangle(x, y, Width, Width), 0, -180);

            //center labels and values
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //draw the gauge
            e.Graphics.DrawString("" + value, new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.Black, new Rectangle(x, y - Width/4 + 10, Width, Width), sf);
            e.Graphics.DrawString(Label, new Font(FontFamily.GenericSansSerif, 15, FontStyle.Regular), Brushes.Black, new Rectangle(x, y + Width / 4 - 10, Width, Width), sf);
            e.Graphics.DrawLine(Pens.Black, start, calcPointFromValue(value));
        }

        public void setValue(int val)
        {
            value = val;
        }

        private Point calcPointFromValue(double value)
        {
            //calculate the end point of the line to draw based on the current value and the min and max of this gauge object
            double a = (value / Max) * 180;
            a += 180;
            double X = start.X + Width/2 * Math.Cos(a * Math.PI / 180F);
            double Y = start.Y + Width/2 * Math.Sin(a * Math.PI / 180F);
            return new Point((int)X,(int)Y);
        }

    }
}
