using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolRentalStoreApp.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int CustomerId { get; set; } // foreign key
        public CustomerDto Customer { get; set; }
    }
}