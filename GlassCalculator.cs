using System;

namespace ProGlassApp.Core
{
    public static class GlassCalculator
    {
        // 0.5 SQM Rule: 0.5 से कम होने पर 0.5 मानेंगे
        public static decimal GetSqm(decimal w1, decimal h1, decimal w2, decimal h2)
        {
            decimal area = ((w1 * h1) + (w2 * h2)) / 1000000m; // mm to sqm conversion
            return (area > 0 && area < 0.5m) ? 0.5m : area;
        }

        // DGU Price Generator (As per your formula)
        public static decimal CalculateDguPrice(decimal outer, decimal inner, decimal aspPrice, decimal profitMargin)
        {
            decimal ans2 = (outer + inner) / 0.85m;
            decimal ans3 = ans2 + aspPrice;
            decimal final = ans3 + (ans3 * (profitMargin / 100));
            return Math.Round(final); // Example: 151.86 -> 152
        }

        // 4sqm Surcharge Logic (Apply on SqmPrice only)
        public static decimal ApplySurcharge(decimal basePrice, decimal area, decimal percent)
        {
            if (area > 4.0m)
                return Math.Round(basePrice + (basePrice * (percent / 100)));
            return basePrice;
        }
    }
}
