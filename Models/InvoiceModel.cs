using System;
using System.Collections.Generic;

namespace ProGlassApp.Models
{
	// मुख्य इनवॉइस की जानकारी के लिए
	public class ProformaInvoice
	{
		public int ID { get; set; }
		public string PINumber { get; set; }
		public DateTime PIDate { get; set; } = DateTime.Now; // ऑटो-डिटेक्ट आज की तारीख
		public string LpoNumber { get; set; }
		public DateTime LpoDate { get; set; }
		public int Revision { get; set; }

		// ग्राहक विवरण
		public string CustomerName { get; set; }
		public string CustomerTRN_VAT { get; set; } // सिंगल बॉक्स
		public string Mobile { get; set; }
		public string Attention { get; set; }

		// स्टेटस: केवल 'Confirmed' ही मंथली रिपोर्ट में जुड़ेगा
		public string Status { get; set; } = "Pending";

		public List<SpecificationSection> Sections { get; set; } = new List<SpecificationSection>();
	}

	// हर स्पेसिफिकेशन सेक्शन के लिए
	public class SpecificationSection
	{
		public string FullSpecHeader { get; set; } // ऑटो-जेनरेटेड स्पेसिफिकेशन बार
		public List<SpecRow> Rows { get; set; } = new List<SpecRow>();

		public decimal TotalQty { get; set; }
		public decimal TotalSqm { get; set; }
		public decimal TotalGross { get; set; }
	}

	// ग्रिड की प्रत्येक रो (Row) के लिए
	public class SpecRow
	{
		public int SrNo { get; set; }
		public string Reference { get; set; }
		public decimal Width1 { get; set; }
		public decimal Height1 { get; set; }
		public decimal Width2 { get; set; } = 0; // डिफ़ॉल्ट 0 दिखेगा
		public decimal Height2 { get; set; } = 0; // डिफ़ॉल्ट 0 दिखेगा
		public int Qty { get; set; }

		// गणना (Calculated Fields)
		public decimal Sqm { get; set; } // 0.5 Rule के साथ
		public decimal SqmPrice { get; set; } // सरचार्ज के साथ
		public decimal TotalPrice => Sqm * Qty * SqmPrice;
	}
}
