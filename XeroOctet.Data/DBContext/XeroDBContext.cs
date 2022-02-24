using Microsoft.EntityFrameworkCore;
using XeroOctet.Data.Models;

namespace XeroOctet.Data.DBContext
{
    public class XeroDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public XeroDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Invoice>().HasKey(c => new { c.InvoiceNumber });
            modelBuilder.Entity<Invoice>().Property(x => x.InvoiceAmount).HasPrecision(16, 2);
            modelBuilder.Entity<Invoice>().Property(x => x.OutstandingAmount).HasPrecision(16, 2);

            base.OnModelCreating(modelBuilder);

        }
        public virtual DbSet<Invoice> Invoice { get; set; }
        
    }
}
