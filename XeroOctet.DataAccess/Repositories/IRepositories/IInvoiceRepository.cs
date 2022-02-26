using XeroOctet.Data.Models;
using XeroOctet.DataAccess.Repositories.IRepositories;

namespace XeroOctet.DataAccess.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        void Update(Invoice invoice);
       
    }
}
