using System;

namespace ProGlassApp.Core
{
    public static class GlassCalculator
    {
        // 0.5 SQM Rule: 0.5 से कम होने पर 0.5 मानेंगे
        public static decimal GetSqm(decimal w1, decimal h1, decimal w2, decimal h2)
        {
            decimal area = ((w1 * h1) + (w2 * h2)) / 1000000m; // mm to sqm
            return (area > 0 && area < 0.5m) ? 0.5m : area;
        }

        // DGU Price Logic: (Outer+Inner)/0.85 + ASP + Profit
        public static decimal CalculateDguPrice(decimal outer, decimal inner, decimal asp, decimal profit)
        {
            decimal baseCost = (outer + inner) / 0.85m;
            decimal totalWithAsp = baseCost + asp;
            return Math.Round(totalWithAsp + (totalWithAsp * profit / 100));
        }

        // 4sqm Surcharge: केवल SqmPrice पर अप्लाई होगा
        public static decimal ApplySurcharge(decimal basePrice, decimal area, decimal percent)
        {
            if (area > 4.0m)
                return Math.Round(basePrice + (basePrice * percent / 100));
            return basePrice;
        }
    }
}
