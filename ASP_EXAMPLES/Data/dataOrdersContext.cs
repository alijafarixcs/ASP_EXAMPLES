using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataOrders.Data
{
    public class dataOrdersContext : DbContext
    {
        public dataOrdersContext(DbContextOptions<dataOrdersContext> context)
            : base(context)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
