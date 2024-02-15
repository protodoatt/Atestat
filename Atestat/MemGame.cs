using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class MemGame : Form
    {
        public MemGame()
        {
            InitializeComponent();
            String base_string = Application.StartupPath;
            base_string = base_string.Remove(base_string.Length - 9);
            base_string += "\\Resurse\\Imagini\\";
            MessageBox.Show(base_string);
            string[] panou_address = new string[8];
            MessageBox.Show(panou_address[2]);
        }

        private void MemGame_Load(object sender, EventArgs e)
        {

        }
    }
}
