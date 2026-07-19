using System;
using System.Windows.Forms;
using System.IO;

/* =========================================================================
 * 🎨 UI BUILD GUIDE
 * =========================================================================
 * Form Layout Elements:
 *
 * 📝 Inputs (TextBoxes)
 * ▪ textBox1 - Display area for text loaded from global state
 *
 * 🔘 Buttons
 * ▪ button1 - Load data from Class1 into the text box
 * ▪ button2 - Reserved for future functionality
 * ▪ button3 - Save current text content to a file
 *
 * 🎨 Dialogs
 * ▪ saveFileDialog1 - File picker for saving text data
 *
 * ========================================================================= */

namespace WinFormsApp14
{
    // ╔════════════════════════════════════════════════════════════════════════╗
    // ║ 🧩 CORE COMPONENT: Lab22Second                                         ║
    // ╠════════════════════════════════════════════════════════════════════════╣
    // ║ ▪ Secondary UI Window for exporting data                               ║
    // ╚════════════════════════════════════════════════════════════════════════╝
    public partial class Lab22Second : Form
    {
        // ⚙ Internal State: Default file path
        string outFileName = "Dfile.txt"; 

        public Lab22Second()
        {
            InitializeComponent();  
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: PENDING / UNASSIGNED (button2_Click)
        // ──────────────────────────────────────────────────────────────────────
        private void button2_Click(object sender, EventArgs e)
        {
            // Placeholder for future logic
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: LOAD FROM GLOBAL STATE (button1_Click)
        // 🎯 Target: Retrieve string from static class and render to UI
        // ──────────────────────────────────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Class1.line; // Fetch data from static registry
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: SAVE OUTPUT FILE (button3_Click)
        // 💾 Target: Configure save dialog ➔ Write text payload to disk
        // ──────────────────────────────────────────────────────────────────────
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dSaveText = new SaveFileDialog(); // Initialize dialog
            
            // Set file filters for text files
            dSaveText.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
            if (dSaveText.ShowDialog() == DialogResult.OK) // Trigger save dialog
            {
                outFileName = dSaveText.FileName; // Capture selected path
                StreamWriter writer = new StreamWriter(outFileName);
                
                writer.Write(textBox1.Text); // Write content to file
                writer.Close(); // Terminate stream
                
                // Show confirmation
                MessageBox.Show("Output file saved at:\n" + outFileName,
                                "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                outFileName = ""; // Reset file path state if canceled
                return;
            };
        }
    }
}