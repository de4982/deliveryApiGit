using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderWebApi.Models;

namespace OrderWebApi.Data
{
    public class DbInit
    {
        public static void Init(ApiContext _context)
        {
            _context.Database.EnsureCreated();

            if (_context.Shop.Any())
            {
                return;
            }
            var shops = new Shop[]
                {
                    new Shop { IsActive = true, Name = "ozon", ApiKey = "a5d36b4a-ac93-43bd-b6ce-4c8456b445a4" },
                    new Shop { IsActive = true, Name = "wildberries", ApiKey = "ab691e2e-1fc3-4765-b858-a30548c8d9ee"},
                    new Shop { IsActive = true, Name = "citilink", ApiKey = "24696559-ce97-4cd6-9620-87239ec194f0"}
                };
            foreach (Shop _shop in shops)
            {
                _context.Shop.Add(_shop);
            }

            if (_context.Status.Any())
            {
                return;
            }
            var statuses = new Status[]
                {
                    new Status { Number = 1, Name = "Зарегистрирован" },
                    new Status { Number = 2, Name = "Принят на складе"},
                    new Status { Number = 3, Name = "Выдан курьеру"},
                    new Status { Number = 4, Name = "Доставлен в постамат"},
                    new Status { Number = 5, Name = "Доставлен получателю"},
                    new Status { Number = 6, Name = "Отменен"},
                };
            foreach (Status _status in statuses)
            {
                _context.Status.Add(_status);
            }

            if (_context.Postamat.Any())
            {
                return;
            }
            var postamats = new Postamat[]
                {
                    new Postamat { Number = 1, Address = "Кутузовский проспект", Status = true },
                    new Postamat { Number = 2, Address = "Ленинский проспект", Status = true },
                    new Postamat { Number = 3, Address = "Варшавское шоссе", Status = true }
                };
            foreach (Postamat _postamat in postamats)
            {
                _context.Postamat.Add(_postamat);
            }

            _context.SaveChanges();


        }
    }
}
