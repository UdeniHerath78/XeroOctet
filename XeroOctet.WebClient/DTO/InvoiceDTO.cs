using System;

namespace XeroOctet.WebClient.DTO
{
    public class InvoiceDTO
    {
        public string InvoiceNumber { get; set; }
        public string ContactName { get; set; }
        public DateTime? InvoiceIssueDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? OutstandingAmount { get; set; }
    }
}
