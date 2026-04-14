using System;
using System.Windows.Forms;
using ProGlassAutomation.Core; // कैलकुलेशन इंजन के लिए
using ProGlassAutomation.Models;

namespace ProGlassAutomation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // आज की तारीख ऑटो-सेट करें
            dtpPiDate.Value = DateTime.Now;
        }

        // 1. स्मार्ट ग्रिड: Enter दबाने पर नई रो और रेट सिंक करना
        private void dgvSpecs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int currentRow = dgvSpecs.CurrentCell.RowIndex;

                if (currentRow == dgvSpecs.Rows.Count - 1)
                {
                    // पहली रो से रेट उठाएं
                    decimal firstRowPrice = Convert.ToDecimal(dgvSpecs.Rows[0].Cells["SqmPrice"].Value ?? 0);

                    dgvSpecs.Rows.Add();
                    dgvSpecs.Rows[currentRow + 1].Cells["SqmPrice"].Value = firstRowPrice;
                    dgvSpecs.CurrentCell = dgvSpecs.Rows[currentRow + 1].Cells["Reference"];
                }
            }
        }

        // 2. ऑटो-कैलकुलेशन: 0.5 Rule और 4sqm+ सरचार्ज
        private void dgvSpecs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvSpecs.Rows[e.RowIndex];
            decimal w1 = Convert.ToDecimal(row.Cells["W1"].Value ?? 0);
            decimal h1 = Convert.ToDecimal(row.Cells["H1"].Value ?? 0);
            decimal w2 = Convert.ToDecimal(row.Cells["W2"].Value ?? 0);
            decimal h2 = Convert.ToDecimal(row.Cells["H2"].Value ?? 0);

            // 0.5 Rule Logic
            decimal finalSqm = GlassCalculator.GetFinalSqm(w1, h1, w2, h2);
            row.Cells["TotalSqm"].Value = finalSqm;

            // 4sqm Surcharge (केवल SqmPrice पर)
            decimal basePrice = Convert.ToDecimal(row.Cells["SqmPrice"].Value ?? 0);
            row.Cells["SqmPrice"].Value = GlassCalculator.ApplySurcharge(basePrice, finalSqm, 20);

            // Total Price Calculation
            int qty = Convert.ToInt32(row.Cells["Qty"].Value ?? 0);
            row.Cells["TotalPrice"].Value = finalSqm * qty * (decimal)row.Cells["SqmPrice"].Value;
        }

        // 3. ग्लोबल जॉब ऑर्डर टॉगल
        private void btnJobOrder_Click(object sender, EventArgs e)
        {
            bool isJob = (lblTitle.Text == "PROFORMA INVOICE");
            dgvSpecs.Columns["SqmPrice"].Visible = !isJob;
            dgvSpecs.Columns["TotalPrice"].Visible = !isJob;
            dgvOtherCharges.Columns["Rate"].Visible = !isJob;
            dgvOtherCharges.Columns["Amount"].Visible = !isJob;

            lblTitle.Text = isJob ? "JOB ORDER" : "PROFORMA INVOICE";
        }
    }
}
