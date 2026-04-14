namespace ProGlassApp.Services
{
    public class ReportService
    {
        // केवल 'Confirmed' स्टेटस वाले डेटा को रिपोर्ट में जोड़ना
        public void GetMonthlySummary(string status, decimal amount, decimal sqm, out decimal totalAmt, out decimal totalSqm)
        {
            totalAmt = 0; totalSqm = 0;
            if (status == "Confirmed")
            {
                totalAmt += amount;
                totalSqm += sqm;
            }
        }
    }
}
