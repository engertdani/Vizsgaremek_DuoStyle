namespace frmfo
{
    partial class frmosszesfoglalas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmosszesfoglalas));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgadatok = new System.Windows.Forms.DataGridView();
            this.appointment_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shifts_shift_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointments_start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointments_finish_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointments_note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txkereses = new System.Windows.Forms.TextBox();
            this.btkilepes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbaktiv = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 11);
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
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(805, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 48);
            this.label2.TabIndex = 7;
            this.label2.Text = "Összes foglalás";
            // 
            // dgadatok
            // 
            this.dgadatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgadatok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointment_id,
            this.employee_name,
            this.shifts_shift_date,
            this.appointments_start_time,
            this.appointments_finish_time,
            this.user_name,
            this.service,
            this.appointments_note});
            this.dgadatok.Location = new System.Drawing.Point(16, 192);
            this.dgadatok.Margin = new System.Windows.Forms.Padding(4);
            this.dgadatok.Name = "dgadatok";
            this.dgadatok.RowHeadersWidth = 51;
            this.dgadatok.Size = new System.Drawing.Size(1124, 330);
            this.dgadatok.TabIndex = 8;
            // 
            // appointment_id
            // 
            this.appointment_id.HeaderText = "";
            this.appointment_id.MinimumWidth = 6;
            this.appointment_id.Name = "appointment_id";
            this.appointment_id.ReadOnly = true;
            this.appointment_id.Visible = false;
            this.appointment_id.Width = 125;
            // 
            // employee_name
            // 
            this.employee_name.HeaderText = "Alkalmazott neve";
            this.employee_name.MinimumWidth = 6;
            this.employee_name.Name = "employee_name";
            this.employee_name.ReadOnly = true;
            this.employee_name.Width = 125;
            // 
            // shifts_shift_date
            // 
            this.shifts_shift_date.HeaderText = "Időpont dátuma";
            this.shifts_shift_date.MinimumWidth = 6;
            this.shifts_shift_date.Name = "shifts_shift_date";
            this.shifts_shift_date.ReadOnly = true;
            this.shifts_shift_date.Width = 125;
            // 
            // appointments_start_time
            // 
            this.appointments_start_time.HeaderText = "Időpont kezdete";
            this.appointments_start_time.MinimumWidth = 6;
            this.appointments_start_time.Name = "appointments_start_time";
            this.appointments_start_time.ReadOnly = true;
            this.appointments_start_time.Width = 125;
            // 
            // appointments_finish_time
            // 
            this.appointments_finish_time.HeaderText = "Időpont vége";
            this.appointments_finish_time.MinimumWidth = 6;
            this.appointments_finish_time.Name = "appointments_finish_time";
            this.appointments_finish_time.ReadOnly = true;
            this.appointments_finish_time.Width = 125;
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
            // appointments_note
            // 
            this.appointments_note.HeaderText = "Megjegyzés";
            this.appointments_note.MinimumWidth = 6;
            this.appointments_note.Name = "appointments_note";
            this.appointments_note.ReadOnly = true;
            this.appointments_note.Width = 125;
            // 
            // txkereses
            // 
            this.txkereses.Location = new System.Drawing.Point(335, 160);
            this.txkereses.Margin = new System.Windows.Forms.Padding(4);
            this.txkereses.MaxLength = 10;
            this.txkereses.Name = "txkereses";
            this.txkereses.Size = new System.Drawing.Size(115, 22);
            this.txkereses.TabIndex = 16;
            this.txkereses.TextChanged += new System.EventHandler(this.txkereses_TextChanged);
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(976, 74);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 41;
            this.btkilepes.Text = "Kilépés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(139, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "Időpont dátuma:";
            // 
            // cbaktiv
            // 
            this.cbaktiv.AutoSize = true;
            this.cbaktiv.BackColor = System.Drawing.Color.Transparent;
            this.cbaktiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbaktiv.ForeColor = System.Drawing.Color.White;
            this.cbaktiv.Location = new System.Drawing.Point(567, 158);
            this.cbaktiv.Name = "cbaktiv";
            this.cbaktiv.Size = new System.Drawing.Size(263, 29);
            this.cbaktiv.TabIndex = 43;
            this.cbaktiv.Text = "csak az aktív foglalások";
            this.cbaktiv.UseVisualStyleBackColor = false;
            this.cbaktiv.CheckedChanged += new System.EventHandler(this.cbaktiv_CheckedChanged);
            // 
            // frmosszesfoglalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1180, 554);
            this.Controls.Add(this.cbaktiv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btkilepes);
            this.Controls.Add(this.txkereses);
            this.Controls.Add(this.dgadatok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmosszesfoglalas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Összes foglalás";
            this.Load += new System.EventHandler(this.frmosszesfoglalas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgadatok;
        private System.Windows.Forms.TextBox txkereses;
        private System.Windows.Forms.Button btkilepes;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointment_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn shifts_shift_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointments_start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointments_finish_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn service;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointments_note;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbaktiv;
    }
}