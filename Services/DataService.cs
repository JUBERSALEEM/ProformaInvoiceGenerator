using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProGlassAutomation.Core;

namespace ProGlassAutomation.Services
{
    public class DataService
    {
        // स्मार्ट इम्पोर्ट: केवल W/H लेता है, Sqm और सरचार्ज ऑटो-कैलकुलेट करता है
        public void SmartImport(DataGridView dgv, decimal w1, decimal h1, decimal w2, decimal h2, decimal basePrice)
        {
            decimal sqm = GlassCalculator.GetFinalSqm(w1, h1, w2, h2);
            decimal finalPrice = GlassCalculator.ApplySurcharge(basePrice, sqm, 20);
            dgv.Rows.Add(dgv.Rows.Count + 1, "REF", w1, h1, w2, h2, 1, sqm, finalPrice, sqm * finalPrice);
        }

        // CSV एक्सपोर्ट: 'Section Specification' को हेडर बनाता है
        public void ExportFullCSV(DataGridView dgv, string specName, string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Section Specification: {specName}");
            sb.AppendLine("Sr,Ref,W1,H1,W2,H2,Qty,Sqm,Price,Total");
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.IsNewRow) continue;
                sb.AppendLine($"{r.Cells[0].Value},{r.Cells[1].Value},{r.Cells[2].Value},{r.Cells[3].Value},{r.Cells[4].Value},{r.Cells[5].Value},{r.Cells[6].Value},{r.Cells[7].Value},{r.Cells[8].Value},{r.Cells[9].Value}");
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
}
