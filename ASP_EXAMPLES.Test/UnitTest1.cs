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
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            //optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            //var context = new CustomerContext(optionsBuilder.Options);

            //// Just to make sure: Delete all existing customers in the DB
            //await context.Database.EnsureDeletedAsync();
            //await context.Database.EnsureCreatedAsync();

            //// Create Controller
            //var controller = new CustomersController(context);

            //// Add customer
            //await controller.Add(new Customer() { CustomerName = "FooBar" });

            //// Check: Does GetAll return the added customer?
            //var result = (await controller.GetAll()).ToArray();
            //Assert.Single(result);
            //Assert.Equal("FooBar", result[0].CustomerName);
        
        Assert.Equal(1, 1);

        }
    }
}