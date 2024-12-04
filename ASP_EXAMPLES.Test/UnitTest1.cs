using ASP_EXAMPLES.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OdataOrders.Data;

namespace ASP_EXAMPLES.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
        }
        
        [Fact]
        public async Task CustomerIntegrationTest()
        {
            //// Create DB Context
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<dataOrdersContext>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            var context = new dataOrdersContext(optionsBuilder.Options);

            // Just to make sure: Delete all existing customers in the DB
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // Create Controller
            var controller = new CustomersController(context);

            // Add customer
            await controller.Add(new Customer() { CustomerName = "FooBar", CountryId="12" });

            // Check: Does GetAll return the added customer?
            var result = (controller.GetAll()).ToArray();
            Assert.Single(result);
            Assert.Equal("FooBar", result[0].CustomerName);
        
        Assert.Equal(1, 1);

        }
    }
}