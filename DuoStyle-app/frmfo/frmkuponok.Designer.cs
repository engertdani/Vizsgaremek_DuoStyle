namespace frmfo
{
    partial class frmkuponok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmkuponok));
            this.dgadatok = new System.Windows.Forms.DataGridView();
            this.coupon_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btkilepes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).BeginInit();
            this.SuspendLayout();
            // 
            // dgadatok
            // 
            this.dgadatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgadatok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coupon_code,
            this.discount_amount});
            this.dgadatok.Location = new System.Drawing.Point(84, 40);
            this.dgadatok.Name = "dgadatok";
            this.dgadatok.RowHeadersWidth = 51;
            this.dgadatok.RowTemplate.Height = 24;
            this.dgadatok.Size = new System.Drawing.Size(566, 265);
            this.dgadatok.TabIndex = 0;
            // 
            // coupon_code
            // 
            this.coupon_code.HeaderText = "Kupon kód";
            this.coupon_code.MinimumWidth = 6;
            this.coupon_code.Name = "coupon_code";
            this.coupon_code.ReadOnly = true;
            this.coupon_code.Width = 125;
            // 
            // discount_amount
            // 
            this.discount_amount.HeaderText = "Kedvezmény mértéke (%)";
            this.discount_amount.MinimumWidth = 6;
            this.discount_amount.Name = "discount_amount";
            this.discount_amount.ReadOnly = true;
            this.discount_amount.Width = 125;
            // 
            // btkilepes
            // 
            this.btkilepes.Location = new System.Drawing.Point(486, 346);
            this.btkilepes.Margin = new System.Windows.Forms.Padding(4);
            this.btkilepes.Name = "btkilepes";
            this.btkilepes.Size = new System.Drawing.Size(164, 76);
            this.btkilepes.TabIndex = 24;
            this.btkilepes.Text = "Kilépés";
            this.btkilepes.UseVisualStyleBackColor = true;
            this.btkilepes.Click += new System.EventHandler(this.btkilepes_Click);
            // 
            // frmkuponok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btkilepes);
            this.Controls.Add(this.dgadatok);
            this.Name = "frmkuponok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aktív kuponok megtekintése";
            ((System.ComponentModel.ISupportInitialize)(this.dgadatok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgadatok;
        private System.Windows.Forms.Button btkilepes;
        private System.Windows.Forms.DataGridViewTextBoxColumn coupon_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount_amount;
    }
}