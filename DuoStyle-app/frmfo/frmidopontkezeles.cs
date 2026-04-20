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
    public partial class frmidopontkezeles : Form
    {
        public frmidopontkezeles()
        {
            InitializeComponent();
        }
        public int id { get; set; }

        private void emailKuldes(string toEmail)
        {
            string htmlBody = $@"
            <div style='font-family: ""Segoe UI"", Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #c5a059; border-radius: 4px; background-color: #121212; color: #e0e0e0;'>
                <div style='background: linear-gradient(135deg, #1a1a1a 0%, #000000 100%); color: #c5a059; padding: 30px; text-align: center; border-bottom: 2px solid #c5a059; margin: -20px -20px 20px -20px;'>
                    <h1 style='margin: 0; letter-spacing: 2px; text-transform: uppercase;'>📅 Időpont Lemondás</h1>
                    <h2 style='margin: 10px 0 0 0; font-weight: 300;'>DuoStyle Szalon</h2>
                </div>
            
                <p style='font-size: 16px; color: #ffffff;'> <strong>Kedves {dgadatok.CurrentRow.Cells["user_name"].Value.ToString()}!</strong> </p>
            
                <div style='background: #1d1d1d; padding: 20px; border-left: 4px solid #c5a059; margin: 25px 0; box-shadow: 0 4px 15px rgba(0,0,0,0.5);'>
                    <p style='font-size: 18px; color: #c5a059; margin: 0; line-height: 1.5;'> 
                        <strong>Sajnálattal értesítjük, hogy a <span style=""color: #ffffff;"">{dgadatok.CurrentRow.Cells["appointment_date"].Value.ToString()}</span> napon, <span style=""color: #ffffff;"">{dgadatok.CurrentRow.Cells["start_time"].Value.ToString()}</span>-ra/re tervezett időpontja lemondásra került.</strong> 
                    </p>
                </div>
            
                <p style='line-height: 1.6;'>Sajnáljuk a kellemetlenséget! Amennyiben szeretne új időpontot foglalni, kérjük, kattintson az alábbi gombra:</p>

                <div style='text-align: center; margin: 30px 0;'>
                    <a href='http://127.0.0.1:8000/' style='background-color: #c5a059; color: #121212; padding: 12px 25px; text-decoration: none; font-weight: bold; border-radius: 4px; display: inline-block; text-transform: uppercase; font-size: 14px;'>Új időpont foglalása</a>
                </div>

                <p style='line-height: 1.6;'>Vagy vegye fel velünk a kapcsolatot telefonon. Reméljük, hamarosan újra a vendégeink között köszönthetjük!</p>

                <hr style='border: none; height: 1px; background: #333; margin: 30px 0;'>
            
                <div style='font-size: 12px; color: #888; text-align: center; padding: 20px; background: #0a0a0a; border-radius: 4px;'>
                    <em style=""color: #666;"">⚠️ Ez egy automatikus rendszerüzenet. Kérjük, ne válaszoljon rá közvetlenül.</em><br><br>
                    <strong style=""color: #c5a059;"">Stílus. Erő. Megújulás.</strong><br>
                    <span style=""font-size: 11px;"">Várjuk mielőbbi visszatérését: DuoStyle csapata! ✂️🥃</span>
                </div>
            </div>";

            MailMessage mail = new MailMessage(dgadatok.CurrentRow.Cells["user_email"].Value.ToString(), toEmail)
            {
                Subject = $"📅 IDŐPONT LEMONDÁS - {dgadatok.CurrentRow.Cells["appointment_date"].Value.ToString()}-{dgadatok.CurrentRow.Cells["start_time"].Value.ToString()}",
                Body = htmlBody,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("engertmohamed@gmail.com", "wyzkngivbhavvdfu");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        void Tablazatfeltoltes()
        {
            dgadatok.Rows.Clear();

            string keresszoveg = "";
            if (txkereses.TextLength > 0)
            {
                keresszoveg = " AND appointments.appointment_date LIKE '" + txkereses.Text + "%'";
            }

            string lekerdezes =
            "SELECT " +
            "appointments.appointment_id AS ID, " +
            "employees.name AS employee_name, " +
            "appointments.appointment_date AS appointment_date, " +
            "appointments.start_time AS start_time, " +
            "appointments.finish_time AS finish_time, " +
            "users.name AS user_name, " +
            "users.email as user_email," +
            "services.name AS service_name, " +
            "appointments.note AS note " +
            "FROM appointments, employees, users, services " +
            "WHERE employees.employee_id = appointments.employee_id " +
            "AND users.user_id = appointments.user_id " +
            "AND services.service_id = appointments.service_id " +
            "AND appointments.active <> 0 " +
            "AND (appointments.appointment_date > CURDATE() " +
                "OR (appointments.appointment_date = CURDATE() AND appointments.start_time > CURTIME())) " +
            keresszoveg +
            " ORDER BY appointments.appointment_id";

            Adatbazis ab = new Adatbazis(lekerdezes);

            while (ab.Dr.Read())
            {
                DateTime datum = Convert.ToDateTime(ab.Dr["appointment_date"]);
                TimeSpan kezdes = (TimeSpan)ab.Dr["start_time"];
                TimeSpan befejezes = (TimeSpan)ab.Dr["finish_time"];

                dgadatok.Rows.Add(
                    ab.Dr["ID"],
                    ab.Dr["user_email"],
                    ab.Dr["employee_name"],
                    datum.ToString("yyyy-MM-dd"),
                    kezdes.ToString(@"hh\:mm"),
                    befejezes.ToString(@"hh\:mm"),
                    ab.Dr["user_name"],
                    ab.Dr["service_name"],
                    ab.Dr["note"]
                );
            }
        }

        private void btlemondva_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show($"Biztos lemondod {dgadatok.CurrentRow.Cells["user_name"].Value.ToString()} időpontját?", "KÉRDÉS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (valasz == DialogResult.Yes)
            {
                if (dgadatok.CurrentRow == null)
                {
                    MessageBox.Show("Válassz ki egy időpontot a táblázatból!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int kivalasztottId = Convert.ToInt32(dgadatok.CurrentRow.Cells["ID"].Value);

                string lekerdezes = "UPDATE appointments SET active = '" + 0 + "' WHERE appointment_id = '" + kivalasztottId + "'";
                Adatbazis ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();
                emailKuldes(dgadatok.CurrentRow.Cells["user_email"].Value.ToString());
                MessageBox.Show($"A időpontja {dgadatok.CurrentRow.Cells["user_name"].Value.ToString()}-nak/nek lelett mondva!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tablazatfeltoltes();
            }
        }


        private void frmidopontkezeles_Load(object sender, EventArgs e)
        {
            Tablazatfeltoltes();
        }

        private void txkereses_TextChanged(object sender, EventArgs e)
        {
            Tablazatfeltoltes();
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos elveted az időpontjaid kezelését?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

    }
}