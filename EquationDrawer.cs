using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class EquationDrawer : Control
    {
        public EquationDrawer()
        {
        }
        Func<double, double> func;
        public void Draw(Func<double, double> func)
        {
            this.func = func;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            double h2 = Height / 2.0;
            double w2 = Width / 2.0;
            e.Graphics.DrawLine(Pens.Black, new Point((int)w2, 0), new Point((int)w2, Height));
            e.Graphics.DrawLine(Pens.Black, new Point(0, (int)h2), new Point(Width, (int)h2));

            if (func == null)
                return;

            int density = 100;
            int limit = 50;
            double step = limit * 2 / density;
            double ratio = w2 / limit;
            for (int i = -density/2; i < density/2; i++)
            {
                double x = i * step * ratio + w2;
                double y = h2 - func(i * step) * ratio;
                double x1 = (i + 1) * step * ratio + w2;
                double y1 = h2 - func((i + 1) * step) * ratio;
                if ((y > Height && y1 > Height) || (y < 0 && y1 < 0))
                    continue;
                e.Graphics.DrawLine(Pens.Black, (int)x, (int)y, (int)x1, (int)y1);
            }
        }
    }
}
