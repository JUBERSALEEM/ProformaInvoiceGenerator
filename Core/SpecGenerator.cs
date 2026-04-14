namespace ProGlassApp.Core
{
	public static class SpecGenerator
	{
		// DGU ऑटो-जेनरेटर (with U-Insert, Argon, Overlap logic)
		public static string GenerateDgu(string outr, string color, string asp, string innr, string extra)
		{
			// Example: 6mm HD Grey FT Glass + 12mm ASP with U-Insert + 6mm Clear FT Glass with Argon Gas
			return $"{outr} {color} FT Glass + {asp} ASP {extra} + {innr} FT Glass".Trim();
		}

		// SGU ऑटो-जेनरेटर
		public static string GenerateSgu(string thick, string color, string type, string processing)
		{
			// Example: 6mm Clear FT Glass with All Side Polish
			return $"{thick} {color} {type} Glass with {processing}".Trim();
		}

		// Lamination ऑटो-जेनरेटर
		public static string GenerateLami(string outr, string pvb, string innr, string extra)
		{
			return $"{outr} FT Glass + {pvb} PVB + {innr} FT Glass {extra}".Trim();
		}
	}
}
