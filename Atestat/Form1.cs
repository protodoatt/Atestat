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
using System.IO;

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
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+sqlpoint+";Integrated Security=True;Connect Timeout=30; MultipleActiveResultSets=true");
            inregistrare = new Inregistrare(con);
            textBox2.PasswordChar = '*';
            //user_data_loader();
            //results_data_loader();
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
                    this.Hide();
                    SqlCommand cmd2 = new SqlCommand("SELECT NumeUtilizator FROM Utilizatori WHERE EmailUtilizator = @email", con);
                    cmd2.Parameters.AddWithValue("@email", textBox1.Text);
                    SqlDataReader rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    string usrnm = rdr[0].ToString();
                    usrnm = usrnm.Trim();
                    rdr.Close();
                    AlegeJoc joc = new AlegeJoc(textBox1.Text, usrnm);
                    joc.Show();
                    joc.Closed += (s, args) => this.Close();
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
            //MessageBox.Show(dec.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap)));
            String unprocessed_code = dec.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
            string[] code = unprocessed_code.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            textBox1.Text = code[1];
            textBox2.Text = code[2];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = qdec.Encode("andrei O SUGE");
            pictureBox1.Image = bmp;
        }

        private void user_data_loader()
        {
            con.Open();
            StreamReader sr = new StreamReader(sqlpoint.Remove(sqlpoint.Length-15)+"\\Resurse\\Utilizatori.txt");
            String line = sr.ReadLine();
            while(line != null)
            {
                string[] split_line = line.Split(new string[] {";" }, StringSplitOptions.RemoveEmptyEntries);
                //MessageBox.Show(split_line[1]);
                string command = "INSERT INTO Utilizatori (NumeUtilizator, Parola, EmailUtilizator) VALUES (@user, @pass, @email)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@user", split_line[1]);
                cmd.Parameters.AddWithValue("@pass", split_line[2]);
                cmd.Parameters.AddWithValue("@email", split_line[0]);
                cmd.ExecuteNonQuery();
                line = sr.ReadLine();
            }
            con.Close();
        }

        private void results_data_loader()
        {
            con.Open();
            StreamReader sr = new StreamReader(sqlpoint.Remove(sqlpoint.Length - 15) + "\\Resurse\\Rezultate.txt");
            String line = sr.ReadLine();
            while(line != null)
            {
                string[] split_line = line.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                string command = "INSERT INTO Rezultate (TipJoc, EmailUtilizator, PunctajJoc, Data) VALUES (@tipjoc, @email, @punctaj, @data)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@tipjoc", split_line[0]);
                cmd.Parameters.AddWithValue("@email", split_line[1]);
                cmd.Parameters.AddWithValue("@punctaj", split_line[2]);
                cmd.Parameters.AddWithValue("@data", DateTime.Parse(split_line[3]));
                cmd.ExecuteNonQuery();
                line = sr.ReadLine();
            }
            con.Close();
        }
    }
}
