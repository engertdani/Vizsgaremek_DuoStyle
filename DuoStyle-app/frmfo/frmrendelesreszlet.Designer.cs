namespace frmfo
{
    partial class frmrendelesreszlet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrendelesreszlet));
            this.btkesz = new System.Windows.Forms.Button();
            this.btkilepes = new System.Windows.Forms.Button();
            this.dgadatok = new System.Windows.Forms.DataGridView();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).BeginInit();
            this.SuspendLayout();
            // 
            // btkesz
            // 
            this.btkesz.Location = new System.Drawing.Point(154, 382);
            this.btkesz.Margin = new System.Windows.Forms.Padding(4);
            this.btkesz.Name = "btkesz";
            this.btkesz.Size = new System.Drawing.Size(164, 76);
            this.btkesz.TabIndex = 45;
            this.btkesz.Text = "Rendelés összeállítva";
            this.btkesz.UseVisualStyleBackColor = true;
            this.btkesz.Click += new System.EventHandler(this.btkesz_Click);
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(617, 382);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 44;
            this.btkilepes.Text = "Elvetés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // dgadatok
            // 
            this.dgadatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgadatok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_id,
            this.email,
            this.product_name,
            this.size,
            this.quantity});
            this.dgadatok.Location = new System.Drawing.Point(154, 13);
            this.dgadatok.Margin = new System.Windows.Forms.Padding(4);
            this.dgadatok.Name = "dgadatok";
            this.dgadatok.RowHeadersWidth = 51;
            this.dgadatok.Size = new System.Drawing.Size(615, 330);
            this.dgadatok.TabIndex = 46;
            // 
            // order_id
            // 
            this.order_id.HeaderText = "Rendelés Azonosítója";
            this.order_id.MinimumWidth = 6;
            this.order_id.Name = "order_id";
            this.order_id.ReadOnly = true;
            this.order_id.Visible = false;
            this.order_id.Width = 125;
            // 
            // email
            // 
            this.email.HeaderText = "Felhasználó emailja";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Visible = false;
            this.email.Width = 125;
            // 
            // product_name
            // 
            this.product_name.HeaderText = "Termék neve";
            this.product_name.MinimumWidth = 6;
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            this.product_name.Width = 125;
            // 
            // size
            // 
            this.size.HeaderText = "Kiszerelés";
            this.size.MinimumWidth = 6;
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 125;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Rendelt mennyiség";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 125;
            // 
            // frmrendelesreszlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1046, 500);
            this.Controls.Add(this.dgadatok);
            this.Controls.Add(this.btkesz);
            this.Controls.Add(this.btkilepes);
            this.Name = "frmrendelesreszlet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmrendelesreszlet";
            this.Load += new System.EventHandler(this.frmrendelesreszlet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btkesz;
        private System.Windows.Forms.Button btkilepes;
        private System.Windows.Forms.DataGridView dgadatok;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
    }
}