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

namespace Atestat
{
    public partial class Inregistrare : Form
    {
        SqlConnection con;
        public Inregistrare(SqlConnection con)
        {
            InitializeComponent();
            textBox3.PasswordChar = '*';
            this.con = con;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Utilizatori WHERE EmailUtilizator='"+textBox1.Text+"' OR NumeUtilizator ='"+textBox2.Text+"'");
            sqlCommand.Connection = con;
            con.Open();
            if(sqlCommand.ExecuteReader().Read())
            {
                MessageBox.Show("Email sau Utilizator deja ocupat");
            }
            else
            {
                con.Close();
                con.Open();

                sqlCommand = new SqlCommand("INSERT INTO Utilizatori (EmailUtilizator, NumeUtilizator, Parola) VALUES (@email, @nume, @pass)");
                sqlCommand.Parameters.AddWithValue("@email", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@pass", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@nume", textBox2.Text);
                sqlCommand.Connection = con;
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Account created!");
                textBox1.Text = string.Empty; textBox3.Text = string.Empty; textBox2.Text = string.Empty;
                this.Hide();
            }
            con.Close();
        }
    }
}
