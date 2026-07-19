using System;
using System.Windows.Forms;
using System.IO;

/* =========================================================================
 * 🎨 UI BUILD GUIDE
 * =========================================================================
 * Form2 Layout Elements (Settings/Editor):
 *
 * 📝 Inputs (TextBoxes)
 * ▪ textBox1 - Editor area for training text
 *
 * 🔘 Buttons
 * ▪ button1 - "Load from file" (Завантажити з файлу)
 * ▪ button2 - "Save" (Зберегти)
 * ▪ button3 - "Cancel" (Скасувати)
 *
 * 🎨 Dialogs
 * ▪ openFileDialog1 - Open file picker
 * ▪ saveFileDialog1 - Save file picker
 *
 * ========================================================================= */

namespace WinFormsApp14
{
    // ╔════════════════════════════════════════════════════════════════════════╗
    // ║ 🧩 CORE COMPONENT: Form2                                               ║
    // ╠════════════════════════════════════════════════════════════════════════╣
    // ║ ▪ Settings and Text Editor Window                                      ║
    // ╚════════════════════════════════════════════════════════════════════════╝
    public partial class Form2 : Form // Fixed: added missing inheritance colon
    {
        string outFileName = "Dfile.txt"; // Fixed: added missing quotes

        public Form2()
        {
            InitializeComponent();
        }

        // ➔ ACTION: LOAD FROM FILE (button1_Click)
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dOpen = new OpenFileDialog();
            dOpen.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dOpen.ShowDialog() == DialogResult.OK)
            {
                // Load file content into textbox and update global state
                textBox1.Text = File.ReadAllText(dOpen.FileName);
                Class1.line = textBox1.Text;
            }
        }

        // ➔ ACTION: SAVE TO FILE (button2_Click)
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dSaveText = new SaveFileDialog(); // Create dialog window
            dSaveText.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
            if (dSaveText.ShowDialog() == DialogResult.OK) // Trigger dialog
            {
                outFileName = dSaveText.FileName; // Save file path
                File.WriteAllText(outFileName, textBox1.Text); // Write content
                
                // Update global state and notify user
                Class1.line = textBox1.Text;
                MessageBox.Show("File saved successfully at:\n" + outFileName, 
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ➔ ACTION: CANCEL (button3_Click)
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the settings window
        }
    }
}