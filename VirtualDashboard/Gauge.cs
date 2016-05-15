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
        private int FormWidth;
        private int FormHeight;
        private double Width;
        private String Label;
        private int Min;
        private int Max;
        private double PercentWidth;

        private double xPer;
        private double yPer;

        private int value = 0;

        private Point start;

        public Gauge(double xx, double yy, int modeCode,int formwidth,int formheight,double percentWidth,String label,int min, int max)
        {
            xPer = xx;
            yPer = yy;

            x = (int)(xx / 100 * formwidth);
            y = (int)(yy / 100 * formheight);
            FormHeight = formheight;
            ModeCode = modeCode;
            FormWidth = formwidth;
            Label = label;
            Min = min;
            Max = max;
            PercentWidth = percentWidth;
            Width = percentWidth / 100 * formwidth;
            start = new Point((int)(x + Width/2),(int) (y + Width/2));
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawArc(Pens.Black, new Rectangle(x, y, (int)Width,(int) Width), 0, -180);

            //center labels and values
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //draw the gauge
            e.Graphics.DrawString("" + value, new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.Black, new Rectangle(x,(int) (y - Width/4 + 10),(int) Width,(int) Width), sf);
            e.Graphics.DrawString(Label, new Font(FontFamily.GenericSansSerif, 15, FontStyle.Regular), Brushes.Black, new Rectangle(x, (int) (y + Width / 4 - 10), (int)Width,(int) Width), sf);
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

        public void setFormWidth(int width)
        {
            FormWidth = width;
            Width = PercentWidth / 100 * FormWidth;
            x = (int)(xPer / 100 * FormWidth);
            start = new Point((int)(x + Width / 2), (int)(y + Width / 2));
        }

        public void setFormHeight(int height)
        {
            FormHeight = height;
            y = (int)(yPer / 100 * FormHeight);
            start = new Point((int)(x + Width / 2), (int)(y + Width / 2));
        }

    }
}
