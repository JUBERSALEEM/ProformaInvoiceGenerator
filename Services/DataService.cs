using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProGlassAutomation.Core;

namespace ProGlassAutomation.Services
{
    public class DataService
    {
        // स्मार्ट इम्पोर्ट: केवल W1/H1 लेता है, Sqm और सरचार्ज ऑटो-कैलकुलेट करता है
        public void SmartImport(DataGridView dgv, decimal w1, decimal h1, decimal w2, decimal h2, decimal basePrice)
        {
            // 1. 0.5 SQM Rule के साथ एरिया निकालना
            decimal sqm = GlassCalculator.GetFinalSqm(w1, h1, w2, h2);

            // 2. 4sqm+ सरचार्ज ऑटो-अप्लाई करना (SqmPrice पर)
            decimal finalPrice = GlassCalculator.ApplySurcharge(basePrice, sqm, 20);

            // 3. ग्रिड में डेटा जोड़ना (W2/H2 अगर 0 हैं तो 0 ही दिखेंगे)
            dgv.Rows.Add(dgv.Rows.Count + 1, "IMP-REF", w1, h1, w2, h2, 1, sqm, finalPrice, sqm * finalPrice);
        }

        // CSV एक्सपोर्ट: 'Section Specification' को हेडर के रूप में इस्तेमाल करता है
        public void ExportFullCSV(DataGridView dgv, string fullSpecName, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // हेडर में सेक्शन का पूरा नाम (उदा. 6mm HD Grey...) इस्तेमाल करना
            sb.AppendLine($"Section Specification: {fullSpecName}");
            sb.AppendLine("Sr,Ref,W1,H1,W2,H2,Qty,Total Sqm,Sqm Price,Total Price");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine($"{row.Cells["Sr"].Value},{row.Cells["Ref"].Value},{row.Cells["W1"].Value},{row.Cells["H1"].Value},{row.Cells["W2"].Value},{row.Cells["H2"].Value},{row.Cells["Qty"].Value},{row.Cells["Sqm"].Value},{row.Cells["Price"].Value},{row.Cells["Total"].Value}");
            }
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("All Data exported successfully with Full Specification Headers!");
        }
    }
}
