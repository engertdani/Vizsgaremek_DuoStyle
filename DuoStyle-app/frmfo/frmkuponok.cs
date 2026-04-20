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
    public partial class frmkuponok : Form
    {
        public frmkuponok()
        {
            InitializeComponent();
            betoltes();
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos kilépsz a kuponok megtekintéséből?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        void betoltes()
        {
            dgadatok.Rows.Clear();
            string lekerdezes = "select coupons.coupon_code as code, coupons.discount_amount as amount from coupons WHERE coupons.active = 1";
            Adatbazis ab = new Adatbazis(lekerdezes);
            while (ab.Dr.Read())
            {
                dgadatok.Rows.Add(ab.Dr["code"], ab.Dr["amount"]);
            }
        }
    }
}
