using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProGlassApp.Services
{
    public class DataService
    {
        // स्मार्ट इम्पोर्ट: केवल W1, H1 लेता है, बाकी ऑटो-कैलकुलेट करता है
        public void SmartImport(decimal w1, decimal h1, decimal w2, decimal h2, decimal basePrice)
        {
            decimal sqm = Core.GlassCalculator.GetFinalSqm(w1, h1, w2, h2);
            decimal finalPrice = Core.GlassCalculator.ApplySurcharge(basePrice, sqm, 20); // 4sqm+ logic
            // Grid update logic here...
        }

        // CSV एक्सपोर्ट: 'Section Specification' को हेडर के रूप में उपयोग करता है
        public void ExportToCSV(DataGridView dgv, string fullSpecName, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Section Specification: {fullSpecName}");
            sb.AppendLine("Sr,Ref,W1,H1,W2,H2,Qty,Total Sqm,Sqm Price,Total");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine($"{row.Cells["Sr"].Value},{row.Cells["Ref"].Value},{row.Cells["W1"].Value},{row.Cells["H1"].Value},{row.Cells["W2"].Value},{row.Cells["H2"].Value},{row.Cells["Qty"].Value},{row.Cells["Sqm"].Value},{row.Cells["Price"].Value},{row.Cells["Total"].Value}");
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        // पूरे PI को जॉब ऑर्डर में बदलना (प्राइस छिपाना)
        public void ToggleJobOrder(Form f, bool hidePrice)
        {
            // लॉजिक: फॉर्म के सभी ग्रिड्स में Price और Amount कॉलम को Visible = false करना
        }
    }
}
