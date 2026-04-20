using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static frmfo.muveletek;
using static System.Net.WebRequestMethods;

namespace frmfo
{
    public partial class frmdolgozofelvetel : Form
    {
        public frmdolgozofelvetel()
        {
            InitializeComponent();
        }
        private string Email;
        private string Jelszo;
        string selectedfile = "";
        private void emailKuldes(string toEmail)
        {
            string pozicio = rbfodrasz.Checked ? "fodrász" : "masszőr";

            string htmlBody = $@"
            <div style='font-family: ""Segoe UI"", Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #c5a059; border-radius: 4px; background-color: #121212; color: #e0e0e0;'>
            <div style='background: linear-gradient(135deg, #1a1a1a 0%, #000000 100%); color: #c5a059; padding: 30px; text-align: center; border-bottom: 2px solid #c5a059; margin: -20px -20px 20px -20px;'>
            <h1 style='margin: 0; letter-spacing: 2px; text-transform: uppercase;'>🎉 Felvételi Értesítő 🎉</h1>
            <h2 style='margin: 10px 0 0 0; font-weight: 300;'>DuoStyle Szalon</h2>
            </div>
    
             <p style='font-size: 16px; color: #ffffff;'>
             <strong>Kedves {txdolgozonev.Text}!</strong>
             </p>
    
             <div style='background: #1d1d1d; padding: 20px; border-left: 4px solid #c5a059; margin: 25px 0; box-shadow: 0 4px 15px rgba(0,0,0,0.5);'>
             <p style='font-size: 18px; color: #c5a059; margin: 0; line-height: 1.5;'>
             <strong>✨ Örömmel értesítjük, hogy felvételt nyert a DuoStyle szalonba <span style=""color: #ffffff;"">{pozicio}</span> munkakörbe!</strong>
             </p>
             </div>
    
             <p style='line-height: 1.6;'>Üdvözöljük kreatív csapatunkban! Meggyőződésünk, hogy szakértelme hozzájárul majd a szalonunk által képviselt prémium minőséghez.</p>
             
             <hr style='border: none; height: 1px; background: #333; margin: 30px 0;'>
             
             <p style='font-size: 12px; color: #888; text-align: center; padding: 20px; background: #0a0a0a; border-radius: 4px;'>
                 <em style=""color: #666;"">⚠️ Ha Önt nem érinti ez az e-mail, kérjük, hagyja figyelmen kívül!</em><br><br>
                 <strong style=""color: #c5a059;"" >Stílus. Erő. Megújulás.</strong><br>
                 <span style=""font-size: 11px;"">További szép napot kíván a DuoStyle csapata! ✂️🥃</span>
             </p>
             </div>";
            MailMessage mail = new MailMessage(Email, toEmail)
            {
                Subject = $"🎉 FELVÉTELI ÉRTESÍTŐ - {txdolgozonev.Text.ToUpper()}",
                Body = htmlBody,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("engertmohamed@gmail.com", "wyzkngivbhavvdfu");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private void Urites()
        {
           txdolgozonev.Clear();
            txdolgozotel.Clear();
            txdolgozokedvmarka.Clear();
            rtdolgozoleiras.Clear();
            cbtulaj.Checked = false;
            rbfodrasz.Checked = true;
            rbnemferfi.Checked = true;
            dtfelvetel.Value = DateTime.Now;
        }

        private void frmdolgozofelvetel_Load(object sender, EventArgs e)
        {
            Urites();
            rbfodrasz.Checked = true;
            rbnemferfi.Checked = true;
        }

        private void KepMentese(string sourcePath)
        {
            string targetFolder = @"C:\Users\User\Desktop\MENTÉS\duostylewebesteljes\DuoStyle-app\public\assets\img\";

            string fileName = Path.GetFileName(sourcePath);
            string targetPath = Path.Combine(targetFolder, fileName);

            System.IO.File.Copy(sourcePath, targetPath, true);
        }

        private void txdolgozotel_TextChanged(object sender, EventArgs e)
        {
            if (txdolgozotel.TextLength > 0)
            {
                try
                {
                    int szam = Convert.ToInt32(txdolgozotel.Text);
                }
                catch
                {
                    MessageBox.Show("A dolgozó telefonszáma nem lehet betű!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txdolgozotel.Clear();
                    txdolgozotel.Focus();
                }
            }
        }

        private void btfelvetel_Click(object sender, EventArgs e)
        {
            if (txdolgozonev.TextLength == 0)
            {
                MessageBox.Show("Nem lehet név nélküli dolgozót felvenni!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txdolgozonev.Focus();
            }
            else if (txdolgozotel.TextLength == 0)
            {
                MessageBox.Show("Nem lehet telefonszán nélküli dolgozót felvenni!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txdolgozotel.Focus();
            }
            else if (txdolgozokedvmarka.TextLength == 0)
            {
                MessageBox.Show("Nem lehet kedvenc márka nélküli dolgozót felvenni!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txdolgozokedvmarka.Focus();
            }
            else if (rtdolgozoleiras.TextLength == 0)
            {
                MessageBox.Show("Adjon meg egy leirast a dolgozóról", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtdolgozoleiras.Focus();
            }
            else if (rbfodrasz.Checked && rtdolgozoleiras.Text.ToLower().Contains("masszőr"))
            {
                MessageBox.Show("Ha az alkalmazott Fodrász szalonba lesz felvéve nem tartalmazhatja a leirása a masszőr szót!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtdolgozoleiras.Focus();
            }
            else if (rbmasszaz.Checked && rtdolgozoleiras.Text.ToLower().Contains("fodrász"))
            {
                MessageBox.Show("Ha az alkalmazott masszőr szalonba lesz felvéve nem tartalmazhatja a leirása a fodrász szót!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtdolgozoleiras.Focus();
            }
            else if (Email == null)
            {
                MessageBox.Show("Adja meg az alkalmazott email-jét és jelszavát!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btemailjelszo.Focus();
            }
            else if (string.IsNullOrEmpty(selectedfile))
            {
                MessageBox.Show("Nem választottál ki fájlt!","HIBA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btkep.Focus();
            }
            else if (rbfodrasz.Checked && !rtdolgozoleiras.Text.ToLower().Contains("fodrász"))
            {
                MessageBox.Show("Ha az alkalmazott Fodrász szalonba lesz felvéve a leirásának tartalmaznia kell a fodrász szót!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtdolgozoleiras.Focus();
            }
            else if (rbmasszaz.Checked && !rtdolgozoleiras.Text.ToLower().Contains("masszőr"))
            {
                MessageBox.Show("Ha az alkalmazott Fodrász szalonba lesz felvéve a leirásának tartalmaznia kell a masszőr szót!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtdolgozoleiras.Focus();
            }
            else
            {
                if ( cbtulaj.Checked && rbfodrasz.Checked && rbnemferfi.Checked )
                {
                    
                    string lekerdezes = "select count(*) as darab from employees where tel = '"+txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img  ,admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','"+"f"+"','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+ Path.GetFileName(opfile.FileName).ToString() + "','" + 1 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if ( cbtulaj.Checked && rbfodrasz.Checked && rbnemno.Checked)
                {

                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) " +
                            "VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" 
                            + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','" + Path.GetFileName(opfile.FileName).ToString() + "','" + 1 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if ( cbtulaj.Checked && rbmasszaz.Checked && rbnemferfi.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '"+txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "f" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','" + Path.GetFileName(opfile.FileName).ToString() + "','" + 1 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (cbtulaj.Checked && rbmasszaz.Checked && rbnemno.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 1 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbfodrasz.Checked && rbnemferfi.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','"+"f"+"','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbfodrasz.Checked && rbnemno.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img  ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbmasszaz.Checked && rbnemferfi.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "f" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbmasszaz.Checked && rbnemno.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img  ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (cbtulaj.Checked && rbfodrasz.Checked && rbnemferfi.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "f" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 1 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (cbtulaj.Checked && rbfodrasz.Checked && rbnemno.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img  ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 1 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", 
                            "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", 
                            "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (cbtulaj.Checked && rbmasszaz.Checked && rbnemferfi.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "f" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 1 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (cbtulaj.Checked && rbmasszaz.Checked && rbnemno.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 1 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbfodrasz.Checked && rbnemferfi.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "f" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read(); 
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbfodrasz.Checked && rbnemno.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 1 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbmasszaz.Checked && rbnemferfi.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "f" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
                else if (rbmasszaz.Checked && rbnemno.Checked)
                {
                    string lekerdezes = "select count(*) as darab from employees where tel = '" +txdolgozotel.Text+"'";
                    Adatbazis ab = new Adatbazis(lekerdezes);
                    ab.Dr.Read();
                    int db = Convert.ToInt32(ab.Dr["darab"]);
                    ab.lezaras();
                    if (db == 0)
                    {
                        lekerdezes = "INSERT INTO  employees ( name ,  email ,  tel ,  password , gender ,  join_date ,  description ,  fav_brand , img ,  admin, salon_id ) VALUES ('" + txdolgozonev.Text + "','" + Email + "','" + "+36" + txdolgozotel.Text + "','" + Jelszo + "','" + "n" + "','" + dtfelvetel.Text + "','" + rtdolgozoleiras.Text + "','" + txdolgozokedvmarka.Text + "','"+Path.GetFileName(opfile.FileName).ToString()+"','" + 0 + "','" + 2 + "')";
                        ab = new Adatbazis(lekerdezes);
                        ab.Dr.Read();
                        emailKuldes(Email);
                        KepMentese(opfile.FileName);
                        MessageBox.Show($"Sikeresen felvetted a(z) {txdolgozonev.Text} nevű dolgozót", "ÜZENET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Ilyen dolgozónk már van!!", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txdolgozotel.Focus();
                        txdolgozotel.Clear();
                    }
                    Urites();
                }
            }
        }
            
        private void btkilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz =  MessageBox.Show("Bizots elveted az új alkalmazott felvételét?", "ÜZENET", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (valasz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btemailjelszo_Click(object sender, EventArgs e)
        {
            using (var jelszomegad = new frmjelszomegadas())
            {
                if (jelszomegad.ShowDialog() == DialogResult.OK)
                {
                    Email = jelszomegad.VisszaEmail;
                    Jelszo = jelszomegad.VisszaJelszo;

                    MessageBox.Show("Email és jelszó átvéve ✅", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btkep_Click(object sender, EventArgs e)
        {
            if (opfile.ShowDialog() == DialogResult.OK)
            {
                selectedfile = opfile.FileName;
            }
        }
    }
}
