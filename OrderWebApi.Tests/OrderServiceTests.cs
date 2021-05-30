using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OrderWebApi.Services;
using OrderWebApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Razor.Language;
using FluentAssertions.Common;

namespace OrderWebApi.Tests
{
    public class OrderServiceTests
    {
        private ApiContext _context;
        private OrderService _service;

        public OrderServiceTests()
        {

            var _options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "OrderDatabase")
            .Options;
            _context = new ApiContext(_options);
            Postamat _postamat = new Postamat() { Id = 1, Number = 1, Address = "1", Status = true } ;
            Status _status = new Status() { Id = 1, IsActive = true, Name = "1", Number = 1 } ;
            Order _order = new Order()
            {
                Id = 1,
                Cost = 1,
                IsDelete = false,
                Number = 1,
                Phone = "1",
                Postamat = _postamat,
                Products = "1,2",
                Recipient = "1",
                Status = _status
            };
            _context.Postamat.Add(_postamat);
            _context.Status.Add(_status);
            _context.Order.Add(_order);
            _context.SaveChanges();
            _service = new OrderService(_context);

        }

        
        [Fact]
        public void IsPhoneValidTest1()
        {
            bool result = _service.IsPhoneValid("+7900-333-22-11");
            Assert.True(result, "phone number +7900-333-22-11 is valid");
        }
        [Fact]
        public void IsPhoneValidTest2()
        {
            bool result = _service.IsPhoneValid("+7-900-333-22-11");
            Assert.False(result, "phone number +7-900-333-22-11 is not valid");
        }
        /*
        [Fact]
        public void GetOrderTest1()
        {
            OrderGetDTO result = _service.Get(1);
            OrderGetDTO mock = new OrderGetDTO() { 
                Number = 1, 
                Cost = 1, 
                Phone = "1", 
                Postamat = 1, 
                Products = new List<string> { "1", "2" }, 
                Recipient = "1", 
                Status = "1"  };

            Assert.True(result.IsSameOrEqualTo(mock));

        }
        */

    }
}
