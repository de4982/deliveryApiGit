using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OrderWebApi.Models
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<Log> Log { get; set; }
        public DbSet<Error> Error { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Postamat> Postamat { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
