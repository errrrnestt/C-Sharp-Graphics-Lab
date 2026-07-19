using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* =========================================================================
 * 🎨 UI BUILD GUIDE
 * =========================================================================
 * Add the following controls:
 *
 * 📝 TextBoxes
 * ▪ textBox1 - Inner radius (r)
 * ▪ textBox2 - X coordinate
 * ▪ textBox3 - Outer radius (R)
 * ▪ textBox4 - Vertices count (n)
 * ▪ textBox5 - Y coordinate
 *
 * 🔘 Buttons
 * ▪ button1 - Draw star/polygon
 * ▪ button2 - Select color
 *
 * 📦 Panel
 * ▪ panel1 - Drawing area
 *
 * 🎨 Dialog
 * ▪ colorDialog1 - Color picker
 *
 * ⚙ Events:
 * ▪ button1.Click
 * ▪ button2.Click
 * ▪ textBox1-5.TextChanged
 *
 * ========================================================================= */

// ✨⊱✥━━━━━━━━━━━━━━━━━━━━━━━━━ ❧ ☙ ━━━━━━━━━━━━━━━━━━━━━━━━━✥⊰✨
// Part 3: Star Drawing


namespace WindowsFormsApp5
{
    
    // 🖼️ MAIN FORM CLASS - STAR/POLYGON DRAWER
    

    public partial class Form1 : Form
    {
      
        // 🏗️ CONSTRUCTOR
        

        public Form1()
        {
            InitializeComponent();
        }

       
        // 📦 PRIVATE FIELDS
        

        Color cvet = Color.Red;  // 🎨 Default drawing color

       
        // 🖊️ BUTTON 1: Draw star/polygon
        

        private void button1_Click(object sender, EventArgs e)
        {
            
            // 📐 SHAPE PARAMETERS (default values)
         

            int n = 5;               // 🔢 Number of vertices
            double R = 25, r = 50;   // 📏 Outer and inner radii
            double alpha = 0;        // 🔄 Rotation angle
            double x0 = 60, y0 = 60; // 📍 Center coordinates

            // 🖼️ Get graphics context from panel
            Graphics myGraphics = panel1.CreateGraphics();

           
            // 📥 READ USER INPUTS WITH VALIDATION
           

            // 🔢 Number of vertices (textBox4)
            n = Convert.ToInt32(textBox4.Text);
            if (n == 0 && n < 0)
            {
                n = 5;  // ⚠️ Fallback to default if invalid
            }

            // 📏 Outer radius (textBox3)
            R = Convert.ToInt32(textBox3.Text);
            if (R == 0 && R < 0)
            {
                R = 25;  // ⚠️ Fallback to default if invalid
            }

            // 📏 Inner radius (textBox1)
            r = Convert.ToInt32(textBox1.Text);
            if (r == 0 && r < 0)
            {
                r = 50;  // ⚠️ Fallback to default if invalid
            }

            // 📍 X center coordinate (textBox2)
            x0 = Convert.ToInt32(textBox2.Text);
            if (x0 == 0 && x0 < 0)
            {
                x0 = 60;  // ⚠️ Fallback to default if invalid
            }

            // 📍 Y center coordinate (textBox5)
            y0 = Convert.ToInt32(textBox5.Text);
            if (y0 == 0 && y0 < 0)
            {
                y0 = 60;  // ⚠️ Fallback to default if invalid
            }

            
            // ⭐ CALCULATE STAR VERTICES
            

            PointF[] points = new PointF[2 * n + 1];
            double a = alpha;           // 🔄 Current angle
            double da = Math.PI / n;    // 📐 Angle step
            double l;                  // 📏 Current radius (alternates)

            for (int k = 0; k < 2 * n + 1; k++)
            {
                // 🔄 Alternate between outer (R) and inner (r) radii
                l = k % 2 == 0 ? r : R;
                
                // 📐 Calculate point coordinates using polar coordinates
                points[k] = new PointF(
                    (float)(x0 + l * Math.Cos(a)),  // X coordinate
                    (float)(y0 + l * Math.Sin(a))   // Y coordinate
                );
                a += da;  // ➕ Advance angle
            }

            
            // 🎨 DRAW THE STAR
           

            Pen myPen = new Pen(cvet);  // 🖊️ Create pen with selected color
            myGraphics.DrawLines(myPen, points);  // ⭐ Draw the star shape
        }

        
        // 📝 TEXTBOX EVENT HANDLERS (Placeholders)
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // 🔢 Vertices input
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // 📏 Outer radius input
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 📏 Inner radius input
        }

       
        // 🎨 BUTTON 2: Change drawing color
    

        private void button2_Click(object sender, EventArgs e)
        {
            // 🎨 Open color dialog
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cvet = colorDialog1.Color;  // ✅ Apply selected color
            }
        }
    }
}
