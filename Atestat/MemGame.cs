using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        string[] match_boxes_images;
        string selected_image = null;
        int points = 0;
        bool? selected_image_row;
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
            for (int i = 0; i<n; i++)
            {
                boxes[i] = new PictureBox();
                boxes[i].Location = new Point(100*i, 50);
                //boxes[i].BackgroundImage = Image.FromFile(panou_address[i]);
                boxes[i].BackColor = Color.Yellow;
                boxes[i].BackgroundImageLayout = ImageLayout.Stretch;
                boxes[i].Size = new Size(90, 90);
                boxes[i].Click += click;
                this.Controls.Add(boxes[i]);
            }
            match_boxes = new PictureBox[panou_address.Length];
            Random rnd = new Random();
            bool[] last_occurences = new bool[panou_address.Length];
            string[] match_boxes_images = new string[panou_address.Length];
            for(int i = 0; i<n; i++) {
                match_boxes[i] = new PictureBox();
                match_boxes[i].Location = new Point(100 * i, 150);
                string bleh;
                int rand = rnd.Next(0, panou_address.Length);
                while (last_occurences[rand] == true)
                    rand = rnd.Next(0, panou_address.Length);
                last_occurences[rand] = true;
                bleh = panou_address[rand];
                //match_boxes[i].BackgroundImage = Image.FromFile(bleh);
                match_boxes_images[i] = bleh;
                match_boxes[i].BackColor = Color.Yellow;
                match_boxes[i].BackgroundImageLayout = ImageLayout.Stretch;
                match_boxes[i].Size = new Size(90, 90);
                match_boxes[i].Click += click_match;
                this.Controls.Add(match_boxes[i]);
            }
            this.match_boxes_images = match_boxes_images;
        }

        private void update_label(int n)
        {
            label1.Text = "Puncte: " + n;
        }

        private void click_match(object sender, System.EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int index = Array.IndexOf(match_boxes, pb);
            if (selected_image != null)
            {
                if (selected_image == match_boxes_images[index])
                {
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    pb.Image = Image.FromFile(selected_image);
                    selected_image = null;
                    points++;
                    update_label(points);
                }
                else
                {
                    int index_remover = Array.IndexOf(panou_address, selected_image);
                    boxes[index_remover].Image = null;
                }
            }
            else if (pb.Image == null && (selected_image_row == false || selected_image_row == null))
            {
                selected_image = match_boxes_images[index];
                selected_image_row = true;
                pb.Image = Image.FromFile(match_boxes_images[index]);
            }
        }

        private void click (object sender, System.EventArgs e) {
            PictureBox pb = (PictureBox)sender;
            int index = Array.IndexOf(boxes, pb);
            if (selected_image != null)
            {
                if (selected_image == panou_address[index])
                {
                    pb.Image = Image.FromFile(panou_address[index]);
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    selected_image = null;
                    points++;
                    update_label(points);
                }
                else
                {
                    int index_remover = Array.IndexOf(match_boxes_images, selected_image);
                    match_boxes[index_remover].Image = null;
                }
            }
            else if (pb.Image == null && (selected_image_row==true || selected_image_row == null)) {
                selected_image = panou_address[index];
                selected_image_row = false;
                pb.Image = Image.FromFile(panou_address[index]);
            }
        }
    }
}
