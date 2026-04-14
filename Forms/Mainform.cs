using System;
using System.Windows.Forms;
using ProGlassAutomation.Core; // आपके फॉर्मूला इंजन के लिए
using ProGlassAutomation.Services;

namespace ProGlassAutomation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dtpPiDate.Value = DateTime.Now; // आज की तारीख
        }

        // 1. स्पेसिफिकेशन बार से 'Auto-Spec Text' जनरेट करना
        private void btnGenerateSpec_Click(object sender, EventArgs e)
        {
            // Inputs: Thickness, Color, ASP, Inner Glass
            string spec = SpecGenerator.GenerateDgu(
                txtOuterThick.Text,
                txtOuterColor.Text,
                cmbASP.Text,
                txtInnerThick.Text,
                "with Argon Gas" // Example Extra
            );
            txtFullSpecHeader.Text = spec; // पूरी स्पेसिफिकेशन बार में सेट करना
        }

        // 2. प्राइस कैलकुलेटर (46 + 28 Logic)
        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            try
            {
                decimal outer = txtOuterPrice.Text != "" ? Convert.ToDecimal(txtOuterPrice.Text) : 0;
                decimal inner = txtInnerPrice.Text != "" ? Convert.ToDecimal(txtInnerPrice.Text) : 0;
                decimal aspPrice = 45; // 12mm का डिफ़ॉल्ट रेट (इसे डायनामिक भी कर सकते हैं)
                decimal profit = txtProfitMargin.Text != "" ? Convert.ToDecimal(txtProfitMargin.Text) : 15;

                // Formula: (Outer+Inner)/0.85 + ASP + Profit%
                decimal finalRate = GlassCalculator.GetDguPrice(outer, inner, aspPrice, profit);

                // इस रेट को ग्रिड की पहली रो (First Row) में भेजना
                if (dgvSpecs.Rows.Count > 0)
                {
                    dgvSpecs.Rows[0].Cells["SqmPrice"].Value = finalRate;
                }
                MessageBox.Show($"Calculated Price: {finalRate} AED applied.");
            }
            catch (Exception ex) { MessageBox.Show("Error in Calculation: " + ex.Message); }
        }

        // 3. ग्रिड ऑटोमेशन: Enter दबाने पर नई रो और रेट सिंक
        private void dgvSpecs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int currentRow = dgvSpecs.CurrentCell.RowIndex;

                // पहली रो से बेस रेट उठाना
                decimal firstRowPrice = Convert.ToDecimal(dgvSpecs.Rows[0].Cells["SqmPrice"].Value ?? 0);

                if (currentRow == dgvSpecs.Rows.Count - 1)
                {
                    dgvSpecs.Rows.Add();
                    dgvSpecs.Rows[currentRow + 1].Cells["SqmPrice"].Value = firstRowPrice;
                    dgvSpecs.CurrentCell = dgvSpecs.Rows[currentRow + 1].Cells["Reference"];
                }
            }
        }

        // 4. 0.5 SQM Rule और 4sqm+ सरचार्ज (केवल SqmPrice पर)
        private void dgvSpecs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvSpecs.Rows[e.RowIndex];
            decimal w1 = Convert.ToDecimal(row.Cells["W1"].Value ?? 0);
            decimal h1 = Convert.ToDecimal(row.Cells["H1"].Value ?? 0);
            decimal w2 = Convert.ToDecimal(row.Cells["W2"].Value ?? 0);
            decimal h2 = Convert.ToDecimal(row.Cells["H2"].Value ?? 0);

            // 0.5 Rule logic
            decimal sqm = GlassCalculator.GetFinalSqm(w1, h1, w2, h2);
            row.Cells["TotalSqm"].Value = sqm;

            // 1st Row का बेस रेट प्राप्त करें
            decimal baseRate = Convert.ToDecimal(dgvSpecs.Rows[0].Cells["SqmPrice"].Value ?? 0);

            // सरचार्ज केवल 4sqm+ पर ऑटो-अप्लाई करना
            if (sqm > 4.0m)
                row.Cells["SqmPrice"].Value = Math.Round(baseRate * 1.20m); // 20% Surcharge
            else
                row.Cells["SqmPrice"].Value = baseRate;

            // Row Total
            int qty = Convert.ToInt32(row.Cells["Qty"].Value ?? 1);
            decimal currentPrice = Convert.ToDecimal(row.Cells["SqmPrice"].Value);
            row.Cells["TotalPrice"].Value = sqm * qty * currentPrice;
        }

        // 5. जॉब ऑर्डर (Global Toggle)
        private void btnJobOrder_Click(object sender, EventArgs e)
        {
            bool isJob = (lblTitle.Text == "PROFORMA INVOICE");
            dgvSpecs.Columns["SqmPrice"].Visible = !isJob;
            dgvSpecs.Columns["TotalPrice"].Visible = !isJob;
            lblTitle.Text = isJob ? "JOB ORDER" : "PROFORMA INVOICE";
        }
    }
}
