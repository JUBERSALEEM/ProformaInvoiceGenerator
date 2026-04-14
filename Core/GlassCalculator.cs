using System;

namespace ProGlassApp.Core
{
    public static class GlassCalculator
    {
        // 1. 0.5 SQM Rule: यदि एरिया 0.5 से कम है, तो उसे 0.5 मानेंगे
        public static decimal GetFinalSqm(decimal w1, decimal h1, decimal w2, decimal h2)
        {
            decimal area = ((w1 * h1) + (w2 * h2)) / 1000000m; // mm to sqm
            return (area > 0 && area < 0.5m) ? 0.5m : area;
        }

        // 2. 4sqm Surcharge: केवल SqmPrice पर ऑटो-अप्लाई होगा
        public static decimal ApplySurcharge(decimal basePrice, decimal area, decimal percent)
        {
            if (area > 4.0m)
                return Math.Round(basePrice + (basePrice * (percent / 100)));
            return basePrice;
        }

        // 3. DGU Price Generator: (Outer + Inner)/0.85 + ASP + Profit
        // Note: 'Outer' price here is the Sheet Price used in Wastage
        public static decimal GetDguPrice(decimal outer, decimal inner, decimal asp, decimal profit)
        {
            decimal ans2 = (outer + inner) / 0.85m;
            decimal ans3 = ans2 + asp;
            return Math.Round(ans3 + (ans3 * profit / 100));
        }

        // 4. SGU Price Generator: (Sheet/0.85) + Cutting + Tempering + Profit
        public static decimal GetSguPrice(decimal sheet, decimal cut, decimal temp, decimal profit)
        {
            decimal ans2 = (sheet / 0.85m) + cut + temp;
            return Math.Round(ans2 + (ans2 * profit / 100));
        }

        // 5. Lami Price Generator: (Outer + Inner)/0.85 + PVB + Profit
        public static decimal GetLamiPrice(decimal outer, decimal inner, decimal pvb, decimal profit)
        {
            decimal ans2 = (outer + inner) / 0.85m;
            decimal ans3 = ans2 + pvb;
            return Math.Round(ans3 + (ans3 * profit / 100));
        }

        // 6. Polish Logic: SGU (x2) vs Lami/DGU (x4)
        public static decimal GetPolishQty(decimal w, decimal h, string type)
        {
            decimal baseQty = (w * h) / 1000;
            return (type == "SGU") ? baseQty * 2 : baseQty * 4;
        }

        // 7. Wastage Answer 3: (Sheet Price / (OptSqm/100)) - (Sheet Price / 0.85)
        public static decimal GetWastageRate(decimal outerSheetPrice, decimal optSqmManual)
        {
            decimal ans1 = outerSheetPrice / (optSqmManual / 100);
            decimal ans2 = outerSheetPrice / 0.85m;
            return Math.Round(ans1 - ans2, 2);
        }
    }
}
