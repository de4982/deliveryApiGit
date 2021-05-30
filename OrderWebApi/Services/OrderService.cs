using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderWebApi.Models;
using OrderWebApi.Services.Interfaces;

namespace OrderWebApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApiContext _context;

        public OrderService(ApiContext context)
        {
            _context = context;
        }

        public bool IsAccessDenied(HttpRequest request)
        {
            bool result = true;
            var key = request.Headers["x-api-key"];
            if (key.Count > 0 && _context.Shop.FirstOrDefault(x => x.ApiKey == key.ToString()) != null)
                result = false;
            return result;
        }

        public OrderGetDTO Get(int Number)
        {
            var order = _context.Order
                .Include(x=>x.Status)
                .Include(x=>x.Postamat)
                .FirstOrDefault(x => x.Number == Number);
            if (order == null)
                return null;
            var result = new OrderGetDTO();
            result.Cost = order.Cost;
            result.Number = order.Number;
            result.Phone = order.Phone;
            result.Postamat = order.Postamat.Number;
            result.Recipient = order.Recipient;
            result.Status = order.Status.Name;
            if (order.Products != null)
                result.Products = order.Products.Split(',').ToList();
            return result;
        }

        public Order Add(OrderCreateDTO _order, out string message) 
        {
            if (_order == null)
            {
                message = String.Format("Ошибка добавления заказа: Формат запроса не идентифицирован");
                return null;
            }
            var checkOrder = _context.Order.FirstOrDefault(x => x.Number == _order.Number);
            if (checkOrder != null)
            {
                message = String.Format("Ошибка добавления заказа: Заказ с номером {0} уже существует", _order.Number);
                return null;
            }
            var checkPostamat = _context.Postamat.FirstOrDefault(x => x.Status && x.Number == _order.Postamat);
            if (checkPostamat == null)
            {
                message = String.Format("Ошибка добавления заказа: Постамат с номером {0} не доступен", _order.Postamat);
                return null;
            }
            if (_order.Products.Count > 10)
            {
                message = String.Format("Ошибка добавления заказа: Более 10 товаров в заказе");
                return null;
            }
            if (!IsPhoneValid(_order.Phone))
            {
                message = String.Format("Ошибка добавления заказа: Номер телефона не в формате +7900-100-10-10");
                return null;
            }
            var order = new Order();
            order.IsDelete = false;
            order.Number = _order.Number;
            order.Cost = _order.Cost;
            order.Products = string.Join(",", _order.Products);
            order.Phone = _order.Phone;
            order.Postamat = checkPostamat;
            order.Recipient = _order.Recipient;
            order.Status = _context.Status.FirstOrDefault(x => x.Number == 1);
            _context.Order.Add(order);
            _context.SaveChanges();

            message = "all correct";
            return order;
        }

        public Order Update(int _number, OrderUpdateDTO _order, out string message)
        {
            if (_order == null)
            {
                message = String.Format("Ошибка обновления заказа: Формат запроса не идентифицирован");
                return null;
            }
            var order = _context.Order.FirstOrDefault(x => x.Number == _number);
            if (order == null)
            {
                message = String.Format("Ошибка обновления заказа: Заказ {0} не найден", _number);
                return null;
            }
            var checkPostamat = _context.Postamat.FirstOrDefault(x => x.Status && x.Number == _order.Postamat);
            if (checkPostamat == null)
            {
                message = String.Format("Ошибка обновления заказа: Постамат с номером {0} не доступен", _order.Postamat);
                return null;
            }
            if (_order.Products.Count > 10)
            {
                message = String.Format("Ошибка обновления заказа: Более 10 товаров в заказе");
                return null;
            }
            if (!IsPhoneValid(_order.Phone))
            {
                message = String.Format("Ошибка обновления заказа: Номер телефона не в формате +7900-100-10-10");
                return null;
            }
            order.IsDelete = false;
            order.Cost = _order.Cost;
            order.Products = string.Join(",", _order.Products);
            order.Phone = _order.Phone;
            order.Postamat = checkPostamat;
            order.Recipient = _order.Recipient;
            _context.SaveChanges();

            message = "all correct";
            return order;
        }

        public Order Cancel(int number, out string message)
        {
            var order = _context.Order.FirstOrDefault(x => x.Number == number);
            if (order == null)
            {
                message = String.Format("Ошибка отмены заказа: Заказ {0} не найден", number);
                return null;
            }
            order.Status = _context.Status.FirstOrDefault(x => x.Number == 6);
            _context.SaveChanges();

            message = "all correct";
            return order;
        }

        public PostamatGetDTO GetPostamat(int number, out string message)
        {
            var _postamat = _context.Postamat.FirstOrDefault(x => x.Number == number);
            if (_postamat == null)
            {
                message = String.Format("Ошибка получения постамата: Постамат номер {0} не найден", number); ;
                return null;
            }
            if (_postamat.Status == false)
            {
                message = String.Format("Ошибка получения постамата: Постамат номер {0} не активен", number); ;
                return null;
            }
            PostamatGetDTO postamat = new PostamatGetDTO();
            postamat.Number = _postamat.Number;
            postamat.Address = _postamat.Address;
            postamat.Status = _postamat.Status;

            message = "all correct";
            return postamat;
        }

        public bool IsPhoneValid(string phone)
        {
            bool result = true;
            Regex regex = new Regex(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$", RegexOptions.IgnoreCase);
            if (phone != null && !regex.IsMatch(phone))
                result = false;
            return result;
        }

    }
}
