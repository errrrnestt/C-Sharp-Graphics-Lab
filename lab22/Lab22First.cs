using System;
using System.IO;
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
 * Form1 Layout Elements (Text Processor):
 *
 * 📝 Inputs (TextBoxes)
 * ▪ textBox1 - "Исходный текст" (Source content)
 * ▪ textBox2 - "Количество слов в строке" (Output results)
 *
 * 🔘 Buttons
 * ▪ button1 - "Открыть" (Open source file)
 * ▪ button2 - "Сохранить" (Save output file)
 * ▪ button3 - "Вывести результат" (Process text)
 * ▪ button4 - "Выход" (Exit application)
 *
 * ========================================================================= */

namespace WindowsFormsApp22
{
    // ╔════════════════════════════════════════════════════════════════════════╗
    // ║ 🧩 CORE COMPONENT: Form1                                               ║
    // ╠════════════════════════════════════════════════════════════════════════╣
    // ║ ▪ Primary UI Window for Text File Processing                           ║
    // ╚════════════════════════════════════════════════════════════════════════╝
    public partial class Lab22First : Form
    {
        // ⚙ Internal State: File paths and counter
        int r = 0;
        string inFileName, outFileName;

        public Lab22First()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: OPEN SOURCE FILE (button1_Click)
        // 🎯 Target: Select file ➔ Read content to textBox1
        // ──────────────────────────────────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            
            OpenFileDialog dText = new OpenFileDialog();
            dText.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
            if (dText.ShowDialog() == DialogResult.OK)
            {
                inFileName = dText.FileName; 
            }
            else
            {
                inFileName = ""; 
                return;
            }

            // 📦 Read file content into the source textbox
            StreamReader sr = new StreamReader(inFileName);
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: SAVE OUTPUT FILE (button2_Click)
        // 🎯 Target: Write processed data from textBox2 to a file
        // ──────────────────────────────────────────────────────────────────────
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dSaveText = new SaveFileDialog();
            dSaveText.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
            if (dSaveText.ShowDialog() == DialogResult.OK)
            {
                outFileName = dSaveText.FileName;
                StreamWriter writer = new StreamWriter(outFileName);
                
                writer.Write(textBox2.Text);
                writer.Close();
                
                MessageBox.Show("Output file saved successfully.", 
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: PROCESS TEXT (button3_Click)
        // 🎯 Target: Iterate lines, count words (spaces + 1), display result
        // ──────────────────────────────────────────────────────────────────────
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inFileName))
            {
                MessageBox.Show("Please select a source file first!", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            textBox2.Clear();
            StreamReader sr = new StreamReader(inFileName);

            int lineNumber = 1;
            
            // ⟳ Loop through each line of the file
            while (!sr.EndOfStream) 
            {
                string line = sr.ReadLine();
                r = 0; // Reset counter for new line

                // 🎯 Count spaces to determine word count (assuming word count = spaces + 1)
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ' ') r++;
                }
                
                // 📝 Append result: "Строка N: word_count"
                textBox2.Text += "Строка " + lineNumber + ": " + (r + 1) + Environment.NewLine;
                
                lineNumber++;
            }
            
            sr.Close();
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: EXIT (button4_Click)
        // ──────────────────────────────────────────────────────────────────────
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}