using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolRentalStoreApp.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}