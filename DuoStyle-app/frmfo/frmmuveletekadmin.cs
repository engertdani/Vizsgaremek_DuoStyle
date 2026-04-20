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
    public partial class frmmuveletekadmin : Form
    {
        public frmmuveletekadmin()
        {
            InitializeComponent();
        }
        public int employeeid { get; set; }
        
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

        private void btsajatprof_Click(object sender, EventArgs e)
        {
            frmsajatprofil sajatprofil = new frmsajatprofil();
            sajatprofil.id = employeeid;
            sajatprofil.ShowDialog();
        }

        private void btdolgozofel_Click(object sender, EventArgs e)
        {
            frmdolgozofelvetel dolgozofelvetele = new frmdolgozofelvetel();
            dolgozofelvetele.ShowDialog();
        }

        private void btosszfog_Click(object sender, EventArgs e)
        {
            frmosszesfoglalas osszesfoglalas = new frmosszesfoglalas();
            osszesfoglalas.ShowDialog();
        }

        private void btkijelentkezes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztos kijelentkezel az alkalmazásból?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }
        private void txtermekek_Click(object sender, EventArgs e)
        {
            frmtermekek termekek = new frmtermekek();
            termekek.ShowDialog();
        }

        private void btalkkirug_Click(object sender, EventArgs e)
        {
            frmalkkirug alkalmazottkirugasa = new frmalkkirug();
            alkalmazottkirugasa.ShowDialog();
        }

        private void btarakmeg_Click(object sender, EventArgs e)
        {
            frmarak arak = new frmarak();
            arak.id = employeeid;
            arak.ShowDialog();
        }

        private void btkupon_Click(object sender, EventArgs e)
        {
            frmkupon kupon = new frmkupon();
            kupon.ShowDialog();
        }

        private void btrendelesek_Click(object sender, EventArgs e)
        {
            frmrendelesek rendelesek = new frmrendelesek();
            rendelesek.ShowDialog();
        }
    }
}
