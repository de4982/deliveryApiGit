using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Models
{
    public class Status
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

    }
}
