using Altkom.CSharp.ConsoleClient.AltkomWCFService;
using Altkom.CSharp.DbServices;
using Altkom.CSharp.EFServices;
using Altkom.CSharp.FakeServices;
using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.CSharp.ConsoleClient
{
    public class DateTimeHelper
    {        
        public static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class DateTimeExtensions
    {
        // Metoda rozszerzająca (extension method)
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        public static DateTime AddWorkDays(this DateTime date, int days)
        {
            return date.AddDays(days);
        }

        public static string ToMyString(this DateTime date)
        {
            return date.ToShortDateString();
        }
    }

    class Program
    {
        // C# <=7.0
        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        // C# > 7.1
        /// static async Task Main(string[] args)

        static async Task MainAsync(string[] args)
        {
            WCFClientTest();

            SOAPClientTest();

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Starting...");

            // TaskSendTest();
            // CalculateTaxTest();

            // Task<decimal> result = CalculateTaxAsyncAwaitTest();

            // decimal result = await CalculateTaxAsyncAwaitTest();

            CalculateTaxAsyncAwaitTest();


            // Task.Run(()=>CalculateTaxAsyncAwaitTest());

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Done.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            #region 
            //LaserPrinterTest();

            //PrinterTest();

            // ExtensionMethodTest();

            //AddProductTest();

            //GetProductTest();

            //GetProductsTest();

            // ProductsTest();

            // CreateOrder1();

            // CreateOrder2();

            //ArrayTest();
            //CollectionTest();
            #endregion
        }

        private static async void RestApiClientTest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54015");
            
            HttpResponseMessage response = await client.GetAsync("api/products");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            }
        }

        private static void WCFClientChannelFactoryTest()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress("http://localhost:54015/MyService");

            ChannelFactory<IMyService> proxy = new ChannelFactory<IMyService>(binding, endpoint);
            IMyService client = proxy.CreateChannel();

            int result = client.Add(10, 5);

        }

        private static void WCFClientTest()
        {
            AltkomWCFService.MyServiceClient client = new AltkomWCFService.MyServiceClient();
            int result = client.Add(10, 5);
        }

        private static void SOAPClientTest()
        {
            ServiceAltkom.MyService service = new ServiceAltkom.MyService();
            int result = service.Add(10, 5);

            ServiceAltkom.Product[] products =  service.GetProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }

            
        }

        private static void ThreadSendTest()
        {
            Thread thread = new Thread(SyncTest);
            thread.Start();
        }

        private static void TaskSendTest()
        {
            //Task task = new Task(() => SyncTest());
            //task.Start();

            Task.Run(() => SyncTest());
        }

        private static void CalculateTaxSyncTest()
        {
            decimal amount1 = CalculateTax(100);
            decimal amount2 = CalculateTax(100);
            decimal total = amount1 + amount2;
            Console.WriteLine($"{total}");
        }

        private static void CalculateTaxTest()
        {
           CalculateTaxAsync(100)
                .ContinueWith(t => Console.WriteLine($"{t.Result}"));
        }

        private static void CalculateTaxParaller()
        {
            Task<decimal> t1 = CalculateTaxAsync(100);
            Task<decimal> t2 = CalculateTaxAsync(300);

            Task.WaitAll(t1, t2);

            decimal total = t1.Result + t2.Result;
        }

        private static async Task<decimal> CalculateTaxAsyncAwaitTest()
        {
            decimal amount1 = await CalculateTaxAsync(100);
            decimal amount2 = await CalculateTaxAsync(300);

            decimal total = amount1 + amount2;

            Console.WriteLine($"result: {total}");

            return total;
        }

        private static Task<decimal> CalculateTaxAsync(decimal amount)
        {
            return Task.Run(() => CalculateTax(amount));
        }

        private static decimal CalculateTax(decimal amount)
        {
            Console.WriteLine($"Calculating...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"Calculated.");

            return amount * 1.23m;
        }

        private static void SyncTest()
        {
            Sender sender = new Sender();
            sender.Send("Hello World!");
        }

        private static void ExtensionMethodTest()
        {
            DateTime shipDate = DateTime.Today.AddWorkDays(10);

            Console.WriteLine(DateTime.Today.ToMyString());

            if (DateTime.Today.IsWeekend())
            {
                Console.WriteLine("Weekend!");
            }
        }

        private static void LaserPrinterTest()
        {
            LaserPrinter printer = new LaserPrinter();

            printer.PaperOut += Printer_PaperOut;
            printer.LowLevel += Printer_LowLevel;

            printer.Log = LogConsole;
            printer.Log += LogFile;
            printer.Log += LogFile;
            printer.Log += LogEmail;
            // printer.Log += LogToFile;


            // metoda anonimowa
            printer.Log += delegate (string message)
            {                
                Console.WriteLine($"send to Facebook {message}");
            };
             
            // R    f <- x + y 
            //      g <- f(10, 5) + 1
            
            printer.Log += message => Console.WriteLine(message);

            printer.CalculateCost += Calculate;

            Printer logPrinter = new Printer();
            printer.Log += logPrinter.Print;

            printer.Print("5465654344");

            printer.Log -= LogEmail;
            

            printer.Print("5556667773");

            printer.Log = null;

            printer.Print("8098989895");
        }
      
        private static void Printer_LowLevel(object sender, PrinterEventArgs e)
        {
            Console.WriteLine($"Level {e.Level}");
        }

        private static void Printer_PaperOut()
        {
            Console.WriteLine("koniec papieru");
        }

        private static decimal Calculate(int copies)
        {
            return copies * 0.99m;
        }

        private static void LogToFile(string filename, string message)
        {
            System.IO.File.AppendAllText(filename, message);
        }

        private static void LogFile(string message)
        {
            System.IO.File.AppendAllText(@"c:\temp\altkom.log", message);
        }

        private static void LogConsole(string message)
        {
            Console.WriteLine(message);
        }

        private static void LogEmail(string content)
        {
            Console.WriteLine($"Send email {content}");
        }

        private static void PrinterTest()
        {
            Printer printer = new Printer();
            printer.Print("5465654344");
        }

       

        private static void AddProductTest()
        {
            Product product = new Product
            {
                Name = "Maska ochronna",
                Color = "blue",
                UnitPrice = 25.99m,
                Weight = 200.5f
            };

            IProductService productService = CreateEFProductService();
            productService.Add(product);
        }

        private static void GetProductTest()
        {
            IProductService productService = CreateEFProductService();
            Product product = productService.Get(1);
            Console.WriteLine(product.Name);
        }

        private static IProductService CreateEFProductService()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyEFDb;Integrated Security=True;Application Name=Altkom";

            // MyContext context = new MyContext();

            MyContext context = new MyContext(connectionString);
            IProductService productService = new EFProductService(context);

            return productService;
        }

        private static IProductService CreateDbProductService()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDb;Integrated Security=True;Application Name=Altkom";

            SqlConnection connection = new SqlConnection(connectionString);
            IProductService productService = new DbProductService(connection);

            return productService;
        }

        private static void GetProductsTest()
        {
            IProductService productService = CreateEFProductService();

            IEnumerable<Product> products = productService.Get();

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }
        }

        private static void VarTest()
        {
            var x = 10m;

            // x = "Hello World";
        }

        private static void DynamicTest()
        {
            dynamic a = 10;

            a = "Hello World";            
        }
    
        private static void ProductsTest()
        {
            ICollection<Product> products = Create();

            IProductService productService = new FakeProductService();
            productService.AddRange(products);

            var blackProducts = productService.Get("black");
            
            foreach (Product product in blackProducts)
            {
                Console.WriteLine(product);
            }

            //var myProducts = productService.Get(10, 50);

            //foreach (Product product in myProducts)
            //{

            //}

        }

        private static void CollectionTest()
        {
            Collection<string> customers = new Collection<string>();
            customers.Add("Ewa");
            customers.Add("Tomek");
        }

        private static void ArrayTest()
        {
            string[] names = new string[255];
            names[0] = "Ewa";
            names[1] = "Tomek";

            string[] members = new string[] { "Ewa", "Tomek" };
        }

        private static ICollection<Product> Create()
        {
            Product product1 = new Product
            {
                Id = 1,
                Name = "maska",
                Color = "black",
                UnitPrice = 9.99m
            };

            Product product2 = new Product
            {
                Id = 2,
                Name = "Plyn",
                Color = "Transparentny",
                UnitPrice = 100m
            };

            ICollection<Product> products = new List<Product>
            {
                product1,
                product2
            };

            return products;
        }

        private static void CreateOrder2()
        {
            Customer customer = new Customer("John", "Smith");

            Console.WriteLine(customer.LastName.ToLower());

            Product product1 = new Product
            {
                Id = 1,
                Name = "maska",
                Color = "black",
                UnitPrice = 9.99m
            };

            Product product2 = new Product
            {
                Id = 2,
                Name = "Plyn",
                Color = "Transparentny",
                UnitPrice = 100m
            };

            Service service1 = new Service
            {
                Id = 1,
                Name = "Odkazanie",
                Duration = TimeSpan.FromMinutes(30),
                UnitPrice = 25m
            };

            Collection<OrderDetail> orderDetails = new Collection<OrderDetail>
             {
                 new OrderDetail(1, product1, quantity: 5),
                 new OrderDetail(2, product2, unitPrice: 75m),
                 new OrderDetail(3, service1),
             };

            Order order = new Order("ZAM 1/2020", customer)
            {
                Id = 1,
                ShipDate = DateTime.Today.AddDays(7),
                OrderDetails = orderDetails
            };
            
            foreach (OrderDetail orderDetail in order.OrderDetails)
            {
                // snippet: cw
                Console.WriteLine($"{orderDetail.Item} {orderDetail.Quantity} szt. {orderDetail.UnitPrice} PLN");                
            }
        }

        private static void CreateOrder1()
        {
            Customer customer = new Customer();
            customer.FirstName = "John";
            customer.LastName = "Smith";

            Order order = new Order();
            order.Id = 1;
            order.OrderDate = DateTime.Now;
            order.Customer = customer;
        }
    }
}
