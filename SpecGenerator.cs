namespace ProGlassApp.Core
{
	public static class SpecGenerator
	{
		public static string GenerateDguText(string thick, string color, string asp, string inner, bool uInsert, bool argon)
		{
			string opt1 = uInsert ? " with U-Insert" : "";
			string opt2 = argon ? " with Argon Gas" : "";
			return $"{thick} {color} FT Glass + {asp} ASP{opt1} + {inner} FT Glass{opt2}";
		}
	}
}
