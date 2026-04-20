using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static frmfo.muveletek;
using System.Windows.Forms;

namespace frmfo
{
    public partial class frmfo : Form
    {
        public frmfo()
        {
            InitializeComponent();
        }

        private void btbejelentkezes_Click(object sender, EventArgs e)
        {
            if (txemail.TextLength == 0)
            {
                MessageBox.Show("Kérlek írd be a profilodhoz tartozó email-t!", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txjelszo.TextLength == 0)
            {
                MessageBox.Show("Kérlek írd be a profilodhoz tartozó jelszót!", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txjelszo.Focus();
            }
            else if (txemail.TextLength == 0 && txjelszo.TextLength == 0)
            {
                MessageBox.Show("Kérlek írd be a profilodhoz tartozó email és jelszó párost!", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string lekerdezes ="SELECT employee_id AS id, email, `password`, admin, active " +
                 "FROM employees WHERE email = '" + txemail.Text + "'";
                Adatbazis ab = new Adatbazis(lekerdezes);
                if (ab.Dr.Read())
                {
                    int id = Convert.ToInt32(ab.Dr["id"]);
                    int active = Convert.ToInt32(ab.Dr["active"]);
                    string email = ab.Dr["email"].ToString();
                    string jelszo = ab.Dr["password"].ToString();
                    int admin = Convert.ToInt32(ab.Dr["admin"]);

                    if (HashPassword(txjelszo.Text) != jelszo)
                    {
                        MessageBox.Show(
                            "A jelszó nem megfelelő!",
                            "HIBA",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                         txjelszo.Clear();
                         txjelszo.Focus();
                    }
                    else if (active == 0)
                    {
                        MessageBox.Show("A profilod jelenleg inaktív! Kérlek vedd fel a kapcsolatot a rendszergazdával!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         txemail.Clear();
                         txjelszo.Clear();
                         txemail.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Sikeres bejelentkezés!","ÜZENET",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        if (admin == 1)
                        {

                            frmmuveletekadmin frmadminmuvelet = new frmmuveletekadmin();
                            frmadminmuvelet.employeeid = id;
                            this.Visible = false;
                            frmadminmuvelet.ShowDialog();
                            this.Visible = true;
                        }
                        else
                        {

                            frmmuveletek frmdolgozomuveletek = new frmmuveletek();
                            frmdolgozomuveletek.employeeid = id;
                            this.Visible = false;
                            frmdolgozomuveletek.ShowDialog();
                            this.Visible = true;
                        }
                         txemail.Clear();
                         txjelszo.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Az email cím nem található a rendszerben!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                     txemail.Clear();
                     txjelszo.Clear();
                     txemail.Focus();
                }
                ab.lezaras();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txjelszo.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos leállitod az alkalmazást?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
