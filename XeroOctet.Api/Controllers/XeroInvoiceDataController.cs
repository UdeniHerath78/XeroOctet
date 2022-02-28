using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Api;
using XeroOctet.Api.Helpers;
using XeroOctet.Api.Services;

namespace XeroOctet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XeroInvoiceDataController : ControllerBase
    {
        private readonly ILogger<XeroInvoiceDataController> _logger;
        private readonly IXeroSettings _xeroSettings;
        private readonly IXeroInvoiceApiService _apiService;

        public XeroInvoiceDataController(ILogger<XeroInvoiceDataController> logger, 
            IXeroSettings xeroSettings,
            IXeroInvoiceApiService apiService)
        {
            _logger = logger;
            _xeroSettings = xeroSettings;
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var xeroAccessToken = await _xeroSettings.GetXeroAccessToken();

            try
            {
                var apiInstance = new AccountingApi();
                var xeroTenantId = "";
                var sixMonthsAgo = DateTime.Now.AddMonths(-6).ToString("yyyy, MM, dd");
                var invoicesFilter = "Date >= DateTime(" + sixMonthsAgo + ")";
                var result = await apiInstance.GetInvoicesAsync(xeroAccessToken, xeroTenantId, null, invoicesFilter);
                var filteredInvoices = await _apiService.GetFilteredInvoiceData(result._Invoices);
                return Ok(filteredInvoices);
            }
            catch (Exception e)
            {
                _logger.LogError("Exception when calling apiInstance.GetInvoice: " + e.Message);
                return Ok(e.ToString());
            }

        }
    }
}
