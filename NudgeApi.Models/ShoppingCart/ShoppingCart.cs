using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ram { get; set; }
        public string Hdd { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
    }

    public class ShoppingCartResponse
    {
        public List<ShoppingCart> Laptops { get; set; }
    }
}
