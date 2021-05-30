using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OrderWebApi.Models;

namespace OrderWebApi.Services.Interfaces
{
    public interface IOrderService
    {
        bool IsAccessDenied(HttpRequest request);
        OrderGetDTO Get(int number);
        Order Add(OrderCreateDTO order, out string message);
        Order Update(int number, OrderUpdateDTO order, out string message);
        Order Cancel(int number, out string message);
        PostamatGetDTO GetPostamat(int number, out string message);
    }
}
