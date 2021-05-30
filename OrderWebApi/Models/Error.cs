using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
    }
}
