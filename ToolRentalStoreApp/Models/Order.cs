using System;

namespace ToolRentalStoreApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int CustomerId { get; set; } // foreign key
        public Customer Customer { get; set; } // navigation property
    }
}