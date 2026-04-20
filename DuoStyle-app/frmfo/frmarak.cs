using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmfo
{
    public partial class frmarak : Form
    {
        public int id { get; set; }
        public frmarak()
        {
            InitializeComponent();
            txhossz.Enabled = false;
        }
        List<int> service_id = new List<int>();
        List<string> nevek = new List<string>();
        List<string> idok = new List<string>();

        void listaFeltolt()
        {
            lbszolgalgatasok.Items.Clear();
            service_id.Clear();
            nevek.Clear();
            idok.Clear();

            string lekerdezes = "SELECT service_id ,name, duration FROM services WHERE salon_id = (SELECT salon_id FROM employees WHERE employee_id = '" + id + "')";
            Adatbazis ab = new Adatbazis(lekerdezes);

            while (ab.Dr.Read())
            {
                int serviceindex = Convert.ToInt32(ab.Dr["service_id"].ToString());
                string nev = ab.Dr["name"].ToString();
                string ido = ab.Dr["duration"].ToString();

                service_id.Add(serviceindex);
                nevek.Add(nev);
                idok.Add(ido);

                lbszolgalgatasok.Items.Add(nev);
            }
        }

        private void frmarak_Load(object sender, EventArgs e)
        {

            listaFeltolt();
        }

        void torles()
        {
            txhossz.Clear();
            txara.Clear();
            lbszolgalgatasok.SelectedIndex = -1;
        }

        private void lbszolgalgatasok_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbszolgalgatasok.SelectedIndex;

            if (index != -1)
            {
                txhossz.Text = idok[index];
            }
        }

        private void btelvet_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos elveted áraid megadását?","KÉRDÉS",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btment_Click(object sender, EventArgs e)
        {
            if (lbszolgalgatasok.SelectedIndex == -1)
            {
                MessageBox.Show("Kérlek válaszd ki a szolgáltatást aminek árat akkarsz adni!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lbszolgalgatasok.Focus();
            }
            else if(txara.TextLength == 0)
            {
                MessageBox.Show("Kérlek add meg a szolgáltatás árát!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txara.Focus();
            }
            else
            {
                string lekerdezes = "SELECT COUNT(*) as db FROM prices WHERE employee_id = '" + id + "' AND service_id = '" + service_id[lbszolgalgatasok.SelectedIndex] + "'";
                Adatbazis ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();
                int darab = Convert.ToInt32(ab.Dr["db"]);
                ab.lezaras();

                if (darab > 0)
                {
                    lekerdezes = "SELECT price FROM prices WHERE employee_id = '" + id + "' AND service_id = '" + service_id[lbszolgalgatasok.SelectedIndex] + "'";
                    ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int ar = Convert.ToInt32(ab.Dr["price"]);
                    ab.lezaras();

                    DialogResult valasz = MessageBox.Show(
                        $"Erre a szolgáltatásra már van egy beállitott árad ami {ar} Ft biztos megváltoztatod?",
                        "KÉRDÉS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (valasz == DialogResult.Yes)
                    {
                        lekerdezes = "UPDATE prices SET price = '" + txara.Text + "' WHERE employee_id = '" + id + "' AND service_id = '" + service_id[lbszolgalgatasok.SelectedIndex] + "'";
                        ab = new Adatbazis(lekerdezes);
                        MessageBox.Show("Sikeresen elmentetted az új árat!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    lekerdezes = "INSERT INTO prices (employee_id, service_id, price) VALUES ('" + id + "', '" + service_id[lbszolgalgatasok.SelectedIndex] + "', '" + txara.Text + "')";
                    ab = new Adatbazis(lekerdezes);
                    MessageBox.Show("Sikeresen elmentetted az árat!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                torles();
            }
        }

        private void txara_TextChanged(object sender, EventArgs e)
        {
            if (txara.TextLength > 0)
            {
                try
                {
                    int szam = Convert.ToInt32(txara.Text);
                }
                catch
                {
                    MessageBox.Show("A szolgáltatás ára nem lehet betű!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txara.Clear();
                    txara.Focus();
                }
            }
        }
    }
}
