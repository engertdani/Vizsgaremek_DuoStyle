namespace frmfo
{
    partial class frmarak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmarak));
            this.lbszolgalgatasok = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txara = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btment = new System.Windows.Forms.Button();
            this.btelvet = new System.Windows.Forms.Button();
            this.txhossz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbszolgalgatasok
            // 
            this.lbszolgalgatasok.FormattingEnabled = true;
            this.lbszolgalgatasok.ItemHeight = 16;
            this.lbszolgalgatasok.Location = new System.Drawing.Point(246, 137);
            this.lbszolgalgatasok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbszolgalgatasok.Name = "lbszolgalgatasok";
            this.lbszolgalgatasok.Size = new System.Drawing.Size(152, 84);
            this.lbszolgalgatasok.TabIndex = 0;
            this.lbszolgalgatasok.SelectedIndexChanged += new System.EventHandler(this.lbszolgalgatasok_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Szolgáltatás fajtája:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Szolgáltatás ára:";
            // 
            // txara
            // 
            this.txara.Location = new System.Drawing.Point(246, 253);
            this.txara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txara.MaxLength = 6;
            this.txara.Name = "txara";
            this.txara.Size = new System.Drawing.Size(100, 22);
            this.txara.TabIndex = 3;
            this.txara.TextChanged += new System.EventHandler(this.txara_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(352, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "ft";
            // 
            // btment
            // 
            this.btment.Location = new System.Drawing.Point(65, 426);
            this.btment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btment.Name = "btment";
            this.btment.Size = new System.Drawing.Size(120, 68);
            this.btment.TabIndex = 5;
            this.btment.Text = "Mentés";
            this.btment.UseVisualStyleBackColor = true;
            this.btment.Click += new System.EventHandler(this.btment_Click);
            // 
            // btelvet
            // 
            this.btelvet.Location = new System.Drawing.Point(236, 426);
            this.btelvet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btelvet.Name = "btelvet";
            this.btelvet.Size = new System.Drawing.Size(120, 68);
            this.btelvet.TabIndex = 6;
            this.btelvet.Text = "Elvetés";
            this.btelvet.UseVisualStyleBackColor = true;
            this.btelvet.Click += new System.EventHandler(this.btelvet_Click);
            // 
            // txhossz
            // 
            this.txhossz.Location = new System.Drawing.Point(246, 332);
            this.txhossz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txhossz.Name = "txhossz";
            this.txhossz.Size = new System.Drawing.Size(35, 22);
            this.txhossz.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Szolgáltatás hossza:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(287, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "perc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(11, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(428, 48);
            this.label6.TabIndex = 24;
            this.label6.Text = "DUO STYLE SZALON";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(536, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 48);
            this.label7.TabIndex = 25;
            this.label7.Text = "Ár megadása";
            // 
            // frmarak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(885, 671);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txhossz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btelvet);
            this.Controls.Add(this.btment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txara);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbszolgalgatasok);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmarak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ár megadása";
            this.Load += new System.EventHandler(this.frmarak_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbszolgalgatasok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txara;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btment;
        private System.Windows.Forms.Button btelvet;
        private System.Windows.Forms.TextBox txhossz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}