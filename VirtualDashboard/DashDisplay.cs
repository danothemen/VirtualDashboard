using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualDashboard
{
    class DashDisplay : Form
    {

        public DashDisplay(){
            this.DoubleBuffered = true;
            this.ShowInTaskbar = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Purple;

            foreach (Gauge gag in Form1.DashElements)
            {
                if (gag != null)
                {
                    gag.setFormWidth(this.Width);
                    gag.setFormHeight(this.Height);
                }
            }
            Console.WriteLine("Set Dimens");

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(Pens.Black, 0, 0, 200, 200);
            foreach(Gauge gag in Form1.DashElements)
            {
                if(gag != null)
                {
                    gag.Draw(e);
                    gag.setFormWidth(this.Width);
                    gag.setFormHeight(this.Height);
                }
            }

            this.Invalidate(); //cause repaint
        }

    }
}
