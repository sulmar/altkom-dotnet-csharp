﻿using Altkom.CSharp.FakeServices;
using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.CSharp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsTest();

            // CreateOrder1();

            // CreateOrder2();

            //ArrayTest();
            //CollectionTest();
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