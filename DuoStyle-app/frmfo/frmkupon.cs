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
    public partial class frmkupon : Form
    {
        public frmkupon()
        {
            InitializeComponent();
            lbkedvezmeny.Items.Add("5%");
            lbkedvezmeny.Items.Add("10%");
            lbkedvezmeny.Items.Add("15%");
            lbkedvezmeny.Items.Add("20%");
            lbkedvezmeny.Items.Add("25%");
        }

        
        int kedvezmeny = 0;

        void torles()
        {
            txkuponkod.Clear();
            lbkedvezmeny.SelectedIndex = -1;
        }
        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos elveted a kupon felvételét?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btmentes_Click(object sender, EventArgs e)
        {
            if (txkuponkod.TextLength == 0)
            {
                MessageBox.Show("Irja be a kupon kódot!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txkuponkod.Focus();
            }
            else if (lbkedvezmeny.SelectedIndex == -1)
            {
                MessageBox.Show("Válassza ki a kedvezmény mértékét!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string lekerdezes = "select count(coupon_code) as db from coupons where coupon_code = '"+txkuponkod.Text+"'";
                Adatbazis ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();
                int darab = Convert.ToInt32(ab.Dr["db"]);
                ab.lezaras();
                if (darab == 0)
                {
                    lekerdezes = "INSERT INTO `coupons`(`coupon_code`,`discount_amount`) VALUES ('"+txkuponkod.Text+"','"+kedvezmeny+"')";
                    ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    ab.lezaras();
                    MessageBox.Show($"{txkuponkod.Text} nevű 1x használatos kupon létrejött {kedvezmeny} % kedvezményt ad!","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                      torles();
                }
                else
                {
                    MessageBox.Show($"{txkuponkod.Text} Ilyen kupon kódunk már van próbálj egy másikat!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txkuponkod.Clear();
                    txkuponkod.Focus();
                }

            }
        }

        private void lbkedvezmeny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbkedvezmeny.SelectedItem == "5%")
            {
                kedvezmeny = 5;
            }
            else if (lbkedvezmeny.SelectedItem == "10%")
            {
                kedvezmeny = 10;
            }
            else if (lbkedvezmeny.SelectedItem == "15%")
            {
                kedvezmeny = 15;
            }
            else if (lbkedvezmeny.SelectedItem == "20%")
            {
                kedvezmeny = 20;
            }
            else if (lbkedvezmeny.SelectedItem == "25%")
            {
                kedvezmeny = 25;
            }
        }

        private void btkuponok_Click(object sender, EventArgs e)
        {
            frmkuponok kuponok = new frmkuponok();
            kuponok.ShowDialog();
        }
    }
}
