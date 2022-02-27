﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Api;
using XeroOctet.Api.Helpers;
using XeroOctet.Data.Models;
using XeroOctet.DataAccess.Repositories.IRepositories;

namespace XeroOctet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XeroInvoiceData : ControllerBase
    {
        private readonly ILogger<XeroInvoiceDataController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public XeroInvoiceData(ILogger<XeroInvoiceDataController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("saveInvoice")]
        public async Task<IActionResult> SaveInvoice([FromBody] IEnumerable<Invoice> invoices)
        {

            try
            {
                await _unitOfWork.Invoice.AddRangeAsync(invoices);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Exception when calling apiInstance.GetInvoice: " + e.Message);
                return Ok(e.ToString());
            }

        }
    }
}
