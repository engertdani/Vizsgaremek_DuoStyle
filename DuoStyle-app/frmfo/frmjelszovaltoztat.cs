using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static frmfo.muveletek;
using System.Windows.Forms;

namespace frmfo
{
    public partial class frmjelszovaltoztat : Form
    {
        public frmjelszovaltoztat()
        {
            InitializeComponent();
        }
        public int ID { get; set; }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos elveted a jelszód megváltoztatását?","KÉRDÉS",MessageBoxButtons.OK,MessageBoxIcon.Question);
            this.Close();
        }

        private void btfelvetel_Click(object sender, EventArgs e)
        {
            string lekerdezes = "SELECT password FROM employees WHERE employee_id = '"+ID+"'";
            Adatbazis ab = new Adatbazis(lekerdezes);
            if (ab.Dr.Read())
            {
                string elozojelszo = ab.Dr["password"].ToString();
                if (txjelszomost.TextLength == 0)
                {
                    MessageBox.Show("A mostani jelszavának jelszó mezeje üres!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txjelszomost.Focus();
                }
                else if (HashPassword(txjelszomost.Text) != elozojelszo)
                {
                    MessageBox.Show("Nem találta el a mostani jelszavát próbálja meg újra!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txjelszomost.Focus();
                }
                else if (txjelszo.TextLength == 0)
                {
                    MessageBox.Show("Az új jelszó mező üres!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txjelszo.Focus();
                }
                else if (txjelszoujra.TextLength == 0)
                {
                    MessageBox.Show("Írja be mégegyszer a jelszavát!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txjelszoujra.Focus();
                }
                else if (txjelszo.Text != txjelszoujra.Text)
                {
                    MessageBox.Show("A két jelszava nem eggyezik", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txjelszoujra.Focus();
                    txjelszoujra.Clear();
                }
                else if (txjelszomost.Text == txjelszo.Text)
                {
                    MessageBox.Show("A régi jelszavát nem lehet az új!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txjelszo.Focus();
                    txjelszo.Clear();
                    txjelszoujra.Clear();
                }
                else
                {
                    string Hasheltjelszo = HashPassword(txjelszo.Text);
                    lekerdezes = "UPDATE employees SET password = '" + Hasheltjelszo + "' WHERE employee_id = '" + ID + "'";
                    ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    MessageBox.Show("Sikeresen elmentetted a jelszavadat!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txjelszomost.UseSystemPasswordChar = !checkBox1.Checked;
            txjelszo.UseSystemPasswordChar = !checkBox1.Checked;
            txjelszoujra.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
