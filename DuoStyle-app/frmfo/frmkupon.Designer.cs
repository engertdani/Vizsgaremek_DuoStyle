namespace frmfo
{
    partial class frmkupon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmkupon));
            this.label1 = new System.Windows.Forms.Label();
            this.txkuponkod = new System.Windows.Forms.TextBox();
            this.btkilepes = new System.Windows.Forms.Button();
            this.btmentes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbkedvezmeny = new System.Windows.Forms.ListBox();
            this.btkuponok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(287, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kupon kódja:";
            // 
            // txkuponkod
            // 
            this.txkuponkod.Location = new System.Drawing.Point(290, 72);
            this.txkuponkod.MaxLength = 10;
            this.txkuponkod.Name = "txkuponkod";
            this.txkuponkod.Size = new System.Drawing.Size(100, 22);
            this.txkuponkod.TabIndex = 2;
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(407, 342);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 23;
            this.btkilepes.Text = "Elvetés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // btmentes
            // 
            this.btmentes.Location = new System.Drawing.Point(213, 342);
            this.btmentes.Margin = new System.Windows.Forms.Padding(4);
            this.btmentes.Name = "btmentes";
            this.btmentes.Size = new System.Drawing.Size(164, 76);
            this.btmentes.TabIndex = 22;
            this.btmentes.Text = "Kupon felvétele";
            this.btmentes.UseVisualStyleBackColor = true;
            this.btmentes.Click += new System.EventHandler(this.btmentes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(290, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Kupon kedvezménye:";
            // 
            // lbkedvezmeny
            // 
            this.lbkedvezmeny.FormattingEnabled = true;
            this.lbkedvezmeny.ItemHeight = 16;
            this.lbkedvezmeny.Location = new System.Drawing.Point(295, 154);
            this.lbkedvezmeny.Name = "lbkedvezmeny";
            this.lbkedvezmeny.Size = new System.Drawing.Size(119, 84);
            this.lbkedvezmeny.TabIndex = 25;
            this.lbkedvezmeny.SelectedIndexChanged += new System.EventHandler(this.lbkedvezmeny_SelectedIndexChanged);
            // 
            // btkuponok
            // 
            this.btkuponok.Location = new System.Drawing.Point(514, 162);
            this.btkuponok.Margin = new System.Windows.Forms.Padding(4);
            this.btkuponok.Name = "btkuponok";
            this.btkuponok.Size = new System.Drawing.Size(164, 76);
            this.btkuponok.TabIndex = 26;
            this.btkuponok.Text = "Kuponok megtekintése";
            this.btkuponok.UseVisualStyleBackColor = true;
            this.btkuponok.Click += new System.EventHandler(this.btkuponok_Click);
            // 
            // frmkupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btkuponok);
            this.Controls.Add(this.lbkedvezmeny);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btkilepes);
            this.Controls.Add(this.btmentes);
            this.Controls.Add(this.txkuponkod);
            this.Controls.Add(this.label1);
            this.Name = "frmkupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kupon felvétele";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txkuponkod;
        private System.Windows.Forms.Button btkilepes;
        private System.Windows.Forms.Button btmentes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbkedvezmeny;
        private System.Windows.Forms.Button btkuponok;
    }
}