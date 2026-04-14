using System;

namespace ProGlassAutomation.Core
{
	public static class GlassCalculator
	{
		// 1. 0.5 SQM Rule (न्यूनतम क्षेत्र नियम)
		// logic: if area < 0.5 then 0.5, else actual area
		public static decimal GetFinalSqm(decimal w1, decimal h1, decimal w2, decimal h2)
		{
			decimal area = ((w1 * h1) + (w2 * h2)) / 1000000m; // mm to sqm
			if (area > 0 && area < 0.5m) return 0.5m;
			return area;
		}

		// 2. 4sqm Surcharge Logic (ऑटो-सरचार्ज केवल SqmPrice पर)
		// logic: if sqm > 4 then apply manual % (e.g. 20%)
		public static decimal ApplySurcharge(decimal baseSqmPrice, decimal area, decimal surchargePercent)
		{
			if (area > 4.0m)
			{
				return Math.Round(baseSqmPrice + (baseSqmPrice * (surchargePercent / 100)));
			}
			return baseSqmPrice;
		}

		// 3. DGU Price Generator (46 + 28 Logic)
		// Formula: (Outer + Inner) / 0.85 + ASP Price + Profit %
		public static decimal CalculateDguPrice(decimal outer, decimal inner, decimal aspPrice, decimal profitMargin)
		{
			decimal ans1 = outer + inner;
			decimal ans2 = ans1 / 0.85m;
			decimal ans3 = ans2 + aspPrice; // 12mm=45, 16mm=50 etc.
			decimal ans4 = ans3 + (ans3 * (profitMargin / 100));
			return Math.Round(ans4); // Example: 151.86 -> 152
		}

		// 4. SGU Price Generator (27 Logic)
		// Formula: (Sheet / 0.85) + Cutting + Tempering + Profit %
		public static decimal CalculateSguPrice(decimal sheet, decimal cutting, decimal tempering, decimal profitMargin)
		{
			decimal ans1 = sheet / 0.85m;
			decimal ans2 = ans1 + cutting + tempering;
			decimal final = ans2 + (ans2 * (profitMargin / 100));
			return Math.Round(final);
		}

		// 5. Lamination Price Generator (40 + 28 Logic)
		// Formula: (Outer + Inner) / 0.85 + PVB Price + Profit %
		public static decimal CalculateLamiPrice(decimal outer, decimal inner, decimal pvbPrice, decimal profitMargin)
		{
			decimal ans1 = outer + inner;
			decimal ans2 = ans1 / 0.85m;
			decimal ans3 = ans2 + pvbPrice;
			decimal final = ans3 + (ans3 * (profitMargin / 100));
			return Math.Round(final);
		}

		// 6. Polish Formula (x2 for SGU, x4 for Lami/DGU)
		public static decimal GetPolishQty(decimal w, decimal h, string type)
		{
			decimal baseQty = (w * h) / 1000;
			return (type == "SGU") ? baseQty * 2 : baseQty * 4;
		}

		// 7. Wastage Answer 3 (Linking logic)
		// logic: Ans 1 (Price/(OptSqm/100)) - Ans 2 (Price/0.85)
		public static decimal GetWastageResult(decimal outerSheetPrice, decimal optSqmManual)
		{
			decimal ans1 = outerSheetPrice / (optSqmManual / 100);
			decimal ans2 = outerSheetPrice / 0.85m;
			return Math.Round(ans1 - ans2, 2);
		}
	}
}
