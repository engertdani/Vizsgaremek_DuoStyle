namespace frmfo
{
    partial class frmidopontkezeles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmidopontkezeles));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txkereses = new System.Windows.Forms.TextBox();
            this.dgadatok = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointment_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finish_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btkilepes = new System.Windows.Forms.Button();
            this.btlemondva = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).BeginInit();
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
            this.label1.TabIndex = 3;
            this.label1.Text = "DUO STYLE SZALON";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(596, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "Időpontok kezelése";
            // 
            // txkereses
            // 
            this.txkereses.Location = new System.Drawing.Point(275, 149);
            this.txkereses.Margin = new System.Windows.Forms.Padding(4);
            this.txkereses.MaxLength = 10;
            this.txkereses.Name = "txkereses";
            this.txkereses.Size = new System.Drawing.Size(115, 22);
            this.txkereses.TabIndex = 25;
            this.txkereses.TextChanged += new System.EventHandler(this.txkereses_TextChanged);
            // 
            // dgadatok
            // 
            this.dgadatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgadatok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.user_email,
            this.employee_name,
            this.appointment_date,
            this.start_time,
            this.finish_time,
            this.user_name,
            this.service,
            this.note});
            this.dgadatok.Location = new System.Drawing.Point(13, 181);
            this.dgadatok.Margin = new System.Windows.Forms.Padding(4);
            this.dgadatok.MultiSelect = false;
            this.dgadatok.Name = "dgadatok";
            this.dgadatok.ReadOnly = true;
            this.dgadatok.RowHeadersWidth = 51;
            this.dgadatok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgadatok.Size = new System.Drawing.Size(763, 330);
            this.dgadatok.TabIndex = 17;
            // 
            // ID
            // 
            this.ID.HeaderText = "Időpont azon";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // user_email
            // 
            this.user_email.HeaderText = "Kliens Emailja";
            this.user_email.MinimumWidth = 6;
            this.user_email.Name = "user_email";
            this.user_email.ReadOnly = true;
            this.user_email.Visible = false;
            this.user_email.Width = 125;
            // 
            // employee_name
            // 
            this.employee_name.HeaderText = "Alkalmazott neve";
            this.employee_name.MinimumWidth = 6;
            this.employee_name.Name = "employee_name";
            this.employee_name.ReadOnly = true;
            this.employee_name.Visible = false;
            this.employee_name.Width = 125;
            // 
            // appointment_date
            // 
            this.appointment_date.HeaderText = "Időpont dátuma";
            this.appointment_date.MinimumWidth = 6;
            this.appointment_date.Name = "appointment_date";
            this.appointment_date.ReadOnly = true;
            this.appointment_date.Width = 125;
            // 
            // start_time
            // 
            this.start_time.HeaderText = "Időpont kezdete";
            this.start_time.MinimumWidth = 6;
            this.start_time.Name = "start_time";
            this.start_time.ReadOnly = true;
            this.start_time.Width = 125;
            // 
            // finish_time
            // 
            this.finish_time.HeaderText = "Időpont vége";
            this.finish_time.MinimumWidth = 6;
            this.finish_time.Name = "finish_time";
            this.finish_time.ReadOnly = true;
            this.finish_time.Width = 125;
            // 
            // user_name
            // 
            this.user_name.HeaderText = "Kliens neve";
            this.user_name.MinimumWidth = 6;
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            this.user_name.Width = 125;
            // 
            // service
            // 
            this.service.HeaderText = "Szolgáltatás jellege";
            this.service.MinimumWidth = 6;
            this.service.Name = "service";
            this.service.ReadOnly = true;
            this.service.Width = 125;
            // 
            // note
            // 
            this.note.HeaderText = "Megjegyzés";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 125;
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(804, 391);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 41;
            this.btkilepes.Text = "Elvetés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // btlemondva
            // 
            this.btlemondva.Location = new System.Drawing.Point(804, 181);
            this.btlemondva.Margin = new System.Windows.Forms.Padding(4);
            this.btlemondva.Name = "btlemondva";
            this.btlemondva.Size = new System.Drawing.Size(164, 76);
            this.btlemondva.TabIndex = 44;
            this.btlemondva.Text = "Lemondás";
            this.btlemondva.UseVisualStyleBackColor = true;
            this.btlemondva.Click += new System.EventHandler(this.btlemondva_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(79, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 45;
            this.label3.Text = "Időpont dátuma:";
            // 
            // frmidopontkezeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btlemondva);
            this.Controls.Add(this.btkilepes);
            this.Controls.Add(this.txkereses);
            this.Controls.Add(this.dgadatok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmidopontkezeles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Időpontok kezelése";
            this.Load += new System.EventHandler(this.frmidopontkezeles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txkereses;
        private System.Windows.Forms.DataGridView dgadatok;
        private System.Windows.Forms.Button btkilepes;
        private System.Windows.Forms.Button btlemondva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointment_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn finish_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn service;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
    }
}