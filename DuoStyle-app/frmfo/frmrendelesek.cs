using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace frmfo
{
    public partial class frmrendelesek : Form
    {
        public frmrendelesek()
        {
            InitializeComponent();
            betoltes();

        }

        void betoltes()
        {
            dgadatok.Rows.Clear();

            string lekerdezes ="SELECT distinct `order`.order_id as order_id, `users`.email as email, `users`.name as user_name, addresses.city as city, addresses.zip_code as zip_code, addresses.street as street, coupon_code, `order`.total_amount as total_amount, `order`.note as note, `order`.`ordered_at` as ordered_at FROM `order`, order_products, addresses, users  WHERE addresses.address_id = `order`.address_id AND `order`.order_id = order_products.order_id AND `order`.user_id = users.user_id and `order`.order_sent <> 1 ORDER BY `order`.`ordered_at` ASC; ";
            Adatbazis ab = new Adatbazis(lekerdezes);
            while (ab.Dr.Read())
            {
                DateTime datum = Convert.ToDateTime(ab.Dr["ordered_at"]);

                string kupon = Convert.ToString(ab.Dr["coupon_code"]);
                if (kupon == "") kupon = "Nincs kupon";

                string megjegyzes = Convert.ToString(ab.Dr["note"]);
                if (megjegyzes == "") megjegyzes = "Nincs megjegyzés";

                dgadatok.Rows.Add(
                    ab.Dr["order_id"],
                    ab.Dr["user_name"],
                    ab.Dr["zip_code"],
                    ab.Dr["city"],
                    ab.Dr["street"],
                    kupon,
                    ab.Dr["total_amount"],
                    megjegyzes,
                    datum.ToString("yyyy-MM-dd")
                );
            }
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos kilépsz a rendelések áttekintéséből?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }


        private void dgadatok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmrendelesreszlet reszlet = new frmrendelesreszlet();
            reszlet.orderId = Convert.ToInt32(dgadatok.CurrentRow.Cells["order_id"].Value);
            reszlet.name = Convert.ToString(dgadatok.CurrentRow.Cells["user_name"].Value);
            reszlet.ShowDialog();
            betoltes();

        }
    }
}
