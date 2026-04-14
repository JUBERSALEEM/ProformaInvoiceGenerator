using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProGlassAutomation.Core;

namespace ProGlassAutomation.Services
{
    public class DataService
    {
        // 1. स्मार्ट एक्सेल इम्पोर्ट (W1/H1 Logic)
        // यह केवल साइज लेता है, बाकी गणनाएं सिस्टम खुद करता है
        public void SmartImportFromExcel(DataGridView dgv, decimal impW1, decimal impH1, decimal impW2, decimal impH2, decimal baseSqmPrice)
        {
            // 0.5 SQM Rule के साथ एरिया निकालना
            decimal sqm = GlassCalculator.GetFinalSqm(impW1, impH1, impW2, impH2);

            // 4sqm+ सरचार्ज ऑटो-चेक (SqmPrice पर)
            decimal finalPrice = GlassCalculator.ApplySurcharge(baseSqmPrice, sqm, 20); // 20% default

            // ग्रिड में डेटा जोड़ना (W2/H2 अगर 0 हैं तो 0 ही दिखेंगे)
            dgv.Rows.Add(
                dgv.Rows.Count + 1, // Sr No
                "IMP-REF",          // Default Ref
                impW1, impH1,
                impW2, impH2,
                1,                  // Default Qty
                sqm,                // Calculated Sqm
                finalPrice          // Calculated Price with Surcharge
            );
        }

        // 2. CSV / Excel एक्सपोर्ट (Section Specification as Header)
        // यह सभी स्पेसिफिकेशन सेक्शन्स का डेटा एक साथ एक्सपोर्ट कर सकता है
        public void ExportAllToCSV(string filePath, string fullSpecName, DataGridView dgv)
        {
            StringBuilder sb = new StringBuilder();

            // हेडर में सेक्शन का पूरा नाम (6mm HD Grey...) इस्तेमाल करना
            sb.AppendLine($"Section Specification: {fullSpecName}");
            sb.AppendLine("Sr,Reference,Width 1,Height 1,Width 2,Height 2,Qty,Total Sqm,Sqm Price,Total Price");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    row.Cells["Sr"].Value,
                    row.Cells["Ref"].Value,
                    row.Cells["W1"].Value,
                    row.Cells["H1"].Value,
                    row.Cells["W2"].Value,
                    row.Cells["H2"].Value,
                    row.Cells["Qty"].Value,
                    row.Cells["Sqm"].Value,
                    row.Cells["SqmPrice"].Value,
                    row.Cells["TotalPrice"].Value);

                sb.AppendLine(line);
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("All Data exported successfully to CSV!");
        }

        // 3. ग्लोबल जॉब ऑर्डर मोड (पूरे इनवॉइस से कीमतें हटाना)
        // यह केवल कीमतों को छिपाता है, डिलीट नहीं करता
        public void SetJobOrderView(Form activeForm, bool enableJobOrder)
        {
            // फॉर्म पर मौजूद सभी स्पेसिफिकेशन ग्रिड्स को लूप करें
            foreach (Control ctrl in activeForm.Controls)
            {
                if (ctrl is DataGridView dgv)
                {
                    // Sqm Price और Total Price छिपाना
                    if (dgv.Columns.Contains("SqmPrice")) dgv.Columns["SqmPrice"].Visible = !enableJobOrder;
                    if (dgv.Columns.Contains("TotalPrice")) dgv.Columns["TotalPrice"].Visible = !enableJobOrder;

                    // Other Charges के Rate और Amount छिपाना
                    if (dgv.Columns.Contains("Rate")) dgv.Columns["Rate"].Visible = !enableJobOrder;
                    if (dgv.Columns.Contains("Amount")) dgv.Columns["Amount"].Visible = !enableJobOrder;
                }
            }
        }
    }
}
