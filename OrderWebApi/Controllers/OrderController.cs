using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderWebApi.Models;
using OrderWebApi.Services;
using OrderWebApi.Services.Interfaces;

namespace OrderWebApi.Controllers
{

    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/tracking/{number}")]
        public ActionResult<OrderGetDTO> GetOrder(int number)
        {
            if (_service.IsAccessDenied(Request))
                return Unauthorized();
            var order = _service.Get(number);
            if (order == null)
                return NotFound();
            return order;
        }

        [HttpPost]
        [Route("api/order/add")]
        public ActionResult<OrderGetDTO> PostOrder(OrderCreateDTO _order)
        {
            var message = "";
            if (_service.IsAccessDenied(Request))
                return Unauthorized();
            var order = _service.Add(_order, out message);
            if (order == null)
                return BadRequest(message);
            return CreatedAtAction("GetOrder", new { number = order.Number }, order.Number);
        }

        [HttpPut]
        [Route("api/order/{number}")]
        public ActionResult PutOrder(int number, OrderUpdateDTO _order)
        {
            var message = "";
            if (_service.IsAccessDenied(Request))
                return Unauthorized();
            var order = _service.Update(number, _order, out message);
            if (order == null)
                return BadRequest(message);
            return CreatedAtAction("GetOrder", new { number = order.Number }, order.Number);
        }

        [HttpDelete]
        [Route("api/order/{number}")]
        public ActionResult CancelOrder(int number)
        {
            var message = "";
            if (_service.IsAccessDenied(Request))
                return Unauthorized();
            var _order = _service.Cancel(number, out message);
            if (_order == null)
                return BadRequest(message);
            return CreatedAtAction("GetOrder", new { number = _order }, _order.Number);
        }

        [HttpGet]
        [Route("api/postamat/{number}")]
        public ActionResult<PostamatGetDTO> GetPostamat(int number)
        {
            var message = "";
            if (_service.IsAccessDenied(Request))
                return Unauthorized();
            var postomat = _service.GetPostamat(number, out message);
            if (postomat == null)
                return NotFound();
            return postomat;
        }

    }
}