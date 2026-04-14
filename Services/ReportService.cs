using System;
using System.Collections.Generic;
using System.Linq;
using ProGlassAutomation.Models;
using ProGlassAutomation.Core;

namespace ProGlassAutomation.Services
{
    public class ReportService
    {
        // 1. मंथली रिपोर्ट समरी: केवल 'Confirmed' PI का डेटा जोड़ना
        public void GetConfirmedSummary(List<ProformaInvoice> allInvoices, out decimal totalSqm, out decimal totalGross)
        {
            totalSqm = 0;
            totalGross = 0;

            // केवल Confirmed स्टेटस वाली PI को फ़िल्टर करना
            var confirmedInvoices = allInvoices.Where(i => i.Status == "Confirmed").ToList();

            foreach (var invoice in confirmedInvoices)
            {
                foreach (var section in invoice.Sections)
                {
                    totalSqm += section.TotalSqm;
                    totalGross += section.TotalGross;
                }
            }
        }

        // 2. वेस्टेज लिंकिंग लॉजिक: Ans 3 को 'Other Charges' के Rate में भेजना
        public decimal GetWastageRateForCharge(decimal outerSheetPrice, decimal optSqmManual)
        {
            // Ans 1 = Sheet Price / (Optimized Sqm / 10) -> (Your Formula Update)
            decimal ans1 = outerSheetPrice / (optSqmManual / 10);

            // Ans 2 = Sheet Price / 0.85
            decimal ans2 = outerSheetPrice / 0.85m;

            // Final Ans 3
            decimal result = ans1 - ans2;

            return Math.Round(result, 2); // यह वैल्यू 'Other Charges' के रेट में ऑटो-पिक होगी
        }
    }
}
