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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvSpecs = new System.Windows.Forms.DataGridView();

            // Auto-Spec Generator Controls
            this.pnlSpecBar = new System.Windows.Forms.Panel();
            this.txtOuterThick = new System.Windows.Forms.TextBox();
            this.txtOuterColor = new System.Windows.Forms.TextBox();
            this.cmbASP = new System.Windows.Forms.ComboBox();
            this.txtInnerThick = new System.Windows.Forms.TextBox();
            this.txtInnerColor = new System.Windows.Forms.TextBox();
            this.btnGenerateSpec = new System.Windows.Forms.Button();
            this.txtFullSpecHeader = new System.Windows.Forms.TextBox();

            // Price Calculator Inputs
            this.txtOuterPrice = new System.Windows.Forms.TextBox();
            this.txtInnerPrice = new System.Windows.Forms.TextBox();
            this.txtProfitMargin = new System.Windows.Forms.TextBox();
            this.btnCalculatePrice = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecs)).BeginInit();
            this.pnlSpecBar.SuspendLayout();
            this.SuspendLayout();

            // --- 1. BIG LOGO BOX ---
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(220, 130);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // --- 2. SPECIFICATION GENERATOR BAR (Full Width) ---
            this.pnlSpecBar.BackColor = System.Drawing.Color.LightGray;
            this.pnlSpecBar.Controls.Add(this.txtOuterThick);
            this.pnlSpecBar.Controls.Add(this.txtOuterColor);
            this.pnlSpecBar.Controls.Add(this.cmbASP);
            this.pnlSpecBar.Controls.Add(this.txtInnerThick);
            this.pnlSpecBar.Controls.Add(this.btnGenerateSpec);
            this.pnlSpecBar.Location = new System.Drawing.Point(12, 160);
            this.pnlSpecBar.Size = new System.Drawing.Size(1120, 45);

            // Full Spec Header Bar (Autofit)
            this.txtFullSpecHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtFullSpecHeader.Location = new System.Drawing.Point(12, 210);
            this.txtFullSpecHeader.Size = new System.Drawing.Size(1120, 30);
            this.txtFullSpecHeader.Name = "txtFullSpecHeader";

            // --- 3. PRICE CALCULATOR INPUTS ---
            // (इनपुट बॉक्स बिना अप-डाउन एरो के)
            this.txtOuterPrice.Location = new System.Drawing.Point(250, 60);
            this.txtOuterPrice.Size = new System.Drawing.Size(80, 25);
            this.txtInnerPrice.Location = new System.Drawing.Point(340, 60);
            this.txtInnerPrice.Size = new System.Drawing.Size(80, 25);

            // --- 4. MAIN SPEC GRID (No Qty Arrows) ---
            this.dgvSpecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpecs.Location = new System.Drawing.Point(12, 250);
            this.dgvSpecs.Size = new System.Drawing.Size(1120, 350);
            this.dgvSpecs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSpecs_KeyDown);
            this.dgvSpecs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpecs_CellEndEdit);

            // --- 5. MAIN FORM ---
            this.ClientSize = new System.Drawing.Size(1150, 850);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.pnlSpecBar);
            this.Controls.Add(this.txtFullSpecHeader);
            this.Controls.Add(this.dgvSpecs);
            this.Name = "MainForm";
            this.Text = "Pro-Glass Automation System";

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecs)).EndInit();
            this.pnlSpecBar.ResumeLayout(false);
            this.pnlSpecBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.DataGridView dgvSpecs;
        private System.Windows.Forms.Panel pnlSpecBar;
        private System.Windows.Forms.TextBox txtOuterThick;
        private System.Windows.Forms.TextBox txtOuterColor;
        private System.Windows.Forms.ComboBox cmbASP;
        private System.Windows.Forms.TextBox txtInnerThick;
        private System.Windows.Forms.TextBox txtInnerColor;
        private System.Windows.Forms.Button btnGenerateSpec;
        private System.Windows.Forms.TextBox txtFullSpecHeader;
        private System.Windows.Forms.TextBox txtOuterPrice;
        private System.Windows.Forms.TextBox txtInnerPrice;
        private System.Windows.Forms.TextBox txtProfitMargin;
        private System.Windows.Forms.Button btnCalculatePrice;
    }
}
