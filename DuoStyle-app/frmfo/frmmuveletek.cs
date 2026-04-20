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
    public partial class frmmuveletek : Form
    {
        public frmmuveletek()
        {
            InitializeComponent();
        }
        public int employeeid { get; set; }

        private void btsajatprof_Click(object sender, EventArgs e)
        {
            frmsajatprofil sajatprofil = new frmsajatprofil();
            sajatprofil.id = employeeid;
            sajatprofil.ShowDialog();
        }


        private void btidopontkez_Click(object sender, EventArgs e)
        {
            frmidopontkezeles idopontkezeles = new frmidopontkezeles();
            idopontkezeles.id = employeeid;
            idopontkezeles.ShowDialog();
        }

        private void btmunkaidokez_Click(object sender, EventArgs e)
        {
            frmmunkaidokezeles munkaidokezeles = new frmmunkaidokezeles();
            munkaidokezeles.id = employeeid;
            munkaidokezeles.ShowDialog();
        }

        private void btkijelentkezes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos kijelentkezel az alkalmazásból?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btarak_Click(object sender, EventArgs e)
        {
            frmarak arakmegadasa = new frmarak();
            arakmegadasa.id = employeeid;
            arakmegadasa.ShowDialog();
        }

        private void btkupon_Click(object sender, EventArgs e)
        {
            frmkupon kupon = new frmkupon();
            kupon.ShowDialog();
        }
    }
}
