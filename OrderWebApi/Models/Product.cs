using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        // public Order Order { get; set; }
        public string Name { get; set; }
    }
}
