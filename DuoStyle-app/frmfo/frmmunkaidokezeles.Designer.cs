namespace frmfo
{
    partial class frmmunkaidokezeles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmunkaidokezeles));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtdatum = new System.Windows.Forms.DateTimePicker();
            this.dtmunkakezd = new System.Windows.Forms.DateTimePicker();
            this.dtmunkaveg = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbmunkaido = new System.Windows.Forms.Label();
            this.btmentes = new System.Windows.Forms.Button();
            this.btkilepes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "DUO STYLE SZALON";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(607, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 48);
            this.label2.TabIndex = 5;
            this.label2.Text = "Munkaidő kezelés";
            // 
            // dtdatum
            // 
            this.dtdatum.CustomFormat = "yyyy-MM-dd";
            this.dtdatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtdatum.Location = new System.Drawing.Point(68, 183);
            this.dtdatum.Margin = new System.Windows.Forms.Padding(4);
            this.dtdatum.Name = "dtdatum";
            this.dtdatum.Size = new System.Drawing.Size(124, 22);
            this.dtdatum.TabIndex = 6;
            this.dtdatum.ValueChanged += new System.EventHandler(this.dtdatum_ValueChanged);
            // 
            // dtmunkakezd
            // 
            this.dtmunkakezd.CustomFormat = "HH:mm";
            this.dtmunkakezd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmunkakezd.Location = new System.Drawing.Point(355, 183);
            this.dtmunkakezd.Margin = new System.Windows.Forms.Padding(4);
            this.dtmunkakezd.Name = "dtmunkakezd";
            this.dtmunkakezd.Size = new System.Drawing.Size(265, 22);
            this.dtmunkakezd.TabIndex = 7;
            this.dtmunkakezd.ValueChanged += new System.EventHandler(this.dtmunkakezd_ValueChanged);
            // 
            // dtmunkaveg
            // 
            this.dtmunkaveg.CustomFormat = "HH:mm";
            this.dtmunkaveg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmunkaveg.Location = new System.Drawing.Point(355, 298);
            this.dtmunkaveg.Margin = new System.Windows.Forms.Padding(4);
            this.dtmunkaveg.Name = "dtmunkaveg";
            this.dtmunkaveg.Size = new System.Drawing.Size(265, 22);
            this.dtmunkaveg.TabIndex = 8;
            this.dtmunkaveg.ValueChanged += new System.EventHandler(this.dtmunkaveg_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(63, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Munkanap dátuma:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(349, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Munkanap kezdete:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(349, 270);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Munkanap vége:";
            // 
            // lbmunkaido
            // 
            this.lbmunkaido.AutoSize = true;
            this.lbmunkaido.BackColor = System.Drawing.Color.Transparent;
            this.lbmunkaido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbmunkaido.ForeColor = System.Drawing.Color.White;
            this.lbmunkaido.Location = new System.Drawing.Point(53, 372);
            this.lbmunkaido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbmunkaido.Name = "lbmunkaido";
            this.lbmunkaido.Size = new System.Drawing.Size(208, 25);
            this.lbmunkaido.TabIndex = 16;
            this.lbmunkaido.Text = "Számolt munkaidőd:";
            // 
            // btmentes
            // 
            this.btmentes.Location = new System.Drawing.Point(301, 426);
            this.btmentes.Margin = new System.Windows.Forms.Padding(4);
            this.btmentes.Name = "btmentes";
            this.btmentes.Size = new System.Drawing.Size(164, 76);
            this.btmentes.TabIndex = 17;
            this.btmentes.Text = "Munkaidő elmentése";
            this.btmentes.UseVisualStyleBackColor = true;
            this.btmentes.Click += new System.EventHandler(this.btmentes_Click);
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(495, 426);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 21;
            this.btkilepes.Text = "Elvetés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // frmmunkaidokezeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btkilepes);
            this.Controls.Add(this.btmentes);
            this.Controls.Add(this.lbmunkaido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtmunkaveg);
            this.Controls.Add(this.dtmunkakezd);
            this.Controls.Add(this.dtdatum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmmunkaidokezeles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Munkaidő kezelés";
            this.Load += new System.EventHandler(this.frmmunkaidokezeles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtdatum;
        private System.Windows.Forms.DateTimePicker dtmunkakezd;
        private System.Windows.Forms.DateTimePicker dtmunkaveg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbmunkaido;
        private System.Windows.Forms.Button btmentes;
        private System.Windows.Forms.Button btkilepes;
    }
}