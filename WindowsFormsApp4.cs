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
 * The designer file (Form1.Designer.cs) is not included.
 * Add the following controls to the form:
 *
 * 📝 TextBoxes
 * ▪ textBox1  - Width / Size input
 * ▪ textBox2  - Height input
 * ▪ textBox3  - Reserved
 * ▪ textBox4  - Reserved
 *
 * 🔘 Buttons
 * ▪ button1 - Draw filled rectangle
 * ▪ button2 - Draw filled circle
 * ▪ button3 - Draw filled ellipse
 * ▪ button4 - Draw rectangle outline
 * ▪ button5 - Placeholder
 * ▪ button6 - Draw ellipse outline
 * ▪ button7 - Select drawing color
 * ▪ button8 - Change Button1 background color
 *
 * 📦 Panel
 * ▪ panel1 - Drawing area
 *
 * 🎨 Dialog
 * ▪ colorDialog1 - Color picker
 *
 * ⚙ Required Events:
 * ▪ Form.Paint
 * ▪ textBox1-4.TextChanged
 * ▪ button1-8.Click
 *
 * ✅ Use the exact control names listed above.
 * ========================================================================= */


// ✨⊱✥━━━━━━━━━━━━━━━━━━━━━━━━━ ❧ ☙ ━━━━━━━━━━━━━━━━━━━━━━━━━✥⊰✨
// // Part 1: Graphic Primitives Drawing


namespace WindowsFormsApp4
{
    
    // 🖼️ MAIN FORM CLASS
   

    public partial class Form1 : Form
    {
        
        // 📦 PRIVATE FIELDS
       

        int n = 0;          // 📐 Width / Size parameter
        int v = 0;          // 📏 Height / Secondary parameter
        Color cvet = Color.Red;  // 🎨 Default drawing color

      
        // 🏗️ CONSTRUCTOR
        

        public Form1()
        {
            InitializeComponent();  // ⚙️ Initialize form components
        }

        
        // 🎨 EVENT HANDLERS (Paint & Text Changed)
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 🖌️ Paint event - custom drawing logic here
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 📝 TextBox1 changed - width input
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // 📝 TextBox4 changed
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // 📝 TextBox3 changed
        }

        
        // 🎨 BUTTON CLICK EVENTS
        

        // 🟥 BUTTON 8: Change button background color
        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        // 🟦 BUTTON 2: Draw filled square (Rectangle)
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = panel1.CreateGraphics();

            myGraphics.Clear(Color.White);
            if (int.TryParse(textBox1.Text, out n))
                n = Convert.ToInt32(textBox1.Text);
            else
                n = 10;

            if (n == 0 && n < 0)
            {
                n = 10;
            }
            var width = this.panel1.Width / 2;
            var width2 = this.panel1.Height / 2;
            SolidBrush brush = new SolidBrush(cvet);
            myGraphics.FillEllipse(brush, width, width2, n, n);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // 📝 TextBox2 changed - height input
        }

        // 🟩 BUTTON 1: Draw filled square (Ellipse)
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = panel1.CreateGraphics();

            myGraphics.Clear(Color.White);
            if (int.TryParse(textBox1.Text, out n))
                n = Convert.ToInt32(textBox1.Text);
            else
                n = 10;

            if (n == 0 && n < 0)
            {
                n = 10;
            }
            var width = this.panel1.Width / 2;
            var width2 = this.panel1.Height / 2;
            SolidBrush brush = new SolidBrush(cvet);
            myGraphics.FillRectangle(brush, width, width2, n, n);
        }

        // 🟪 BUTTON 7: Change drawing color
        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cvet = colorDialog1.Color;
            }
        }

        // 🟫 BUTTON 4: Draw empty rectangle
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = panel1.CreateGraphics();

            myGraphics.Clear(Color.White);

            if (int.TryParse(textBox1.Text, out n))
                n = Convert.ToInt32(textBox1.Text);
            else
                n = 10;

            if (n == 0 && n < 0)
            {
                n = 10;
            }

            if (int.TryParse(textBox2.Text, out v))
                v = Convert.ToInt32(textBox2.Text);
            else
                v = 10;

            if (v == 0 && v < 0)
            {
                v = 10;
            }

            var width = this.panel1.Width / 2;
            var width2 = this.panel1.Height / 2;

            Pen myPen = new Pen(cvet);
            myGraphics.DrawRectangle(myPen, width, width2, n, v);
        }

        // 🟨 BUTTON 3: Draw filled ellipse
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = panel1.CreateGraphics();

            myGraphics.Clear(Color.White);
            if (int.TryParse(textBox1.Text, out n))
                n = Convert.ToInt32(textBox1.Text);
            else
                n = 10;

            if (n == 0 && n < 0)
            {
                n = 10;
            }

            if (int.TryParse(textBox2.Text, out v))
                v = Convert.ToInt32(textBox2.Text);
            else
                v = 15;

            if (v == 0 && v < 0)
            {
                v = 15;
            }

            var width = this.panel1.Width / 2;
            var width2 = this.panel1.Height / 2;
            SolidBrush brush = new SolidBrush(cvet);
            myGraphics.FillEllipse(brush, width, width2, n, v);
        }

        // 🟧 BUTTON 6: Draw empty ellipse
        private void button6_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = panel1.CreateGraphics();

            myGraphics.Clear(Color.White);
            if (int.TryParse(textBox1.Text, out n))
                n = Convert.ToInt32(textBox1.Text);
            else
                n = 10;

            if (n == 0 && n < 0)
            {
                n = 10;
            }

            if (int.TryParse(textBox2.Text, out v))
                v = Convert.ToInt32(textBox2.Text);
            else
                v = 15;

            if (v == 0 && v < 0)
            {
                v = 15;
            }

            var width = this.panel1.Width / 2;
            var width2 = this.panel1.Height / 2;
            Pen myPen = new Pen(cvet);
            myGraphics.DrawEllipse(myPen, width, width2, n, v);
        }

        // ⬜ BUTTON 5: (Empty - placeholder)
        private void button5_Click(object sender, EventArgs e)
        {
            // 🔲 Placeholder button - add functionality here
        }
    }
}
