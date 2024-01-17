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

namespace Atestat
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        String sqlpoint = Application.StartupPath.Remove(49)+"JocEducativ.mdf";
        Inregistrare inregistrare;
        
        public Form1()
        {
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
    }
}
