using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static frmfo.muveletek;
using System.Windows.Forms;

namespace frmfo
{
    public partial class frmjelszomegadas : Form
    {
        public frmjelszomegadas()
        {
            InitializeComponent();
            MessageBox.Show("Kérem adja át a felvenni kivánt dolgozónak hogy ő irja be a saját email-ját és jelszavát!","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public string VisszaEmail { get; private set; }
        public string VisszaJelszo { get; private set; }

        private void btfelvetel_Click(object sender, EventArgs e)
        {
            if (txemail.TextLength == 0)
            {
                MessageBox.Show("Az email mező üres!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txjelszo.TextLength == 0)
            {
                MessageBox.Show("A jelszó mező üres!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txjelszoujra.TextLength == 0)
            {
                MessageBox.Show("A jelszó újra mező üres!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txjelszo.Text != txjelszoujra.Text)
            {
                MessageBox.Show("A két jelszava nem eggyezik","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txjelszoujra.Focus();
                txjelszoujra.Clear();
            }
            else if(!Igaziemail(txemail.Text))
            {
                MessageBox.Show("Az email nem felel meg a követelményeknek!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txemail.Focus();
                txemail.Clear();
            }
            else
            {
                string lekerdezes = "select count(email) as darab from employees where email = '"+txemail.Text+"'";
                Adatbazis ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();
                int darab = Convert.ToInt32(ab.Dr["darab"]);
                if (darab == 0)
                {
                    VisszaEmail = txemail.Text.Trim();
                    VisszaJelszo = HashPassword(txjelszo.Text);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ez az email már foglalt!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txemail.Clear();
                    txemail.Focus();
                }
                
            }
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Bizots elveted az jelszó megadását?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (valasz == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txjelszo.UseSystemPasswordChar = !checkBox1.Checked;
            txjelszoujra.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
