using Org.BouncyCastle.Asn1.Cms;
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
    public partial class frmmunkaidokezeles : Form
    {
        public frmmunkaidokezeles()
        {
            InitializeComponent();
        }
        public int id { get; set; }

        void frissitMunkaIdo()
        {
            if (!munkaIdoHelyes())
            {
                lbmunkaido.Text = "Számolt munka időd: ";
                return;
            }

            lbmunkaido.Text = "Számolt munka időd: " +
                szamoltMunkaIdo().ToString(@"hh\:mm") + " óra";
        }

        bool munkaIdoHelyes()
        {
            TimeSpan kezdet = dtmunkakezd.Value.TimeOfDay;
            TimeSpan vege = dtmunkaveg.Value.TimeOfDay;
            
            string lekerdezes = "select open_time as nyitas, close_time as zaras from employees, salons where employees.salon_id = salons.salon_id and employees.employee_id = '"+id+"'";
            Adatbazis ab = new Adatbazis(lekerdezes);
            ab.Dr.Read();
            
            TimeSpan nyitas = (TimeSpan)ab.Dr["nyitas"];
            TimeSpan zaras = (TimeSpan)ab.Dr["zaras"];
        
            if (vege <= kezdet)
            {
                MessageBox.Show("A munkaidő vége később kell legyen, mint a kezdete!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
                dtmunkakezd.Value = DateTime.Today.AddHours(9);
                dtmunkaveg.Value = DateTime.Today.AddHours(17);
                return false;
            }
            else if (kezdet < nyitas)
            {
                MessageBox.Show("A munkaidő nem kezdődhet a szalon nyitása előtt!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
                dtmunkakezd.Value = DateTime.Today.AddHours(9);
                dtmunkaveg.Value = DateTime.Today.AddHours(17);
                return false;
            }
            else if (vege > zaras)
            {
                MessageBox.Show("A munkaidő nem tarthat a szalon zárása után!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
                dtmunkakezd.Value = DateTime.Today.AddHours(9);
                dtmunkaveg.Value = DateTime.Today.AddHours(17);
                return false;
            }
        
            return true;
        }


        TimeSpan szamoltMunkaIdo()
        {
            TimeSpan kezdet = dtmunkakezd.Value.TimeOfDay;
            TimeSpan vege = dtmunkaveg.Value.TimeOfDay;

            if (vege < kezdet) 
            { 
                return (TimeSpan.FromHours(24) - kezdet) + vege;
            } 
                return vege - kezdet;
        }
        


        private void frmmunkaidokezeles_Load(object sender, EventArgs e)
        {
            dtmunkakezd.ShowUpDown = true;
            dtmunkaveg.ShowUpDown = true;

            dtmunkakezd.Value = DateTime.Today.AddHours(9);
            dtmunkaveg.Value = DateTime.Today.AddHours(17);
        }

        private void dtdatum_ValueChanged(object sender, EventArgs e)
        {
            if (dtdatum.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Csak jövőbeli dátum választható!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtdatum.Value = DateTime.Today;
            }
        }
        private void dtmunkaveg_ValueChanged(object sender, EventArgs e)
        {
            frissitMunkaIdo();
        }

        private void dtmunkakezd_ValueChanged(object sender, EventArgs e)
        {
            frissitMunkaIdo();
        }

        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos elveted a munka időd megadását?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btmentes_Click(object sender, EventArgs e)
        {
            DateTime datum = dtdatum.Value;

            string lekerdezes = "select count(*) as db, start_time as kezdes, end_time as vegzes from shifts WHERE employee_id = '" + id + "' " +
                "and shift_date = '" + datum.ToString("yyyy-MM-dd") + "'";

            Adatbazis ab = new Adatbazis(lekerdezes);
            ab.Dr.Read();

            int darab = Convert.ToInt32(ab.Dr["db"]);

            if (darab > 0)
            {
                TimeSpan kezdes = (TimeSpan)ab.Dr["kezdes"];
                TimeSpan vegzes = (TimeSpan)ab.Dr["vegzes"];

                DialogResult valasz = MessageBox.Show(
                    $"Ezen a napon már rögzítve van a munkaidőd {kezdes:hh\\:mm\\:ss}-től {vegzes:hh\\:mm\\:ss}-ig.\n" +
                    "Biztos meg szeretnéd változtatni?",
                    "KÉRDÉS",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (valasz == DialogResult.Yes)
                {
                    lekerdezes = "update shifts " +
                        "set start_time = '" + dtmunkakezd.Value.ToString("HH:mm:ss") + "'" +
                        ", end_time = '" + dtmunkaveg.Value.ToString("HH:mm:ss") + 
                        "' WHERE employee_id = '" + id + "' " +
                        "and shift_date = '" + datum.ToString("yyyy-MM-dd") + "'";
                    ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    MessageBox.Show("Munkaidő sikeresen elmentve!",
                         "INFO",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }
            }
            else
            {
                lekerdezes =
                    "insert into shifts (employee_id, shift_date, start_time, end_time) " +
                    "values (" +
                    "'" + id + "', " +
                    "'" + datum.ToString("yyyy-MM-dd") + "', " +
                    "'" + dtmunkakezd.Value.ToString("HH:mm:ss") + "', " +
                    "'" + dtmunkaveg.Value.ToString("HH:mm:ss") + "')";
                ab = new Adatbazis(lekerdezes);
                ab.Dr.Read();

                MessageBox.Show("Munkaidő sikeresen elmentve!",
                    "INFO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            dtdatum.Value = DateTime.Today;
            dtmunkakezd.Value = DateTime.Today.AddHours(9);
            dtmunkaveg.Value = DateTime.Today.AddHours(17);
        }
    }
}