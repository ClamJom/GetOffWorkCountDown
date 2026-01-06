using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountDown
{
    public static class FormHelper
    {
        public static void EnableDrag(this Control control)
        {
            bool dragging = false;
            Point dragStartPoint = Point.Empty;
            Form form = control.FindForm();

            control.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    dragging = true;
                    dragStartPoint = new Point(e.X, e.Y);
                }
            };

            control.MouseMove += (sender, e) =>
            {
                if (dragging && form != null)
                {
                    Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
                    form.Location = new Point(
                        screenPoint.X - dragStartPoint.X,
                        screenPoint.Y - dragStartPoint.Y
                    );
                }
            };

            control.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    dragging = false;
            };
        }

        public static void EnableDoubleClickToClose(this Control control)
        {
            Form from = control.FindForm();

            control.MouseDoubleClick += (sender, e)=>
            {
                if(e.Button == MouseButtons.Left && from != null)
                {
                    from.Close();
                }
            };
        }
    }
}