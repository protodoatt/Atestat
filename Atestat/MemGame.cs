using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
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
        string username, email;
        bool gamestarted = false;
        public MemGame(string username, string email)
        {
            string[] file_names = { "avion.png", "bloc.png", "caine.jpg", "caprioara.jpg", "iepure.png", "leu.jpg", "lup.jpg", "vulpe.png" };
            InitializeComponent();
            String base_string = Application.StartupPath;
            base_string = base_string.Remove(base_string.Length - 9);
            base_string += "Resurse\\Imagini\\";
            string[] panou_address = new string[8];
            panou_address = Enumerable.Repeat(base_string, 8).ToArray();
            for(int i = 0; i < panou_address.Length; i++)
            {
                panou_address[i] += file_names[i];
            }
            //MessageBox.Show(panou_address[2]);
            this.panou_address = panou_address;
            this.username = username;
            this.email = email;
        }
        private void MemGame_Load(object sender, EventArgs e)
        {
            button1.Text = "Start!";

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
                if (selected_image == match_boxes_images[index] && selected_image_row==false)
                {
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    pb.BackgroundImage = Image.FromFile(selected_image);
                    selected_image = null;
                    selected_image_row = null;
                    points++;
                    update_label(points);
                }
                else if(selected_image_row == true)
                {
                    int index_remover = Array.IndexOf(panou_address, selected_image);
                    boxes[index_remover].BackgroundImage = null;
                }
                else
                {
                    Timer timer = new Timer();
                    timer.Interval = 300;
                    Imager imager = new Imager(pb);
                    imager.show_image(Image.FromFile(match_boxes_images[index]));
                    timer.Tick += imager.hide_image;
                    timer.Start();
                }
            }
            else if (pb.BackgroundImage == null && selected_image_row == null)
            {
                selected_image = match_boxes_images[index];
                selected_image_row = true;
                pb.BackgroundImage = Image.FromFile(match_boxes_images[index]);
            }
        }

        private void click (object sender, System.EventArgs e) {
            PictureBox pb = (PictureBox)sender;
            int index = Array.IndexOf(boxes, pb);
            if (selected_image != null)
            {
                if (selected_image == panou_address[index] && selected_image_row == true)
                {
                    pb.BackgroundImage = Image.FromFile(panou_address[index]);
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    selected_image = null;
                    selected_image_row = null;
                    points++;
                    update_label(points);
                }
                else if (selected_image_row == false)
                {
                    int index_remover = Array.IndexOf(match_boxes_images, selected_image);
                    match_boxes[index_remover].BackgroundImage = null;
                }

                else
                {
                    Timer timer = new Timer();
                    timer.Interval = 300;
                    Imager imager = new Imager(pb);
                    imager.show_image(Image.FromFile(panou_address[index]));
                    timer.Tick += imager.hide_image;
                    timer.Start();
                }
            }
            else if (pb.BackgroundImage == null && selected_image_row == null) {
                selected_image = panou_address[index];
                selected_image_row = false;
                pb.BackgroundImage = Image.FromFile(panou_address[index]);
            }
            if (points == 8) db_loader();
        }

        public class Imager
        {
            PictureBox pb;
            public void hide_image(object sender, EventArgs e)
            {
                pb.BackgroundImage = null;
                Timer ts = (Timer)sender;
                ts.Stop();
            }
            public void show_image(Image img)
            {
                pb.BackgroundImage = img;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
            }
            public Imager(PictureBox pb)
            {
                this.pb = pb;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gamestarted)
                reset_game(sender, e);
            else start_game(sender, e);
        }
        private void start_game(object sender, EventArgs e)
        {
            gamestarted = true;
            Button but = (Button)sender;
            but.Text = "Reset";
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer_update;
            timer1.Start();
        }
        int seconds = 30;

        private void timer_update(object sender, EventArgs e)
        {
            label2.Text = "Timer: " + seconds--.ToString();
            if(seconds <= 0)
            {
                timer1.Stop();
                label2.Text = "S-a scurs timpul!";
                label2.ForeColor = Color.Red;
                for(int i = 0; i<n; i++)
                {
                    match_boxes[i].Click -= click_match;
                    boxes[i].Click -= click;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void reset_game(object sender, System.EventArgs e)
        {
            for(int i =  0; i < match_boxes.Length; i++)
            {
                match_boxes[i].Dispose();
                boxes[i].Dispose();
            }
            boxes = null;
            match_boxes = null;
            points = 0;
            button1.Text = "Start!";
            timer1.Stop();
            timer1.Enabled = false;
            timer1.Tick -= timer_update;
            selected_image = null;
            selected_image_row = null;
            update_label(0);
            gamestarted = false;
            seconds = 30;
            label2.Text = "Timer: ";
            MemGame_Load(sender, e);
        }

        public void db_loader()
        {

        }
    }
}
