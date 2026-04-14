using System;

namespace ProGlassAutomation.Core
{
	public static class GlassCalculator
	{
		// 1. 0.5 SQM Rule
		public static decimal GetFinalSqm(decimal w1, decimal h1, decimal w2, decimal h2)
		{
			decimal area = ((w1 * h1) + (w2 * h2)) / 1000000m;
			return (area > 0 && area < 0.5m) ? 0.5m : area;
		}

		// 2. Surcharge Logic (Apply on Sqm Price only)
		public static decimal ApplySurcharge(decimal basePrice, decimal sqm, decimal surchargePct)
		{
			// अगर एरिया 4sqm से ज्यादा है तो +20% (या मैनुअल %)
			if (sqm > 4.0m)
				return Math.Round(basePrice + (basePrice * (surchargePct / 100)));
			return basePrice;
		}

		// 3. DGU Price Engine (As per your 46+28 logic)
		public static decimal GetDguPrice(decimal outer, decimal inner, decimal aspPrice, decimal profitMargin)
		{
			decimal ans1 = outer + inner;
			decimal ans2 = ans1 / 0.85m;
			decimal ans3 = ans2 + aspPrice; // 12mm=45, 16mm=50 etc.
			decimal ans4 = ans3 + (ans3 * (profitMargin / 100));
			return Math.Round(ans4); // Round to 152
		}

		// 4. SGU Price Engine (With Cutting & Tempering)
		public static decimal GetSguPrice(decimal sheet, decimal cutting, decimal tempering, decimal profit)
		{
			decimal ans2 = (sheet / 0.85m) + cutting + tempering;
			return Math.Round(ans2 + (ans2 * profit / 100));
		}

		// 5. Lamination Price Engine (With PVB Outsource)
		public static decimal GetLamiPrice(decimal outer, decimal inner, decimal pvbPrice, decimal profit)
		{
			decimal ans2 = (outer + inner) / 0.85m;
			decimal ans3 = ans2 + pvbPrice;
			return Math.Round(ans3 + (ans3 * profit / 100));
		}

		// 6. Polish Quantity Logic (SGU=x2, DGU/Lami=x4)
		public static decimal GetPolishQty(decimal w, decimal h, string glassType)
		{
			decimal baseQty = (w * h) / 1000;
			// Lamination और DGU के लिए पॉलिशिंग मात्रा 4 गुना होगी
			return (glassType == "SGU") ? baseQty * 2 : baseQty * 4;
		}

		// 7. Glass Wastage Calculation (Ans 1, 2, 3)
		public static decimal GetWastageResult(decimal outerSheetPrice, decimal optSqmManual)
		{
			// Ans 1 = Sheet Price / (OptSqm / 100)
			decimal ans1 = outerSheetPrice / (optSqmManual / 100);
			// Ans 2 = Sheet Price / 0.85
			decimal ans2 = outerSheetPrice / 0.85m;
			// Ans 3 = Result for Other Charges Rate
			return Math.Round(ans1 - ans2, 2);
		}
	}
}
