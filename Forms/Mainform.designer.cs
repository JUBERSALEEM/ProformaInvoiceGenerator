namespace ProGlassAutomation
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
            this.dgvSpecs = new System.Windows.Forms.DataGridView();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtpPiDate = new System.Windows.Forms.DateTimePicker();
            this.btnJobOrder = new System.Windows.Forms.Button();

            // Grid Column Setup (Sr, Ref, W1, H1, W2, H2, Qty, Sqm, Price, Total)
            // यहाँ W1, H1 आदि के लिए साधारण TextBoxColumn का प्रयोग है (बिना एरो के)

            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // Logo Box (बड़ा बॉक्स)
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Size = new System.Drawing.Size(150, 100);

            // Title Label
            this.lblTitle.Text = "PROFORMA INVOICE";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(180, 12);

            // Specifications Grid
            this.dgvSpecs.Location = new System.Drawing.Point(12, 200);
            this.dgvSpecs.Size = new System.Drawing.Size(950, 300);
            this.dgvSpecs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSpecs_KeyDown);
            this.dgvSpecs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpecs_CellEndEdit);

            // MainForm properties
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvSpecs);
            this.Controls.Add(this.dtpPiDate);
            this.Controls.Add(this.btnJobOrder);
            this.Name = "MainForm";
            this.Text = "Glass Automation System";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvSpecs;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpPiDate;
        private System.Windows.Forms.Button btnJobOrder;
        private System.Windows.Forms.DataGridView dgvOtherCharges; // (Other charges grid)
    }
}
