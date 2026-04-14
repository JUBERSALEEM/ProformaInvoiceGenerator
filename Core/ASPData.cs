using System.Collections.Generic;

namespace ProGlassApp.Core
{
    public static class ASPData
    {
        public static List<string> GetSpacers()
        {
            return new List<string> {
                "6mm", "8mm", "10mm", "12mm", "14mm", "16mm", "18mm", "20mm", "22mm", "24mm",
                "6mm Black", "8mm Black", "10mm Black", "12mm Black", "14mm Black", "16mm Black",
                "18mm Black", "20mm Black", "22mm Black", "24mm Black"
            };
        }
    }
}
