using System;
using System.Collections.Generic;

namespace ProGlassAutomation.Models
{
	// 1. मुख्य इनवॉइस का ढांचा
	public class ProformaInvoice
	{
		public int ID { get; set; }
		public string PINumber { get; set; }
		public DateTime PIDate { get; set; } = DateTime.Now; // आज की तारीख ऑटो-डिटेक्ट
		public string LpoNumber { get; set; }
		public DateTime LpoDate { get; set; }

		// ग्राहक विवरण
		public string CustomerName { get; set; }
		public string CustomerTRN_VAT { get; set; } // सिंगल बॉक्स (No separation)
		public string Mobile { get; set; }
		public string Attention { get; set; }

		// स्टेटस ट्रैकिंग (Pending/Confirmed)
		// केवल 'Confirmed' ही मंथली रिपोर्ट में गिना जाएगा
		public string Status { get; set; } = "Pending";

		public List<SpecSection> Sections { get; set; } = new List<SpecSection>();
	}

	// 2. हर स्पेसिफिकेशन ब्लॉक के लिए
	public class SpecSection
	{
		public string FullSpecHeader { get; set; } // ऑटो-जेनरेटेड बार (e.g. 6mm HD Grey...)
		public List<SpecRow> GridRows { get; set; } = new List<SpecRow>();

		public decimal SectionTotalQty { get; set; }
		public decimal SectionTotalSqm { get; set; }
	}

	// 3. ग्रिड की हर लाइन (Row) के लिए
	public class SpecRow
	{
		public int SrNo { get; set; }
		public string Reference { get; set; }
		public decimal W1 { get; set; }
		public decimal H1 { get; set; }
		public decimal W2 { get; set; } = 0; // डिफ़ॉल्ट 0 दिखेगा
		public decimal H2 { get; set; } = 0; // डिफ़ॉल्ट 0 दिखेगा
		public int Qty { get; set; }

		// कैलकुलेटेड वैल्यूज
		public decimal Sqm { get; set; }      // 0.5 Rule के साथ
		public decimal SqmPrice { get; set; } // 4sqm+ सरचार्ज के साथ
		public decimal TotalRowPrice => Sqm * Qty * SqmPrice;
	}
}
