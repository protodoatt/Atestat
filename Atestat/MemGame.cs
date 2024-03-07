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
        int n = 8;
        PictureBox[] boxes, match_boxes;
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
                boxes[i].Location = new Point(100*i, 50);
                boxes[i].BackgroundImage = Image.FromFile(panou_address[i]);
                boxes[i].BackColor = Color.Yellow;
                boxes[i].BackgroundImageLayout = ImageLayout.Stretch;
                boxes[i].Size = new Size(90, 90);
                this.Controls.Add(boxes[i]);
            }
            match_boxes = new PictureBox[panou_address.Length];
            Random rnd = new Random();
            for(int i = 0; i<n; i++) {
                match_boxes[i] = new PictureBox();
                match_boxes[i].Location = new Point(100 * i, 120);
                string bleh = panou_address[rnd.Next(0, panou_address.Length)];
                match_boxes[i].BackgroundImage = Image.FromFile(bleh);
                match_boxes[i].BackColor = Color.Yellow;
                match_boxes[i].BackgroundImageLayout = ImageLayout.Stretch;
                match_boxes[i].Size = new Size(90, 90);
                this.Controls.Add(match_boxes[i]);
            }
        }
    }
}
