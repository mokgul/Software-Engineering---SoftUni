using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Point_and_Rectangle
{
    public partial class FormPointAndRectangle : Form
    {
        public FormPointAndRectangle()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            var x1 = this.numericUpDownX1.Value;
            var y1 = this.numericUpDownY1.Value;
            var x2 = this.numericUpDownX2.Value;
            var y2 = this.numericUpDownY2.Value;
            var x = this.numericUpDownX.Value;
            var y = this.numericUpDownY.Value;

            DisplayPointLocation(x1, y1, x2, y2, x, y);

            var minX = Min(x1, x2, x);
            var maxX = Max(x1, x2, x);
            var minY = Min(y1, y2, y);
            var maxY = Max(y1, y2, y);
            var diagramWidth = maxX - minX;
            var diagramHeight = maxY - minY;
            var ratio = 1.0m;
            var offset = 10;
            if (diagramWidth != 0 && diagramHeight != 0)

            {
                var ratioX =
                (pictureBox.Width - 2 * offset - 1) / diagramWidth;
                var ratioY =
                (pictureBox.Height - 2 * offset - 1) / diagramHeight;
                ratio = Math.Min(ratioX, ratioY);
            }
            // Calculate the scaled rectangle coordinates
            var rectLeft =
            offset + (int)Math.Round((Math.Min(x1, x2) - minX) * ratio);
            var rectTop =
            offset + (int)Math.Round((Math.Min(y1, y2) - minY) * ratio);
            var rectWidth = (int)Math.Round(Math.Abs(x2 - x1) * ratio);
            var rectHeight = (int)Math.Round(Math.Abs(y2 - y1) * ratio);
            var rect =
            new Rectangle(rectLeft, rectTop, rectWidth, rectHeight);
            // Calculate the scalled point coordinates
            var pointX = (int)Math.Round(offset + (x - minX) * ratio);
            var pointY = (int)Math.Round(offset + (y - minY) * ratio);
            var pointRect = new Rectangle(pointX - 2, pointY - 2, 5, 5);
            // Draw the rectangle and point
            pictureBox.Image =
            new Bitmap(pictureBox.Width, pictureBox.Height);
            using (var g = Graphics.FromImage(pictureBox.Image))
            {
                // Draw diagram background (white area)
                g.Clear(Color.White);
                // Draw the rectangle (scalled to the picture box size)
                var pen = new Pen(Color.Blue, 3);
                g.DrawRectangle(pen, rect);
                // Draw the point (scalled to the picture box size)
                pen = new Pen(Color.DarkBlue, 5);
                g.DrawEllipse(pen, pointRect);
            }
        }
        private decimal Min(decimal val1, decimal val2, decimal val3)
        {
            return Math.Min(val1, Math.Min(val2, val3));

        }
        private decimal Max(decimal val1, decimal val2, decimal val3)
        {
            return Math.Max(val1, Math.Max(val2, val3));
        }




        private void DisplayPointLocation(decimal x1, decimal y1, decimal x2, decimal y2,
           decimal x, decimal y)
        {
            var left = Math.Min(x1, x2);
            var right = Math.Max(x1, x2);
            var top = Math.Max(y1, y2);
            var bottom = Math.Min(y1, y2);
            if (x > left && x < right && y > bottom && y < top)
            {
                this.labelLocation.Text = "Inside";
                this.labelLocation.BackColor = Color.LightGreen;
            }
            else if (x < left || x > right || y < bottom || y > top)
            {
                this.labelLocation.Text = "Outside";
                this.labelLocation.BackColor = Color.LightSalmon;
            }
            else
            {
                this.labelLocation.Text = "Border";
                this.labelLocation.BackColor = Color.Gold;
            }
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownX1_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownY1_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownX2_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownY2_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void FormPointAndRectangle_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void FormPointAndRectangle_Resize(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
