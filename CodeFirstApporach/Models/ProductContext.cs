using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApporach.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = LAPTOP-EVDOJPLN\\SQLEXPRESS01;Database=bankdatabase;Trusted_Connection = True;Encrypt=false");
            }

        }

        public virtual DbSet<Product> GetProducts { get; set; }
        public virtual DbSet<Supplierscs> GetSuppliers { get; set; }
        public virtual DbSet<Employee> GetEmployees { get; set; }

    }
}
