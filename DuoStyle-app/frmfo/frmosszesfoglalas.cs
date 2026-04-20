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
    public partial class frmosszesfoglalas : Form
    {
        public frmosszesfoglalas()
        {
            InitializeComponent();
            
        }
        void Tablazatfeltoltes()
        {
            dgadatok.Rows.Clear();

            string keresszoveg = "";
            if (txkereses.TextLength > 0)
            {
                keresszoveg = " AND appointments.appointment_date LIKE '" + txkereses.Text + "%'";
            }

            string aktivszures = "";
            if (cbaktiv.Checked)
            {
                aktivszures =
                    "AND appointments.active <> 0 " +
                    "AND (appointments.appointment_date > CURDATE() " +
                    "OR (appointments.appointment_date = CURDATE() AND appointments.start_time > CURTIME())) ";
            }

            string lekerdezes =
            "SELECT " +
            "appointments.appointment_id AS ID, " +
            "employees.name AS employee_name, " +
            "appointments.appointment_date AS appointment_date, " +
            "appointments.start_time AS start_time, " +
            "appointments.finish_time AS finish_time, " +
            "users.name AS user_name, " +
            "services.name AS service_name, " +
            "appointments.note AS note " +
            "FROM appointments, employees, users, services " +
            "WHERE employees.employee_id = appointments.employee_id " +
            "AND users.user_id = appointments.user_id " +
            "AND services.service_id = appointments.service_id " +
            aktivszures +
            keresszoveg +
            " ORDER BY appointments.appointment_id";

            Adatbazis ab = new Adatbazis(lekerdezes);

            while (ab.Dr.Read())
            {
                DateTime datum = Convert.ToDateTime(ab.Dr["appointment_date"]);

                dgadatok.Rows.Add(
                    ab.Dr["ID"],
                    ab.Dr["employee_name"],
                    datum.ToString("yyyy-MM-dd"),
                    ab.Dr["start_time"],
                    ab.Dr["finish_time"],
                    ab.Dr["user_name"],
                    ab.Dr["service_name"],
                    ab.Dr["note"]
                );
            }
        }
        private void frmosszesfoglalas_Load(object sender, EventArgs e)
        {
            Tablazatfeltoltes();
        }

        private void txkereses_TextChanged(object sender, EventArgs e)
        {
            Tablazatfeltoltes();
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos kilépsz a foglalások áttekintéséből?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void cbaktiv_CheckedChanged(object sender, EventArgs e)
        {
            Tablazatfeltoltes();
        }
    }
}
