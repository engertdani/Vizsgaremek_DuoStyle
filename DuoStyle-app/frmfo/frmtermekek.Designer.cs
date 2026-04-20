namespace frmfo
{
    partial class frmtermekek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtermekek));
            this.dgtermekek = new System.Windows.Forms.DataGridView();
            this.variant_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtermekneve = new System.Windows.Forms.TextBox();
            this.txtermekmeret = new System.Windows.Forms.TextBox();
            this.txtermekmenny = new System.Windows.Forms.TextBox();
            this.txtermekar = new System.Windows.Forms.TextBox();
            this.btmentes = new System.Windows.Forms.Button();
            this.btelvet = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbmod = new System.Windows.Forms.RadioButton();
            this.rbuj = new System.Windows.Forms.RadioButton();
            this.label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.liarulas = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgtermekek)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtermekek
            // 
            this.dgtermekek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgtermekek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.variant_id,
            this.pn,
            this.name,
            this.size,
            this.stock,
            this.price,
            this.active});
            this.dgtermekek.Location = new System.Drawing.Point(28, 73);
            this.dgtermekek.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgtermekek.Name = "dgtermekek";
            this.dgtermekek.RowHeadersWidth = 51;
            this.dgtermekek.RowTemplate.Height = 24;
            this.dgtermekek.Size = new System.Drawing.Size(805, 171);
            this.dgtermekek.TabIndex = 0;
            this.dgtermekek.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgtermekek_CellClick);
            // 
            // variant_id
            // 
            this.variant_id.HeaderText = "Variáns azonosítója";
            this.variant_id.MinimumWidth = 6;
            this.variant_id.Name = "variant_id";
            this.variant_id.ReadOnly = true;
            this.variant_id.Visible = false;
            this.variant_id.Width = 125;
            // 
            // pn
            // 
            this.pn.HeaderText = "Cikkszám";
            this.pn.MinimumWidth = 6;
            this.pn.Name = "pn";
            this.pn.ReadOnly = true;
            this.pn.Visible = false;
            this.pn.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Termék neve";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // size
            // 
            this.size.HeaderText = "Méret/Kiszerelés";
            this.size.MinimumWidth = 6;
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 125;
            // 
            // stock
            // 
            this.stock.HeaderText = "Mennyiség";
            this.stock.MinimumWidth = 6;
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            this.stock.Width = 125;
            // 
            // price
            // 
            this.price.HeaderText = "Ár";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 125;
            // 
            // active
            // 
            this.active.HeaderText = "Áruljuk éppen";
            this.active.MinimumWidth = 6;
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Termék neve:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mérete:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mennyisége:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ára:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Áruljuk:";
            // 
            // txtermekneve
            // 
            this.txtermekneve.Location = new System.Drawing.Point(144, 250);
            this.txtermekneve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtermekneve.Name = "txtermekneve";
            this.txtermekneve.Size = new System.Drawing.Size(220, 22);
            this.txtermekneve.TabIndex = 6;
            // 
            // txtermekmeret
            // 
            this.txtermekmeret.Location = new System.Drawing.Point(144, 293);
            this.txtermekmeret.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtermekmeret.Name = "txtermekmeret";
            this.txtermekmeret.Size = new System.Drawing.Size(100, 22);
            this.txtermekmeret.TabIndex = 7;
            // 
            // txtermekmenny
            // 
            this.txtermekmenny.Location = new System.Drawing.Point(144, 331);
            this.txtermekmenny.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtermekmenny.Name = "txtermekmenny";
            this.txtermekmenny.Size = new System.Drawing.Size(100, 22);
            this.txtermekmenny.TabIndex = 8;
            // 
            // txtermekar
            // 
            this.txtermekar.Location = new System.Drawing.Point(144, 370);
            this.txtermekar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtermekar.Name = "txtermekar";
            this.txtermekar.Size = new System.Drawing.Size(100, 22);
            this.txtermekar.TabIndex = 9;
            this.txtermekar.TextChanged += new System.EventHandler(this.txprice_TextChanged);
            // 
            // btmentes
            // 
            this.btmentes.Location = new System.Drawing.Point(611, 356);
            this.btmentes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btmentes.Name = "btmentes";
            this.btmentes.Size = new System.Drawing.Size(125, 76);
            this.btmentes.TabIndex = 11;
            this.btmentes.Text = "Mentés";
            this.btmentes.UseVisualStyleBackColor = true;
            this.btmentes.Click += new System.EventHandler(this.btmentes_Click);
            // 
            // btelvet
            // 
            this.btelvet.Location = new System.Drawing.Point(809, 356);
            this.btelvet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btelvet.Name = "btelvet";
            this.btelvet.Size = new System.Drawing.Size(125, 76);
            this.btelvet.TabIndex = 13;
            this.btelvet.Text = "Elvetés";
            this.btelvet.UseVisualStyleBackColor = true;
            this.btelvet.Click += new System.EventHandler(this.btelvet_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbmod);
            this.groupBox1.Controls.Add(this.rbuj);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(873, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(247, 98);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Műveletek";
            // 
            // rbmod
            // 
            this.rbmod.AutoSize = true;
            this.rbmod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbmod.Location = new System.Drawing.Point(21, 57);
            this.rbmod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbmod.Name = "rbmod";
            this.rbmod.Size = new System.Drawing.Size(205, 29);
            this.rbmod.TabIndex = 1;
            this.rbmod.TabStop = true;
            this.rbmod.Text = "Termék módosítása";
            this.rbmod.UseVisualStyleBackColor = true;
            this.rbmod.CheckedChanged += new System.EventHandler(this.rbmod_CheckedChanged);
            // 
            // rbuj
            // 
            this.rbuj.AutoSize = true;
            this.rbuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbuj.Location = new System.Drawing.Point(21, 21);
            this.rbuj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbuj.Name = "rbuj";
            this.rbuj.Size = new System.Drawing.Size(183, 29);
            this.rbuj.TabIndex = 0;
            this.rbuj.TabStop = true;
            this.rbuj.Text = "Új termék variáns";
            this.rbuj.UseVisualStyleBackColor = true;
            this.rbuj.CheckedChanged += new System.EventHandler(this.rbuj_CheckedChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(831, 9);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(242, 48);
            this.label.TabIndex = 15;
            this.label.Text = "Termékek";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(428, 48);
            this.label6.TabIndex = 16;
            this.label6.Text = "DUO STYLE SZALON";
            // 
            // liarulas
            // 
            this.liarulas.AllowDrop = true;
            this.liarulas.FormattingEnabled = true;
            this.liarulas.ItemHeight = 16;
            this.liarulas.Location = new System.Drawing.Point(144, 411);
            this.liarulas.Name = "liarulas";
            this.liarulas.Size = new System.Drawing.Size(100, 20);
            this.liarulas.TabIndex = 17;
            // 
            // frmtermekek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1121, 459);
            this.Controls.Add(this.liarulas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btelvet);
            this.Controls.Add(this.btmentes);
            this.Controls.Add(this.txtermekar);
            this.Controls.Add(this.txtermekmenny);
            this.Controls.Add(this.txtermekmeret);
            this.Controls.Add(this.txtermekneve);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgtermekek);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmtermekek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Termékek felvétele/módosítása";
            ((System.ComponentModel.ISupportInitialize)(this.dgtermekek)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgtermekek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtermekneve;
        private System.Windows.Forms.TextBox txtermekmeret;
        private System.Windows.Forms.TextBox txtermekmenny;
        private System.Windows.Forms.TextBox txtermekar;
        private System.Windows.Forms.Button btmentes;
        private System.Windows.Forms.Button btelvet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbmod;
        private System.Windows.Forms.RadioButton rbuj;
        private System.Windows.Forms.DataGridViewTextBoxColumn variant_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox liarulas;
    }
}