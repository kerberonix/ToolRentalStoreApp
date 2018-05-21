using System;

namespace ToolRentalStoreApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateAdded { get; set; }
    }
}