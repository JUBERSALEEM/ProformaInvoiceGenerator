using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProGlassApp.Services
{
    public class DataService
    {
        public void ExportCSV(DataGridView dgv, string specName, string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Section Specification: {specName}");
            sb.AppendLine("Sr,Ref,W1,H1,W2,H2,Qty,Sqm,Price,Total");
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value},0,0,{row.Cells[6].Value}");
            }
            File.WriteAllText(path, sb.ToString());
        }

        public void ToggleJobOrder(DataGridView dgv, bool isJob)
        {
            dgv.Columns["SqmPrice"].Visible = !isJob;
            dgv.Columns["Total"].Visible = !isJob;
        }
    }
}
