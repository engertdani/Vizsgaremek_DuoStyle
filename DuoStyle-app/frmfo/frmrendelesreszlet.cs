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

namespace frmfo
{
    public partial class frmrendelesreszlet : Form
    {
        public frmrendelesreszlet()
        {
            InitializeComponent();

        }
        public int orderId { get; set; }
        public string name { get; set; }

        void betoltes()
        {
            dgadatok.Rows.Clear();

            string lekerdezes = "SELECT `order`.order_id as order_id, `users`.email as email, products.name as product_name, product_variant.size as size, order_products.quantity as quantity FROM `order`, order_products, addresses, users, product_variant, products  WHERE addresses.address_id = `order`.address_id AND `order`.order_id = order_products.order_id AND `order`.user_id = users.user_id AND order_products.variant_id = product_variant.variant_id AND products.pn = product_variant.pn and `order`.order_id = "+orderId+" ORDER BY `order`.`ordered_at` ASC; ";
            Adatbazis ab = new Adatbazis(lekerdezes);
            while (ab.Dr.Read())
            {
                dgadatok.Rows.Add(
                    ab.Dr["order_id"],
                    ab.Dr["email"],
                    ab.Dr["product_name"],
                    ab.Dr["size"],
                    ab.Dr["quantity"]
                );
            }
        }
        
        private void frmrendelesreszlet_Load(object sender, EventArgs e)
        {
            this.Text = $"{name} rendelése";
            betoltes();
        }

        private void emailKuldes(string toEmail)
        {
            string varhatoErkezes = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");

            string htmlBody = $@"
            <div style='font-family: ""Segoe UI"", Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #c5a059; border-radius: 4px; background-color: #121212; color: #e0e0e0;'>
            <div style='background: linear-gradient(135deg, #1a1a1a 0%, #000000 100%); color: #c5a059; padding: 30px; text-align: center; border-bottom: 2px solid #c5a059; margin: -20px -20px 20px -20px;'>
            <h1 style='margin: 0; letter-spacing: 2px; text-transform: uppercase;'>📦 Csomag Értesítő 📦</h1>
            <h2 style='margin: 10px 0 0 0; font-weight: 300;'>DuoStyle Szalon</h2>
            </div>

            <p style='font-size: 16px; color: #ffffff;'>
            <strong>Kedves {name}!</strong>
             </p>

             <div style='background: #1d1d1d; padding: 20px; border-left: 4px solid #c5a059; margin: 25px 0; box-shadow: 0 4px 15px rgba(0,0,0,0.5);'>
            <p style='font-size: 18px; color: #c5a059; margin: 0; line-height: 1.5;'>
            <strong>✨ Örömmel értesítjük, hogy csomagját feladtuk és hamarosan megérkezik Önhöz!</strong>
            </p>
            </div>

            <p style='line-height: 1.6;'>Rendelése úton van! Csomagja a várható érkezési időn belül kézbesítésre kerül. Kérjük, legyen elérhető a megadott szállítási címen.</p>

            <div style='background: #1d1d1d; padding: 15px 20px; border-radius: 4px; margin: 20px 0;'>
             <p style='margin: 0; color: #e0e0e0;'>🗓️ <strong style='color: #c5a059;'>Várható érkezési dátum:</strong> <span style='color: #ffffff;'>{varhatoErkezes}</  span></p>
            </div>
     
            <hr style='border: none; height: 1px; background: #333; margin: 30px 0;'>
     
            <p style='font-size: 12px; color: #888; text-align: center; padding: 20px; background: #0a0a0a; border-radius: 4px;'>
                <em style=""color: #666;"">⚠️ Ha Önt nem érinti ez az e-mail, kérjük, hagyja figyelmen kívül!</em><br><br>
                <strong style=""color: #c5a059;"">Stílus. Erő. Megújulás.</strong><br>
                <span style=""font-size: 11px;"">További szép napot kíván a DuoStyle csapata! ✂️🥃</span>
            </p>
            </div>";

            MailMessage mail = new MailMessage(dgadatok.CurrentRow.Cells["email"].Value.ToString(), toEmail)
            {
                Subject = $"Rendelés feladva - {name.ToUpper()}",
                Body = htmlBody,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("engertmohamed@gmail.com", "wyzkngivbhavvdfu");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos kilépsz a rendelések áttekintéséből?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btkesz_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show($"Biztosan elkészítetted {name}-nak/nek a rendelését?", "KÉRDÉS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (valasz == DialogResult.Yes)
            {
                string lekerdezes = "UPDATE `order` SET `order_sent`= 1 WHERE order_id = '" + orderId + "'";
                Adatbazis ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();
                emailKuldes(dgadatok.CurrentRow.Cells["email"].Value.ToString());
                MessageBox.Show("Sikeresen lezárta a rendelést!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
