using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XeroOctet.Data.Models;
using XeroOctet.DataAccess.Repositories.IRepositories;
using XeroOctet.Shared.DTO;

namespace XeroOctet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XeroInvoiceStoreController : ControllerBase
    {
        private readonly ILogger<XeroInvoiceStoreController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        

        public XeroInvoiceStoreController(ILogger<XeroInvoiceStoreController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("SaveInvoices")]
        public async Task<IActionResult> SaveInvoices([FromBody] IEnumerable<InvoiceDTO> invoices)
        {

            try
            {
                List<Invoice> invoice = new List<Invoice>();
                
                foreach (InvoiceDTO invoiceDTO in invoices)
                {
                    var item = new Invoice
                    {
                        InvoiceNumber = invoiceDTO.InvoiceNumber,
                        ContactName = invoiceDTO.ContactName,
                        InvoiceIssueDate = invoiceDTO.InvoiceIssueDate.GetValueOrDefault(),
                        InvoiceAmount = invoiceDTO.InvoiceAmount.GetValueOrDefault(),
                        OutstandingAmount = invoiceDTO.OutstandingAmount.GetValueOrDefault()
                    };

                    invoice.Add(item);
                    
                }

                await _unitOfWork.Invoice.AddRangeAsync(invoice);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Exception when calling XeroInvoiceData.SaveInvoice: " + e.Message);
                return Ok(e.ToString());
            }

        }
    }
}
