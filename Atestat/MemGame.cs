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
        string[] panou_address;
        int n = 3;
        PictureBox[] boxes;
        public MemGame()
        {
            string[] file_names = { "avion.png", "bloc.png", "caine.jpg", "caprioara.jpg", "iepure.png", "leu.jpg", "lup.jpg", "vulpe.png" };
            InitializeComponent();
            String base_string = Application.StartupPath;
            base_string = base_string.Remove(base_string.Length - 9);
            base_string += "Resurse\\Imagini\\";
            MessageBox.Show(base_string);
            string[] panou_address = new string[8];
            panou_address = Enumerable.Repeat(base_string, 8).ToArray();
            for(int i = 0; i < panou_address.Length; i++)
            {
                panou_address[i] += file_names[i];
            }
            //MessageBox.Show(panou_address[2]);
            this.panou_address = panou_address;
        }
        private void MemGame_Load(object sender, EventArgs e)
        {
            boxes = new PictureBox[panou_address.Length];
            for(int i = 0; i<n; i++)
            {
                boxes[i] = new PictureBox();
                boxes[i].Location = new Point(30, i*50);
                boxes[i].ImageLocation = panou_address[i];
                boxes[i].Show();
            }
        }
    }
}
