using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.DataContracts
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
    public class LaptopResponse
    {
        public List<Laptop> Laptops { get; set; }
    }
    
}
