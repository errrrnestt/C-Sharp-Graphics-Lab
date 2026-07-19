using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp14
{
    // ╔════════════════════════════════════════════════════════════════════════╗
    // ║ ⚙ CLUSTER CONFIGURATION PROFILE: Class1                                ║
    // ╠════════════════════════════════════════════════════════════════════════╣
    // ║ ▪ Global state registry for cross-form data exchange                   ║
    // ╚════════════════════════════════════════════════════════════════════════╝
    static class Class1
    {
        public static bool F = false;     // ▫ Global boolean flag
        public static string line = "1";  // ▫ Global string payload
    }
}