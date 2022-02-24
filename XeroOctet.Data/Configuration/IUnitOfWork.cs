using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroOctet.Data.Models;
using XeroOctet.Data.Repositories;

namespace XeroOctet.Data.Configuration
{
    public interface IUnitOfWork
    {
        IInvoiceRepository<Invoice> Invoice{ get; }
        Task CompleteAsync();
        void Dispose();
    }
}
