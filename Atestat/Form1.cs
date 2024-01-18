using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessagingToolkit.QRCode.Codec.Data;
using MessagingToolkit.QRCode.Codec;

namespace Atestat
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        String sqlpoint = Application.StartupPath;
        QRCodeEncoder qdec;
        Inregistrare inregistrare;
        
        public Form1()
        {
            sqlpoint = sqlpoint.Remove(sqlpoint.Length - 9)+"JocEducativ.mdf";
            //MessageBox.Show(sqlpoint);
            qdec = new QRCodeEncoder();
            qdec.QRCodeScale = 8;
            
            InitializeComponent();
            //MessageBox.Show(sqlpoint.ToString());
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+sqlpoint+";Integrated Security=True;Connect Timeout=30");
            inregistrare = new Inregistrare(con);
            textBox2.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE EmailUtilizator ='" + textBox1.Text + "' AND Parola ='" + textBox2.Text + "'", con);
                if (cmd.ExecuteReader().Read())
                {
                    MessageBox.Show("success");
                }
                else MessageBox.Show("error");
                con.Close();
            }
            else MessageBox.Show("rubricile nu sunt completate");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inregistrare.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = sqlpoint.Remove(sqlpoint.Length - "JocEducativ.mdf".Length)+"Resurse\\QRCode";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            QRCodeDecoder dec = new QRCodeDecoder();

            MessageBox.Show(dec.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap)));

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = qdec.Encode("andrei O SUGE");
            pictureBox1.Image = bmp;
        }
    }
}
