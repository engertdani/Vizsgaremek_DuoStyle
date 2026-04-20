namespace frmfo
{
    partial class frmalkkirug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmalkkirug));
            this.dgadatok = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.join_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fav_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btkirugas = new System.Windows.Forms.Button();
            this.txkereses = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btelvet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).BeginInit();
            this.SuspendLayout();
            // 
            // dgadatok
            // 
            this.dgadatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgadatok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.name,
            this.email,
            this.tel,
            this.join_date,
            this.description,
            this.fav_brand});
            this.dgadatok.Location = new System.Drawing.Point(12, 145);
            this.dgadatok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgadatok.Name = "dgadatok";
            this.dgadatok.RowHeadersWidth = 51;
            this.dgadatok.RowTemplate.Height = 24;
            this.dgadatok.Size = new System.Drawing.Size(839, 267);
            this.dgadatok.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "Alkalmazott azonosítója";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Alkalmazott Neve";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // email
            // 
            this.email.HeaderText = "Alkalmazott email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 125;
            // 
            // tel
            // 
            this.tel.HeaderText = "Alkalmazott Telefonszáma";
            this.tel.MinimumWidth = 6;
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            this.tel.Width = 125;
            // 
            // join_date
            // 
            this.join_date.HeaderText = "Belépés Dátuma";
            this.join_date.MinimumWidth = 6;
            this.join_date.Name = "join_date";
            this.join_date.ReadOnly = true;
            this.join_date.Width = 125;
            // 
            // description
            // 
            this.description.HeaderText = "Alkalmazott Leírása";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 125;
            // 
            // fav_brand
            // 
            this.fav_brand.HeaderText = "Kedvenc Márkája";
            this.fav_brand.MinimumWidth = 6;
            this.fav_brand.Name = "fav_brand";
            this.fav_brand.ReadOnly = true;
            this.fav_brand.Width = 125;
            // 
            // btkirugas
            // 
            this.btkirugas.Location = new System.Drawing.Point(919, 145);
            this.btkirugas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btkirugas.Name = "btkirugas";
            this.btkirugas.Size = new System.Drawing.Size(116, 90);
            this.btkirugas.TabIndex = 1;
            this.btkirugas.Text = "Alkalmazott kirúgása";
            this.btkirugas.UseVisualStyleBackColor = true;
            this.btkirugas.Click += new System.EventHandler(this.btkirugas_Click);
            // 
            // txkereses
            // 
            this.txkereses.Location = new System.Drawing.Point(215, 118);
            this.txkereses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txkereses.MaxLength = 100;
            this.txkereses.Name = "txkereses";
            this.txkereses.Size = new System.Drawing.Size(100, 22);
            this.txkereses.TabIndex = 2;
            this.txkereses.TextChanged += new System.EventHandler(this.txkereses_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 48);
            this.label1.TabIndex = 6;
            this.label1.Text = "DUO STYLE SZALON";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(476, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(578, 48);
            this.label2.TabIndex = 7;
            this.label2.Text = "Alkalmazott elbocsájtása";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 25);
            this.label3.TabIndex = 46;
            this.label3.Text = "Alkalmazott neve:";
            // 
            // btelvet
            // 
            this.btelvet.Location = new System.Drawing.Point(919, 332);
            this.btelvet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btelvet.Name = "btelvet";
            this.btelvet.Size = new System.Drawing.Size(116, 90);
            this.btelvet.TabIndex = 47;
            this.btelvet.Text = "Elvetés";
            this.btelvet.UseVisualStyleBackColor = true;
            this.btelvet.Click += new System.EventHandler(this.btelvet_Click);
            // 
            // frmalkkirug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1105, 526);
            this.Controls.Add(this.btelvet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txkereses);
            this.Controls.Add(this.btkirugas);
            this.Controls.Add(this.dgadatok);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmalkkirug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alkalmazott elbocsájtása";
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgadatok;
        private System.Windows.Forms.Button btkirugas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn join_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn fav_brand;
        private System.Windows.Forms.TextBox txkereses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btelvet;
    }
}