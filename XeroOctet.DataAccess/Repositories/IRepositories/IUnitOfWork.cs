namespace XeroOctet.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoice{ get; }
        void Save();
    }
}
