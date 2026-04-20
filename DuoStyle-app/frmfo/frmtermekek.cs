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
    public partial class frmtermekek : Form
    {
        public frmtermekek()
        {
            InitializeComponent();
            Tablazatfeltoltes();
            txtermekneve.Enabled = false;
            rbuj.Checked = true;
            liarulas.Items.Add("Nem");
            liarulas.Items.Add("Igen");
        }

        private string aktiveSzoveg(object active)
        {

            string status = active.ToString();

            switch (status)
            {
                case "0": return "Nem";
                case "1": return "Igen";
                default: return "Ismeretlen";
            }
        }
        
        void torles()
        {
            txtermekneve.Clear();
            txtermekmeret.Clear();
            txtermekmenny.Clear();
            txtermekar.Clear();
            liarulas.SelectedIndex = -1;
        }

        void Tablazatfeltoltes()
        {
            dgtermekek.Rows.Clear();
            string lekerdezes = "SELECT variant_id, products.pn as pn ,products.name as name , size , stock , price , active from product_variant JOIN products on product_variant.pn = products.pn";
            Adatbazis ab = new Adatbazis(lekerdezes);
            while (ab.Dr.Read())
            {
                string activeText = aktiveSzoveg(ab.Dr["active"]);

                dgtermekek.Rows.Add(

                    ab.Dr["variant_id"],
                    ab.Dr["pn"],
                    ab.Dr["name"],
                    ab.Dr["size"],
                    ab.Dr["stock"],
                    ab.Dr["price"],
                    activeText
                    );
            }
        }

        private void dgtermekek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow sor = dgtermekek.Rows[e.RowIndex];
            if (rbmod.Checked)
            {
                txtermekneve.Text = sor.Cells["name"].Value.ToString();
                txtermekmeret.Text = sor.Cells["size"].Value.ToString();
                txtermekmenny.Text = sor.Cells["stock"].Value.ToString();
                txtermekar.Text = sor.Cells["price"].Value.ToString();
                liarulas.SelectedItem = sor.Cells["active"].Value;
            }
            else
            {
                txtermekneve.Text = sor.Cells["name"].Value.ToString();
            }

        }

        private void btelvet_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos elakkarod vetni a termék módosítását/felvételét?", "KÉRDÉS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btmentes_Click(object sender, EventArgs e)
        {
            if (txtermekneve.TextLength == 0)
            {
                MessageBox.Show("Válasszon termék nevet a megadottakból!", "HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dgtermekek.Focus();
            }
            else if (txtermekmeret.TextLength == 0)
            {
                MessageBox.Show("Adja meg a termék méretét!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtermekmeret.Focus();
            }
            else if (txtermekmenny.TextLength == 0)
            {
                MessageBox.Show("Adja meg a termék elérhető darabszámát!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtermekmenny.Focus();
            }
            else if (txtermekar.TextLength == 0)
            {
                MessageBox.Show("Adja meg a termék árát!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtermekar.Focus();
            }
            else if (!txtermekmeret.Text.Contains("ml") && !txtermekmeret.Text.Contains("g") && !txtermekmeret.Text.Contains("szett") && !txtermekmeret.Text.Contains("filter") && !txtermekmeret.Text.Contains("db"))
            {
                MessageBox.Show("Adjon mértékegységet a terméknek a következők közül (ml, g, szett, filter, db)!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtermekmeret.Focus();
            }
            else if (liarulas.SelectedIndex == -1)
            {
                MessageBox.Show("Válassza ki hogy áruljuk-e!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                liarulas.Focus();
            }
            else 
            {
                if (rbuj.Checked)
                {
                    string pn = dgtermekek.CurrentRow.Cells["pn"].Value.ToString();
                    string lekerdezes =
                        "select count(*) as darab " +
                        "from product_variant " +
                        "where pn = '" + pn + "' " +
                        "and lower(replace(size, ' ', '')) = '" + txtermekmeret.Text.Trim().ToLower().Replace(" ", "") + "'";

                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes =
                            "INSERT INTO product_variant (pn, size, stock, price, active) VALUES (" +
                            "'" + pn + "', " +
                            "'" + txtermekmeret.Text + "', " +
                            "'" + txtermekmenny.Text + "', " +
                            "'" + txtermekar.Text + "', " +
                            "'" + liarulas.SelectedIndex + "')";

                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        ab.lezaras();

                        MessageBox.Show("Sikeres Mentés!", "INFORMÁCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        torles();
                        Tablazatfeltoltes();
                    }
                    else
                    {
                        MessageBox.Show("Ehhez a cikkszámhoz már létezik ez a méret/kiszerelés!",
                                        "FIGYELMEZTETÉS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtermekmeret.Clear();
                        txtermekmeret.Focus();

                    }
                }
                else
                    {
                        string lekerdezes = $"UPDATE product_variant SET size = '{txtermekmeret.Text}', stock = '{txtermekmenny.Text}', price = '{txtermekar.Text}', active = '{(liarulas.SelectedIndex)}' WHERE variant_id = {dgtermekek.CurrentRow.Cells["variant_id"].Value}";
                        Adatbazis ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        MessageBox.Show("Sikeres módosítás!", "INFORMÁCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        torles();
                        Tablazatfeltoltes();
                    }
            }
        }
        private void rbuj_CheckedChanged(object sender, EventArgs e)
        {
            torles();
        }

        private void rbmod_CheckedChanged(object sender, EventArgs e)
        {
            torles();
        }

        private void txprice_TextChanged(object sender, EventArgs e)
        {
            if (txtermekar.TextLength > 0 )
            {
                try
                {
                    int szam = Convert.ToInt32(txtermekar.Text);
                }
                catch
                {
                    MessageBox.Show("A termék ára nem lehet betű!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtermekar.Clear();
                    txtermekar.Focus();
                }
            }
        }
    }
}