using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static frmfo.muveletek;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace frmfo
{
    public partial class frmsajatprofil : Form
    {
        public frmsajatprofil()
        {
            InitializeComponent();
        }
        public int id { get; set; }
        private void frmsajatprofil_Load(object sender, EventArgs e)
        {
            txdolgozonev.Enabled = false;
            rtdolgozoleiras.Enabled = false;
            dtfelvetel.Enabled = false;
            adatfeltoltes();
        }

        void adatfeltoltes()
        {
            string lekerdezes = "select name, email, tel, join_date, description, fav_brand FROM employees WHERE employee_id = '" + id + "';";
            Adatbazis ab = new Adatbazis(lekerdezes);
            while (ab.Dr.Read())
            {
                txdolgozonev.Text = ab.Dr["name"].ToString();
                txdolgozoemail.Text = ab.Dr["email"].ToString();
                txdolgozotel.Text = ab.Dr["tel"].ToString();
                dtfelvetel.Text = ab.Dr["join_date"].ToString();
                rtdolgozoleiras.Text = ab.Dr["description"].ToString();
                txdolgozokedvmarka.Text = ab.Dr["fav_brand"].ToString();
            }
            lbprofilnev.Text = $"{ab.Dr["name"]}";
        }
        private void btkilepes_Click(object sender, EventArgs e)
        {
           
            DialogResult valasz = MessageBox.Show("Biztos elveted a saját profilod szerkesztését?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btmodositas_Click(object sender, EventArgs e)
        {
            if (txdolgozoemail.TextLength == 0 && !Igaziemail(txdolgozoemail.Text))
            {
                MessageBox.Show("Az email cím formátuma nem megfelelő!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txdolgozoemail.Focus();
            }
            else if (txdolgozotel.TextLength == 0)
            {
                MessageBox.Show("Irja be a telefonszámát!", "HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txdolgozotel.Focus();
            }
            else if(!txdolgozotel.Text.Contains("+36"))
            {
                MessageBox.Show("A telefonszáma elején szerepeljen a +36!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txdolgozotel.Focus();
            }
            else if (txdolgozokedvmarka.TextLength == 0)
            {
                MessageBox.Show("Adja meg a kedvenc márkáját","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txdolgozokedvmarka.Focus();
            }
            else
            {
                string lekerdezes = "select count(email) as darab, count(tel) as darabb from employees where email = '" + txdolgozoemail.Text + "' or tel = '" + txdolgozotel.Text + "'";
                Adatbazis ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();
                int db = Convert.ToInt32(ab.Dr["darab"]);
                int dbb = Convert.ToInt32(ab.Dr["darabb"]);
                ab.lezaras();
                if (db == 0 && dbb == 0)
                {
                 lekerdezes = "update employees set email='" + txdolgozoemail.Text + "'" +
                    ",tel='" + txdolgozotel.Text + "',fav_brand='" + txdolgozokedvmarka.Text + "' " +
                    "where employee_id='" + id + "'";
                ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();
                MessageBox.Show("Sikeresen módosította az adatait!", "Sikeres mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(dbb > 0 && db > 0)
                    {
                        MessageBox.Show("A telefonszáma vagy emailja már benne van az adatbázisban forduljon a tulajhoz!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Clear();
                        txdolgozoemail.Clear();
                    }

                }
            }
        }

        private void btjelszovaltoztat_Click(object sender, EventArgs e)
        {
            frmjelszovaltoztat jelszovaltoztat = new frmjelszovaltoztat();
            jelszovaltoztat.ID = id;
            jelszovaltoztat.ShowDialog();
        }
    }
}
