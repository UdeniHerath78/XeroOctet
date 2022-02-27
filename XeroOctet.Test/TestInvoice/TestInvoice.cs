using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using XeroOctet.Data.DBContext;
using XeroOctet.Data.Models;
using XeroOctet.DataAccess.Repositories;
using XeroOctet.DataAccess.Repositories.IRepositories;
using Xunit;
using System.Linq;
using System.Globalization;

namespace XeroOctet.Test.TestInvoice
{
    public class TestInvoice
    {
        [Fact]
        public async void InvoiceRepository_Add_Invoice_Record_When_Invoice_Status_is_Null()
        {
            
            //Arrange 
            IUnitOfWork sut = GetInMemoryInvoiceRepository();

            Invoice invoice = new Invoice()
            {
                InvoiceNumber = "PCR1000",
                ContactName = "John",
                InvoiceAmount = 100000,
                CurrencyCode = "AUD",
                InvoiceIssueDate = DateTime.ParseExact("25/02/2022 23:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                OutstandingAmount = 0
            };
                       
            //Act

            var savedInvoice = await sut.Invoice.AddAsync(invoice);
            sut.Save();

            var count = await sut.Invoice.GetAllAsync();

            var numberOfRecords = count.Count();

            //Assert 
            Assert.Equal(1, numberOfRecords);
            
            Assert.Equal("PCR1000", savedInvoice.InvoiceNumber);
            Assert.Equal("John", savedInvoice.ContactName);
            Assert.Equal("100000", savedInvoice.InvoiceAmount.ToString());
            Assert.Equal("AUD", savedInvoice.CurrencyCode);
            Assert.Equal("25/02/2022 11:00:00 PM", savedInvoice.InvoiceIssueDate.ToString());
            Assert.Equal("0", savedInvoice.OutstandingAmount.ToString());
            Assert.Null(savedInvoice.Status);
        }

        private IUnitOfWork GetInMemoryInvoiceRepository()
        {
            var logger = new Mock<ILogger<UnitOfWork>>();
            DbContextOptions<XeroDBContext> options;
            var builder = new DbContextOptionsBuilder<XeroDBContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            options = builder.Options;
            XeroDBContext invoiceDataContext = new XeroDBContext(options);
            invoiceDataContext.Database.EnsureDeleted();
            invoiceDataContext.Database.EnsureCreated();
            return new UnitOfWork(invoiceDataContext, logger.Object);
        }

        /// <summary>
        /// Sample data - When need to test queries
        /// </summary>
        /// <param name="context"></param>
        private void Seed(IUnitOfWork context)
        {
            var invoices = new[]
            {
                new Invoice { InvoiceNumber = "PCR9000" , ContactName = "Henry" , CurrencyCode = "AUD" , InvoiceAmount = 60000 , OutstandingAmount = 0 , Status = "PAID" },
                new Invoice { InvoiceNumber = "PCR9001" , ContactName = "Sam" , CurrencyCode = "AUD" , InvoiceAmount = 120000 , OutstandingAmount = 7000 , Status = "NOTPAID" },
                new Invoice { InvoiceNumber = "PCR9002" , ContactName = "Matt" , CurrencyCode = "AUD" , InvoiceAmount = 180000 , OutstandingAmount = 0 , Status = "PAID" },
                new Invoice { InvoiceNumber = "PCR9003" , ContactName = "John" , CurrencyCode = "AUD" , InvoiceAmount = 400000 , OutstandingAmount = 200000 , Status = "NOTPAID" },
                new Invoice { InvoiceNumber = "PCR9004" , ContactName = "Tom" , CurrencyCode = "AUD" , InvoiceAmount = 200000 , OutstandingAmount = 87000 , Status = "PAID" },
            };

            context.Invoice.AddRangeAsync(invoices);
            
        }
    }
}
