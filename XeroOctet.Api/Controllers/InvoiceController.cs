using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using XeroOctet.Data.Configuration;

namespace XeroOctet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        
        private readonly ILogger<InvoiceController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceController(ILogger<InvoiceController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var invoices = await _unitOfWork.Invoice.All();
            return Ok(invoices);
        }
    }
}
