using System.Data;
using System.Data.SqlClient;

namespace ProGlassAutomation.Services
{
    public class ReportService
    {
        private string connString = "Server=YOUR_SERVER;Database=GlassAutomationDB;Trusted_Connection=True;";

        // केवल 'Confirmed' स्टेटस वाली PI का समरी डेटा प्राप्त करना
        public DataTable GetMonthlyConfirmedSummary()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SQL View का उपयोग करके डेटा उठाना
                string sql = "SELECT * FROM View_MonthlyConfirmedReport";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
