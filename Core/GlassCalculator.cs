using System;

namespace ProGlassApp.Core
{
    public static class GlassCalculator
    {
        // 0.5 SQM Rule & Surcharge logic
        public static decimal GetFinalSqm(decimal w1, decimal h1, decimal w2, decimal h2)
        {
            decimal area = ((w1 * h1) + (w2 * h2)) / 1000000m;
            return (area > 0 && area < 0.5m) ? 0.5m : area;
        }

        public static decimal ApplySurcharge(decimal price, decimal area, decimal pct) =>
            (area > 4.0m) ? Math.Round(price + (price * pct / 100)) : price;

        // Pricing Engines
        public static decimal GetDguPrice(decimal outr, decimal innr, decimal asp, decimal prft) =>
            Math.Round(((outr + innr) / 0.85m + asp) * (1 + prft / 100));

        public static decimal GetSguPrice(decimal sheet, decimal cut, decimal temp, decimal prft) =>
            Math.Round(((sheet / 0.85m) + cut + temp) * (1 + prft / 100));

        public static decimal GetLamiPrice(decimal outr, decimal innr, decimal pvb, decimal prft) =>
            Math.Round(((outr + innr) / 0.85m + pvb) * (1 + prft / 100));

        // Polish Formula: SGU x2, DGU/Lami x4
        public static decimal GetPolish(decimal w, decimal h, string type) =>
            ((w * h) / 1000) * (type == "SGU" ? 2 : 4);
    }
}
