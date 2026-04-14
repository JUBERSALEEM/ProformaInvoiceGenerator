namespace ProGlassApp.Core
{
	public static class SpecGenerator
	{
		public static string GenerateDguSpec(string outr, string asp, string innr, string extra)
		{
			// Example: 6mm HD Grey + 12mm ASP with U-Insert + 6mm Clear + Argon Gas
			return $"{outr} FT Glass + {asp} ASP + {innr} FT Glass {extra}".Trim();
		}

		public static string GenerateLamiSpec(string outr, string pvb, string innr, string polishType)
		{
			// Example: 8mm Clear FT + 1.52 PVB + 6mm Clear FT with All Side Polish
			return $"{outr} FT Glass + {pvb} + {innr} FT Glass with {polishType}".Trim();
		}
	}
}
