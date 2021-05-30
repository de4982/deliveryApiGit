using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public int Number { get; set; }
        public Status Status { get; set; }
        public string Products { get; set; }
        public decimal Cost { get; set; }
        public Postamat Postamat { get; set; }
        public string Phone { get; set; }
        public string Recipient { get; set; }

    }

    public class OrderGetDTO
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public List<string> Products { get; set; }
        public decimal Cost { get; set; }
        public int Postamat { get; set; }
        public string Phone { get; set; }
        public string Recipient { get; set; }

    }

    public class OrderCreateDTO
    {
        
        public int Number { get; set; }
        public List<string> Products { get; set; }
        public decimal Cost { get; set; }
        public int Postamat { get; set; }
        public string Phone { get; set; }
        public string Recipient { get; set; }

    }
    public class OrderUpdateDTO
    {
        public List<string> Products { get; set; }
        public decimal Cost { get; set; }
        public int Postamat { get; set; }
        public string Phone { get; set; }
        public string Recipient { get; set; }

    }

}
