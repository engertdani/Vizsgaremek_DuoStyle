namespace frmfo
{
    partial class frmjelszomegadas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmjelszomegadas));
            this.txemail = new System.Windows.Forms.TextBox();
            this.txjelszo = new System.Windows.Forms.TextBox();
            this.txjelszoujra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btfelvetel = new System.Windows.Forms.Button();
            this.btkilepes = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txemail
            // 
            this.txemail.Location = new System.Drawing.Point(363, 108);
            this.txemail.Margin = new System.Windows.Forms.Padding(4);
            this.txemail.MaxLength = 100;
            this.txemail.Name = "txemail";
            this.txemail.Size = new System.Drawing.Size(248, 22);
            this.txemail.TabIndex = 0;
            // 
            // txjelszo
            // 
            this.txjelszo.Location = new System.Drawing.Point(363, 168);
            this.txjelszo.Margin = new System.Windows.Forms.Padding(4);
            this.txjelszo.MaxLength = 50;
            this.txjelszo.Name = "txjelszo";
            this.txjelszo.Size = new System.Drawing.Size(248, 22);
            this.txjelszo.TabIndex = 1;
            this.txjelszo.UseSystemPasswordChar = true;
            // 
            // txjelszoujra
            // 
            this.txjelszoujra.Location = new System.Drawing.Point(363, 225);
            this.txjelszoujra.Margin = new System.Windows.Forms.Padding(4);
            this.txjelszoujra.MaxLength = 50;
            this.txjelszoujra.Name = "txjelszoujra";
            this.txjelszoujra.Size = new System.Drawing.Size(248, 22);
            this.txjelszoujra.TabIndex = 2;
            this.txjelszoujra.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(359, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dolgozo email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(359, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dolgozo jelszava:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(359, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Jelszo ujra:";
            // 
            // btfelvetel
            // 
            this.btfelvetel.Location = new System.Drawing.Point(296, 353);
            this.btfelvetel.Margin = new System.Windows.Forms.Padding(4);
            this.btfelvetel.Name = "btfelvetel";
            this.btfelvetel.Size = new System.Drawing.Size(164, 76);
            this.btfelvetel.TabIndex = 15;
            this.btfelvetel.Text = "Dolgozó  email és jelszó mentése";
            this.btfelvetel.UseVisualStyleBackColor = true;
            this.btfelvetel.Click += new System.EventHandler(this.btfelvetel_Click);
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(547, 353);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 21;
            this.btkilepes.Text = "Elvetés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(363, 269);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(260, 29);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Megnézem a jelszavaimat";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(428, 48);
            this.label4.TabIndex = 23;
            this.label4.Text = "DUO STYLE SZALON";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(579, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 48);
            this.label5.TabIndex = 24;
            this.label5.Text = "Jelszó megadás";
            // 
            // frmjelszomegadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(920, 554);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btkilepes);
            this.Controls.Add(this.btfelvetel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txjelszoujra);
            this.Controls.Add(this.txjelszo);
            this.Controls.Add(this.txemail);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmjelszomegadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jelszó megadása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txemail;
        private System.Windows.Forms.TextBox txjelszo;
        private System.Windows.Forms.TextBox txjelszoujra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btfelvetel;
        private System.Windows.Forms.Button btkilepes;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}