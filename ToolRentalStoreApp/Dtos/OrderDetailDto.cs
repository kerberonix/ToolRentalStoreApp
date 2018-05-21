using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolRentalStoreApp.Dtos
{
    public class OrderDetailDto
    {
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}