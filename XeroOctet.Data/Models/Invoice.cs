﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroOctet.Data.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InvoiceNumber { get; set; }
        public string ContactName { get; set; }
        public DateTime InvoiceIssueDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal OutstandingAmount { get; set; }
        public string Status { get; set; }
        public string CurrencyCode { get; set; }
               
    }
}
