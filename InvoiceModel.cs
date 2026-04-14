using System;
using System.Collections.Generic;

namespace ProGlassApp.Models
{
    public class InvoiceHeader
    {
        public string PINumber { get; set; }
        public DateTime PIDate { get; set; } = DateTime.Now;
        public string CustomerTRN { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public class SpecificationRow
    {
        public string SpecName { get; set; }
        public decimal W1 { get; set; }
        public decimal H1 { get; set; }
        public decimal W2 { get; set; } = 0;
        public decimal H2 { get; set; } = 0;
        public int Qty { get; set; }
        public decimal SqmPrice { get; set; }
    }
}
