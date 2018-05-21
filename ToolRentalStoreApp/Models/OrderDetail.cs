namespace ToolRentalStoreApp.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // foreign key
        public int OrderId { get; set; } // foreign key
        public Product Product { get; set; } // navigation property
        public Order Order { get; set; } // navigation property
    }
}