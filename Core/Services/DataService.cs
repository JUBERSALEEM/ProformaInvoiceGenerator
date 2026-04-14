using System.IO;
using System.Text;

namespace ProGlassApp.Services
{
    public class DataService
    {
        public void ExportFullCSV(string specName, string dataRows, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Section Specification: {specName}"); // Header fix
            sb.AppendLine("Sr,Ref,W1,H1,W2,H2,Qty,Total Sqm,Sqm Price,Total");
            sb.Append(dataRows);
            File.WriteAllText(filePath, sb.ToString());
        }

        // Job Order Logic for entire PI
        public void SetGlobalJobOrder(bool isJobOrder)
        {
            // Backend logic to hide prices globally in print
        }
    }
}
