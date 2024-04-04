using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class AlegeJoc : Form
    {
        String username, email;
        public AlegeJoc(String username, String email)
        {
            InitializeComponent();
            this.username = username;
            this.email = email;
            label1.Text = "Bine ai venit, " + username + "! (" + email + ")";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemGame memGame = new MemGame(username, email);
            memGame.Show();
            memGame.Closed += (s, args) => this.Close();
            this.Hide();
        }

        private void AlegeJoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'jocEducativDataSet.Rezultate' table. You can move, or remove it, as needed.
            this.rezultateTableAdapter.Fill(this.jocEducativDataSet.Rezultate);

        }
    }
}