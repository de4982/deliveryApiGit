using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderWebApi.Models;

namespace OrderWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EndpointsController : ControllerBase
    {
        static readonly string[] Commands = new[]
        {
            "api/tracking/1", "api/order/add", "api/order/1"
        };

        [HttpGet]
        public IEnumerable<Endpoints> Get()
        {
            return Enumerable.Range(0, 3).Select(index => new Endpoints
            {
                Command = Commands[index]
            })
            .ToArray();
        }
    }
}