namespace ProGlassApp.Core
{
	public static class SpecGenerator
	{
		public static string Generate(string type, string t1, string c1, string asp = "", string t2 = "", string c2 = "", string extra = "")
		{
			if (type == "DGU")
				return $"{t1} {c1} FT + {asp} ASP + {t2} {c2} FT Glass {extra}".Trim();
			return $"{t1} {c1} FT Glass {extra}".Trim();
		}
	}
}
