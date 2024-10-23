using Nakov.TurtleGraphics;

namespace TurtleGraphics
{
    partial class FormTurtleGraphics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonShowHideTurtle = new System.Windows.Forms.Button();
            this.buttonHexagon = new System.Windows.Forms.Button();
            this.buttonStar = new System.Windows.Forms.Button();
            this.buttonSpiral = new System.Windows.Forms.Button();
            this.buttonSun = new System.Windows.Forms.Button();
            this.buttonSpiralTriangle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(12, 12);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(106, 44);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 62);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(106, 44);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonShowHideTurtle
            // 
            this.buttonShowHideTurtle.Location = new System.Drawing.Point(12, 112);
            this.buttonShowHideTurtle.Name = "buttonShowHideTurtle";
            this.buttonShowHideTurtle.Size = new System.Drawing.Size(106, 44);
            this.buttonShowHideTurtle.TabIndex = 2;
            this.buttonShowHideTurtle.Text = "Hide Turtle";
            this.buttonShowHideTurtle.UseVisualStyleBackColor = true;
            this.buttonShowHideTurtle.Click += new System.EventHandler(this.buttonShowHideTurtle_Click);
            // 
            // buttonHexagon
            // 
            this.buttonHexagon.Location = new System.Drawing.Point(12, 162);
            this.buttonHexagon.Name = "buttonHexagon";
            this.buttonHexagon.Size = new System.Drawing.Size(106, 44);
            this.buttonHexagon.TabIndex = 3;
            this.buttonHexagon.Text = "Hexagon";
            this.buttonHexagon.UseVisualStyleBackColor = true;
            this.buttonHexagon.Click += new System.EventHandler(this.buttonHexagon_Click);
            // 
            // buttonStar
            // 
            this.buttonStar.Location = new System.Drawing.Point(12, 212);
            this.buttonStar.Name = "buttonStar";
            this.buttonStar.Size = new System.Drawing.Size(106, 44);
            this.buttonStar.TabIndex = 4;
            this.buttonStar.Text = "Star";
            this.buttonStar.UseVisualStyleBackColor = true;
            this.buttonStar.Click += new System.EventHandler(this.buttonStar_Click);
            // 
            // buttonSpiral
            // 
            this.buttonSpiral.Location = new System.Drawing.Point(12, 262);
            this.buttonSpiral.Name = "buttonSpiral";
            this.buttonSpiral.Size = new System.Drawing.Size(106, 44);
            this.buttonSpiral.TabIndex = 5;
            this.buttonSpiral.Text = "Spiral";
            this.buttonSpiral.UseVisualStyleBackColor = true;
            this.buttonSpiral.Click += new System.EventHandler(this.buttonSpiral_Click);
            // 
            // buttonSun
            // 
            this.buttonSun.Location = new System.Drawing.Point(12, 312);
            this.buttonSun.Name = "buttonSun";
            this.buttonSun.Size = new System.Drawing.Size(106, 44);
            this.buttonSun.TabIndex = 6;
            this.buttonSun.Text = "Sun";
            this.buttonSun.UseVisualStyleBackColor = true;
            this.buttonSun.Click += new System.EventHandler(this.buttonSun_Click);
            // 
            // buttonSpiralTriangle
            // 
            this.buttonSpiralTriangle.Location = new System.Drawing.Point(12, 362);
            this.buttonSpiralTriangle.Name = "buttonSpiralTriangle";
            this.buttonSpiralTriangle.Size = new System.Drawing.Size(106, 44);
            this.buttonSpiralTriangle.TabIndex = 7;
            this.buttonSpiralTriangle.Text = "Spiral Triangle";
            this.buttonSpiralTriangle.UseVisualStyleBackColor = true;
            this.buttonSpiralTriangle.Click += new System.EventHandler(this.buttonSpiralTriangle_Click);
            // 
            // FormTurtleGraphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSpiralTriangle);
            this.Controls.Add(this.buttonSun);
            this.Controls.Add(this.buttonSpiral);
            this.Controls.Add(this.buttonStar);
            this.Controls.Add(this.buttonHexagon);
            this.Controls.Add(this.buttonShowHideTurtle);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonDraw);
            this.Name = "FormTurtleGraphics";
            this.Text = "Turtle Graphics - Example";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonShowHideTurtle;
        private System.Windows.Forms.Button buttonHexagon;
        private System.Windows.Forms.Button buttonStar;
        private System.Windows.Forms.Button buttonSpiral;
        private System.Windows.Forms.Button buttonSun;
        private System.Windows.Forms.Button buttonSpiralTriangle;
    }
}

