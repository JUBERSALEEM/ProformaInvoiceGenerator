namespace ProGlassAutomation.Core
{
	public static class SpecGenerator
	{
		public static string GenerateDgu(string outr, string asp, string innr, string extra)
		{
			// Example: 6mm HD Grey + 12mm ASP with U-Insert + 6mm Clear + Argon
			return $"{outr} FT Glass + {asp} ASP {extra} + {innr} FT Glass".Trim();
		}

		public static string GenerateSgu(string thick, string color, string type, string processing)
		{
			return $"{thick} {color} {type} Glass with {processing}".Trim();
		}

		public static string GenerateLami(string outr, string pvb, string innr, string extra)
		{
			return $"{outr} FT Glass + {pvb} PVB + {innr} FT Glass {extra}".Trim();
		}
	}
}
