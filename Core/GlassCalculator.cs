namespace ProGlassApp.Core
{
    public static partial class GlassCalculator
    {
        // DGU Price Logic: (Outer+Inner)/0.85 + ASP + Profit
        // Sheet Price is only the Outer Glass Price for Wastage Calc
        public static decimal GetDguFinalPrice(decimal outerPrice, decimal innerPrice, decimal aspPrice, decimal profitMargin)
        {
            decimal ans1 = outerPrice + innerPrice;
            decimal ans2 = ans1 / 0.85m; // 0.85 margin
            decimal ans3 = ans2 + aspPrice; // ASP from dropdown
            decimal ans4 = ans3 + (ans3 * (profitMargin / 100));
            return Math.Round(ans4); // Rounding to 152 logic
        }

        // Polish Formula: SGU (x2) vs Lami/DGU (x4)
        public static decimal GetPolishQty(decimal w, decimal h, bool isLaminationOrDgu)
        {
            decimal baseQty = (w * h) / 1000;
            return isLaminationOrDgu ? baseQty * 4 : baseQty * 2;
        }

        // Surcharge Logic: Applied ONLY to Sqm Price
        public static decimal ApplySurchargeOnPrice(decimal baseSqmPrice, decimal area, decimal surchargePct)
        {
            if (area > 4.0m)
                return Math.Round(baseSqmPrice + (baseSqmPrice * (surchargePct / 100)));
            return baseSqmPrice;
        }
    }
}
