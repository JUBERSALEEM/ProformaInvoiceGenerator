namespace ProGlassApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvSpecs = new System.Windows.Forms.DataGridView();
            this.dtpPiDate = new System.Windows.Forms.DateTimePicker();
            this.btnJobOrder = new System.Windows.Forms.Button();

            // Columns (Sr, Ref, W1, H1, W2, H2, Qty, Sqm, Price, Total)
            // Qty कॉलम को साधारण TextBoxColumn बनाया गया है (No Arrows)
            DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
            colQty.HeaderText = "Qty";
            colQty.Name = "Qty";
            colQty.Width = 60;

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecs)).BeginInit();
            this.SuspendLayout();

            // Big Logo Box
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Size = new System.Drawing.Size(200, 120);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // Title Label
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(230, 12);
            this.lblTitle.Text = "PROFORMA INVOICE";

            // Main Specs Grid Setup
            this.dgvSpecs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpecs.Location = new System.Drawing.Point(12, 220);
            this.dgvSpecs.Size = new System.Drawing.Size(1100, 350);
            this.dgvSpecs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSpecs_KeyDown);
            this.dgvSpecs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpecs_CellEndEdit);

            // MainForm properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 800);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvSpecs);
            this.Controls.Add(this.dtpPiDate);
            this.Controls.Add(this.btnJobOrder);
            this.Name = "MainForm";
            this.Text = "Glass Automation System";

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvSpecs;
        private System.Windows.Forms.DateTimePicker dtpPiDate;
        private System.Windows.Forms.Button btnJobOrder;
        private System.Windows.Forms.DataGridView dgvOtherCharges;
    }
}
