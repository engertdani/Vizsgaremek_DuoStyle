using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmfo
{
    public partial class frmalkkirug : Form
    {
        public frmalkkirug()
        {
            InitializeComponent();
            tablazatbetoltes();
        }
        private void emailKuldes(string toEmail)
        {
          string htmlBody = $@"
                <div style='font-family: ""Segoe UI"", Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #c5a059; border-radius: 4px; background-color: #121212; color: #e0e0e0;'>
                <div style='background: linear-gradient(135deg, #1a1a1a 0%, #000000 100%); color: #c5a059; padding: 30px; text-align: center; border-bottom: 2px solid #c5a059; margin: -20px -20px 20px -20px;'>
                    <h1 style='margin: 0; letter-spacing: 2px; text-transform: uppercase;'>✉️ Tájékoztatás ✉️</h1>
                    <h2 style='margin: 10px 0 0 0; font-weight: 300;'>DuoStyle Szalon</h2>
                </div>

                <p style='font-size: 16px; color: #ffffff;'>
                    <strong>Kedves {dgadatok.CurrentRow.Cells["name"].Value.ToString()}!</strong>
                </p>

                <div style='background: #1d1d1d; padding: 20px; border-left: 4px solid #c5a059; margin: 25px 0; box-shadow: 0 4px 15px rgba(0,0,0,0.5);'>
                    <p style='font-size: 16px; color: #c5a059; margin: 0; line-height: 1.6;'>
                        Ezúton tájékoztatjuk, hogy a mai nappal a <strong>munkaviszonya a DuoStyle szalonban megszűnik</strong>, ezzel párhuzamosan a belső rendszerünkhöz és az alkalmazáshoz való hozzáférése korlátozásra került.
                    </p>
                </div>

                <p style='line-height: 1.6;'>
                    Szeretnénk megköszönni az eddigi munkáját és a szalonunkban töltött időt. Bár szakmai útjaink most elválnak, a jövőben is sok sikert kívánunk Önnek.
                </p>

                <p style='line-height: 1.6; color: #ffffff;'>
                    Fontosnak tartjuk megjegyezni, hogy <strong>vendégként a jövőben is bármikor szívesen látjuk</strong> szalonunkban – a nálunk megszokott prémium szolgáltatásokkal továbbra is állunk rendelkezésére.
                </p>
                
                <hr style='border: none; height: 1px; background: #333; margin: 30px 0;'>

                <p style='font-size: 12px; color: #888; text-align: center; padding: 20px; background: #0a0a0a; border-radius: 4px;'>
                    <em style=""color: #666;"">Ez egy rendszerüzenet, kérjük ne válaszoljon rá.</em><br><br>
                    <strong style=""color: #c5a059;"" >Stílus. Erő. Megújulás.</strong><br>
                    <span style=""font-size: 11px;"">További sok sikert kíván a DuoStyle csapata! ✂️🥃</span>
                </p>
                </div>";
            MailMessage mail = new MailMessage(dgadatok.CurrentRow.Cells["email"].Value.ToString(), toEmail)
            {
                Subject = $"TÁJÉKOZTATÁS JOGVISZONY MEGSZŰNÉSÉRŐL {dgadatok.CurrentRow.Cells["name"].Value.ToString().ToUpper()} részére - DuoStyle",
                Body = htmlBody,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("engertmohamed@gmail.com", "wyzkngivbhavvdfu");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        void tablazatbetoltes()
        {
            dgadatok.Rows.Clear();
            string keresesszoveg = "";
            if (txkereses.TextLength > 0)
            {
                keresesszoveg = "and name like '%"+txkereses.Text+"%'";
            }
            string lekerdezes = "select employee_id as ID, name, email, tel,join_date, description, fav_brand from employees where admin = 0 and active = 1 "+keresesszoveg+";";
            Adatbazis ab = new Adatbazis(lekerdezes);
            while (ab.Dr.Read())
            {
                DateTime datum = Convert.ToDateTime(ab.Dr["join_date"]);
                dgadatok.Rows.Add(ab.Dr["ID"], ab.Dr["name"], ab.Dr["email"], ab.Dr["tel"] ,datum.ToString("yyyy-MM-dd"), ab.Dr["description"], ab.Dr["fav_brand"]);
            }
        }

        private void btkirugas_Click(object sender, EventArgs e)
        {
            if (dgadatok.CurrentRow == null)
            {
                MessageBox.Show("Válasszon ki egy alkalmazotatt elbocsájtás előtt!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                TimeSpan kulonbseg = DateTime.Now - Convert.ToDateTime(dgadatok.CurrentRow.Cells["join_date"].Value);
                int napokSzama = kulonbseg.Days;

                DialogResult valasz = MessageBox.Show($"Biztosan elbocsájtod {dgadatok.CurrentRow.Cells["name"].Value.ToString()}-ot/et aki {napokSzama} napja dolgozik itt?", "KÉRDÉS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (valasz == DialogResult.Yes)
                {
                    string lekerdezes = "UPDATE employees SET active = 0 WHERE employee_id = '" + dgadatok.CurrentRow.Cells["ID"].Value.ToString() + "'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    emailKuldes(dgadatok.CurrentRow.Cells["email"].Value.ToString());
                    MessageBox.Show($"Sikeresen elbocsájtottad {dgadatok.CurrentRow.Cells["name"].Value.ToString()}-ot/et!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tablazatbetoltes();
                }
            }
        }

        private void txkereses_TextChanged(object sender, EventArgs e)
        {
            tablazatbetoltes();
        }

        private void btelvet_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos elveted az alkalmazott elbocsájtását?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
