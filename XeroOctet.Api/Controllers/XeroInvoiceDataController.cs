using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Api;
using XeroOctet.Api.Helpers;

namespace XeroOctet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XeroInvoiceDataController : ControllerBase
    {
        private readonly ILogger<XeroInvoiceDataController> _logger;
        private readonly IXeroSettings _xeroSettings;

        public XeroInvoiceDataController(ILogger<XeroInvoiceDataController> logger, IXeroSettings xeroSettings)
        {
            _logger = logger;
            _xeroSettings = xeroSettings;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var xeroAccessToken = await _xeroSettings.GetXeroAccessToken();

            try
            {
                var apiInstance = new AccountingApi();
                var xeroTenantId = "";
                var result = await apiInstance.GetInvoicesAsync(xeroAccessToken, xeroTenantId);
                return Ok(result._Invoices);
            }
            catch (Exception e)
            {
                _logger.LogError("Exception when calling apiInstance.GetInvoice: " + e.Message);
                return Ok(e.ToString());
            }

        }
    }
}
