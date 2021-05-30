using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Models
{
    public class Postamat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
    }
    public class PostamatGetDTO
    {
        public int Number { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
    }
}
