using System;

namespace ProGlassApp.Models
{
	public class InvoiceHeader
	{
		public string PINumber { get; set; }
		public DateTime PIDate { get; set; } = DateTime.Now;
		public string CustomerTRN { get; set; }
		public string Status { get; set; } = "Pending";
	}

	public class SpecRow
	{
		public string FullSpec { get; set; }
		public decimal W1 { get; set; }
		public decimal H1 { get; set; }
		public int Qty { get; set; }
		public decimal FinalSqmPrice { get; set; }
	}
}
