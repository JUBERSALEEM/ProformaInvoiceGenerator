namespace ProGlassApp.Core
{
    public static class GlassCalculator
    {
        // DGU Price Logic (As per your formula)
        // (Outer + Inner) / 0.85 + ASP Price + Profit %
        public static decimal GetDguFinalPrice(decimal outer, decimal inner, decimal aspPrice, decimal profitMargin)
        {
            decimal ans1 = outer + inner;
            decimal ans2 = ans1 / 0.85m;
            decimal ans3 = ans2 + aspPrice;
            decimal ans4 = ans3 + (ans3 * (profitMargin / 100));
            return Math.Round(ans4); // Rounding to nearest whole number (e.g. 152)
        }

        // Lamination Price Logic
        // (Outer + Inner) / 0.85 + PVB Price + Profit %
        public static decimal GetLamiFinalPrice(decimal outer, decimal inner, decimal pvbPrice, decimal profitMargin)
        {
            decimal ans2 = (outer + inner) / 0.85m;
            decimal ans3 = ans2 + pvbPrice;
            decimal ans4 = ans3 + (ans3 * (profitMargin / 100));
            return Math.Round(ans4);
        }

        // SGU Price Logic
        // (Sheet / 0.85) + Cutting + Tempering + Profit %
        public static decimal GetSguFinalPrice(decimal sheet, decimal cutting, decimal tempering, decimal profit)
        {
            decimal ans2 = (sheet / 0.85m) + cutting + tempering;
            return Math.Round(ans2 + (ans2 * profit / 100));
        }
    }
}
