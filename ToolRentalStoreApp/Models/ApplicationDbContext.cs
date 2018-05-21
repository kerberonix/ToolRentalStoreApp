using System.Data.Entity;

namespace ToolRentalStoreApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // tells entity framework what the name of the connection string is
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {

        }
    }
}