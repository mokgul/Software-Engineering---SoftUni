using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nakov.TurtleGraphics;

namespace TurtleGraphics
{
    public partial class FormTurtleGraphics : Form
    {
        public FormTurtleGraphics()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200; 

            Turtle.Rotate(30);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);

            Turtle.Rotate(-30);
            Turtle.PenUp();
            Turtle.Backward(50);
            Turtle.PenDown();
            Turtle.Backward(100);
            Turtle.PenUp();
            Turtle.Forward(150);
            Turtle.PenDown();
            Turtle.Rotate(30);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
        }

        private void buttonShowHideTurtle_Click(object sender, EventArgs e)
        {
            if (Turtle.ShowTurtle)
            {
                Turtle.ShowTurtle = false;
                this.buttonShowHideTurtle.Text = "Show Turtle";
            }
            else
            {
                Turtle.ShowTurtle = true;
                this.buttonShowHideTurtle.Text = "Hide Turtle";
            }
        }

        private void buttonHexagon_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200 ;
            for (int i = 1; i <=6; i++)
            { 
                Turtle.Forward(100);
                Turtle.Rotate(60);
            }
        }

        private void buttonStar_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            Turtle.PenColor = Color.Green;
            for (int i= 1; i <=5; i++)
            {
                Turtle.Forward(200);
                Turtle.Rotate(144);
            }
        }

        private void buttonSpiral_Click(object sender, EventArgs e)
        {
            int move = 0;
            Turtle.Delay = 200;
            for (int i = 0; i < 20; i++)
            {
                move += 10;
                Turtle.Forward(move);
                Turtle.Rotate(60);
            }
        }

        private void buttonSun_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 36; i++)
            {
                Turtle.Delay = 200;
                Turtle.Rotate(5);
                Turtle.Forward(200);
                Turtle.Rotate(-175);
                Turtle.Forward(200);

               
            }
        }

        private void buttonSpiralTriangle_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            Turtle.PenColor = Color.Red;
            int distance = 0;
            for (int i = 0; i < 22; i++)
            {
                distance += 10;
                Turtle.Forward(distance);
                Turtle.Rotate(120);
            }
            distance = 0;
            for (int i = 0; i < 22; i++)
            {
                distance += 10;
                Turtle.Forward(distance);
                Turtle.Rotate(120);
            }
            distance = 0;
            for (int i = 0; i < 22; i++)
            {
                distance += 10;
                Turtle.Forward(distance);
                Turtle.Rotate(120);
            }
        }
    }
}
