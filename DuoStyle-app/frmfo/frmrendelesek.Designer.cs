namespace frmfo
{
    partial class frmrendelesek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrendelesek));
            this.dgadatok = new System.Windows.Forms.DataGridView();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zip_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coupon_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordered_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btkilepes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).BeginInit();
            this.SuspendLayout();
            // 
            // dgadatok
            // 
            this.dgadatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgadatok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_id,
            this.user_name,
            this.zip_code,
            this.city,
            this.street,
            this.coupon_code,
            this.total_amount,
            this.note,
            this.ordered_at});
            this.dgadatok.Location = new System.Drawing.Point(16, 15);
            this.dgadatok.Margin = new System.Windows.Forms.Padding(4);
            this.dgadatok.Name = "dgadatok";
            this.dgadatok.RowHeadersWidth = 51;
            this.dgadatok.Size = new System.Drawing.Size(1035, 330);
            this.dgadatok.TabIndex = 0;
            this.dgadatok.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgadatok_CellClick);
            // 
            // order_id
            // 
            this.order_id.HeaderText = "Rendelés Azonosítója";
            this.order_id.MinimumWidth = 6;
            this.order_id.Name = "order_id";
            this.order_id.ReadOnly = true;
            this.order_id.Width = 125;
            // 
            // user_name
            // 
            this.user_name.HeaderText = "Felhasználó neve";
            this.user_name.MinimumWidth = 6;
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            this.user_name.Width = 125;
            // 
            // zip_code
            // 
            this.zip_code.HeaderText = "Irányító szám";
            this.zip_code.MinimumWidth = 6;
            this.zip_code.Name = "zip_code";
            this.zip_code.ReadOnly = true;
            this.zip_code.Width = 125;
            // 
            // city
            // 
            this.city.HeaderText = "Város";
            this.city.MinimumWidth = 6;
            this.city.Name = "city";
            this.city.ReadOnly = true;
            this.city.Width = 125;
            // 
            // street
            // 
            this.street.HeaderText = "Utca";
            this.street.MinimumWidth = 6;
            this.street.Name = "street";
            this.street.ReadOnly = true;
            this.street.Width = 125;
            // 
            // coupon_code
            // 
            this.coupon_code.HeaderText = "Kupon Kód";
            this.coupon_code.MinimumWidth = 6;
            this.coupon_code.Name = "coupon_code";
            this.coupon_code.ReadOnly = true;
            this.coupon_code.Width = 125;
            // 
            // total_amount
            // 
            this.total_amount.HeaderText = "Rendelés Végösszege";
            this.total_amount.MinimumWidth = 6;
            this.total_amount.Name = "total_amount";
            this.total_amount.ReadOnly = true;
            this.total_amount.Width = 125;
            // 
            // note
            // 
            this.note.HeaderText = "Megjegyzés";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 125;
            // 
            // ordered_at
            // 
            this.ordered_at.HeaderText = "Rendelés ideje";
            this.ordered_at.MinimumWidth = 6;
            this.ordered_at.Name = "ordered_at";
            this.ordered_at.ReadOnly = true;
            this.ordered_at.Width = 125;
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(432, 412);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 42;
            this.btkilepes.Text = "Kilépés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // frmrendelesek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btkilepes);
            this.Controls.Add(this.dgadatok);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmrendelesek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rendelések";
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgadatok;
        private System.Windows.Forms.Button btkilepes;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn zip_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn street;
        private System.Windows.Forms.DataGridViewTextBoxColumn coupon_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordered_at;
    }
}