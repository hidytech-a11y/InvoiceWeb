using InvoiceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceWeb.AppData
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; } = null!;
    }
}
