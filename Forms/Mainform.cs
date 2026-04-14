using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProGlassApp.Core;      // आपके कैलकुलेशन इंजन के लिए
using ProGlassApp.Models;    // आपके डेटा मॉडल के लिए
using ProGlassApp.Services;  // एक्सेल/डेटा सर्विस के लिए

namespace ProGlassApp
{
    public partial class MainForm : Form
    {
        private DataService _dataService = new DataService();

        public MainForm()
        {
            InitializeComponent();
            // PI Date आज की तारीख पर सेट करें
            dtpPiDate.Value = DateTime.Now;
        }

        // 1. स्मार्ट ग्रिड: Enter दबाने पर नई रो और पहले रो का रेट सिंक करना
        private void dgvSpecs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // बीप साउंड बंद करें
                int currentRowIndex = dgvSpecs.CurrentCell.RowIndex;

                // पहली रो से बेस रेट उठाएं (One Spec = Same Price)
                decimal basePrice = Convert.ToDecimal(dgvSpecs.Rows[0].Cells["SqmPrice"].Value ?? 0);

                if (currentRowIndex == dgvSpecs.Rows.Count - 1)
                {
                    dgvSpecs.Rows.Add();
                    dgvSpecs.Rows[currentRowIndex + 1].Cells["SqmPrice"].Value = basePrice;
                    dgvSpecs.CurrentCell = dgvSpecs.Rows[currentRowIndex + 1].Cells["Reference"];
                }
            }
        }

        // 2. ऑटो-कैलकुलेशन: 0.5 SQM Rule और 4sqm+ सरचार्ज (केवल SqmPrice पर)
        private void dgvSpecs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvSpecs.Rows[e.RowIndex];

            // साइज इनपुट (W1, H1, W2, H2) - खाली होने पर 0
            decimal w1 = Convert.ToDecimal(row.Cells["W1"].Value ?? 0);
            decimal h1 = Convert.ToDecimal(row.Cells["H1"].Value ?? 0);
            decimal w2 = Convert.ToDecimal(row.Cells["W2"].Value ?? 0);
            decimal h2 = Convert.ToDecimal(row.Cells["H2"].Value ?? 0);

            // 0.5 SQM Rule अप्लाई करना
            decimal sqm = GlassCalculator.GetFinalSqm(w1, h1, w2, h2);
            row.Cells["TotalSqm"].Value = sqm;

            // 4sqm+ सरचार्ज लॉजिक (केवल SqmPrice पर ऑटो-अप्लाई)
            decimal baseRate = Convert.ToDecimal(dgvSpecs.Rows[0].Cells["SqmPrice"].Value ?? 0);
            if (sqm > 4.0m)
            {
                // उदाहरण: 20% सरचार्ज (इसे मैनुअल भी बदला जा सकता है)
                row.Cells["SqmPrice"].Value = Math.Round(baseRate * 1.20m);
            }
            else
            {
                row.Cells["SqmPrice"].Value = baseRate;
            }

            // रो टोटल कैलकुलेट करना
            int qty = Convert.ToInt32(row.Cells["Qty"].Value ?? 0);
            decimal finalPrice = Convert.ToDecimal(row.Cells["SqmPrice"].Value);
            row.Cells["TotalPrice"].Value = sqm * qty * finalPrice;

            UpdateGrandTotals();
        }

        // 3. ग्लोबल जॉब ऑर्डर टॉगल (पूरी इनवॉइस से कीमतें हटाना)
        private void btnConvertJobOrder_Click(object sender, EventArgs e)
        {
            bool isJobOrder = (lblTitle.Text == "PROFORMA INVOICE");

            // स्पेसिफिकेशन ग्रिड से प्राइस छिपाएं
            dgvSpecs.Columns["SqmPrice"].Visible = !isJobOrder;
            dgvSpecs.Columns["TotalPrice"].Visible = !isJobOrder;

            // अन्य शुल्कों से रेट और अमाउंट छिपाएं
            dgvOtherCharges.Columns["Rate"].Visible = !isJobOrder;
            dgvOtherCharges.Columns["Amount"].Visible = !isJobOrder;

            lblTitle.Text = isJobOrder ? "JOB ORDER" : "PROFORMA INVOICE";
            this.Text = isJobOrder ? "Job Order - Production Copy" : "Glass Automation System";
        }

        private void UpdateGrandTotals()
        {
            // यहाँ पूरी PI का टोटल Qty, Sqm और Gross AED कैलकुलेट करने का लॉजिक आएगा
        }
    }
}
