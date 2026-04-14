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
        // 1. स्मार्ट इम्पोर्ट: एक्सेल से केवल W1, H1, W2, H2 लेना
        // बाकी Sqm, Surcharge और Price सिस्टम खुद कैलकुलेट करेगा
        public void SmartImportFromExcel(DataGridView dgv, decimal importedW1, decimal importedH1, decimal basePrice)
        {
            // 0.5 Rule के साथ Sqm निकालना
            decimal sqm = GlassCalculator.GetFinalSqm(importedW1, importedH1, 0, 0);

            // 4sqm+ सरचार्ज ऑटो-अप्लाई करना
            decimal finalPrice = GlassCalculator.ApplySurcharge(basePrice, sqm, 20);

            // ग्रिड में डेटा जोड़ना
            dgv.Rows.Add(dgv.Rows.Count + 1, "IMP-REF", importedW1, importedH1, 0, 0, 1, sqm, finalPrice);
        }

        // 2. CSV एक्सपोर्ट: 'Section Specification' को हेडर बनाना
        public void ExportFullToCSV(DataGridView dgv, string fullSpecName, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // हेडर में सेक्शन का पूरा नाम (e.g. 6mm HD Grey + 12mm ASP...)
            sb.AppendLine($"Section Specification: {fullSpecName}");
            sb.AppendLine("Sr,Ref,W1,H1,W2,H2,Qty,Total Sqm,Sqm Price,Total Price");

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
                    row.Cells["TotalSqm"].Value,
                    row.Cells["SqmPrice"].Value,
                    row.Cells["TotalPrice"].Value);

                sb.AppendLine(line);
            }

            File.WriteAllText(filePath, sb.ToString());
            MessageBox.Show("Full Specification Data Exported Successfully to CSV/Excel.");
        }
    }
}
