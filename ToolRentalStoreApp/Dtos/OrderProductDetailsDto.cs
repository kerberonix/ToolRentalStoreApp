using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolRentalStoreApp.Dtos
{
    public class OrderProductDetailsDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // foreign key
        public int OrderId { get; set; } // foreign key
        public ProductDto Product { get; set; }
        public OrderDto Order { get; set; }
    }
}