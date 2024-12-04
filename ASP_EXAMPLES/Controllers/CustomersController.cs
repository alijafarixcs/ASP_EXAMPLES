using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using OdataOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_EXAMPLES.Controllers
{
    public class CustomersController : Controller
    {
        private readonly dataOrdersContext context;

        public CustomersController(dataOrdersContext context)
        {
            this.context = context;
        }

        
        public IActionResult Get() => Ok(context.Customers);
        public List<Customer> GetAll() => (context.Customers.ToList());


        [HttpPost]
        public async Task<IActionResult> Add(Customer c)
        {
            context.Customers.Add(c);
            await context.SaveChangesAsync();
            return Ok(c);
        }

        private readonly List<string> demoCustomers = new List<string>
        {
            "Foo",
            "Bar",
            "Acme",
            "King of Tech",
            "Awesomeness"
        };

        private readonly List<string> demoProducts = new List<string>
        {
            "Bike",
            "Car",
            "Apple",
            "Spaceship"
        };

        private readonly List<string> demoCountries = new List<string>
        {
            "AT",
            "DE",
            "CH"
        };

        [HttpPost]
        [Route("fill")]
        public async Task<IActionResult> Fill()
        {
            var rand = new Random();
            for(var i = 0; i< 10; i++)
            {
                var c = new Customer
                {
                    CustomerName = demoCustomers[rand.Next(demoCustomers.Count)],
                    CountryId = demoCountries[rand.Next(demoCountries.Count)]
                };
                context.Customers.Add(c);

                for(var j = 0; j < 10; j++)
                {
                    var o = new Order
                    {
                        OrderDate = DateTime.Today,
                        Product = demoProducts[rand.Next(demoProducts.Count)],
                        Quantity = rand.Next(1, 5),
                        Revenue = rand.Next(100, 5000),
                        Customer = c
                    };
                    context.Orders.Add(o);
                }
            }

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

