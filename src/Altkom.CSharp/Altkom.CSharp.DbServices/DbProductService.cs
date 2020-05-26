using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using Altkom.CSharp.Models.SearchCriterias;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Altkom.CSharp.DbServices
{
    // System.Data.SqlClient 


    // PMC> Install-Package Microsoft.Data.SqlClient

    public class DbProductService : IProductService
    {
        private readonly SqlConnection connection;

        public DbProductService(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(string color)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(ProductSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            string sql = "select ProductId, Name, UnitPrice, Color, Weight from dbo.Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            ICollection<Product> products = new List<Product>();

            while(reader.Read())
            {
                Product product = new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    UnitPrice = reader.GetDecimal(2),
                    Color = reader.GetString(3),
                    Weight = (float) reader.GetDouble(4),                    
                    // TODO:
                    // reader.GetString("Color"),
                };

                // reader.GetOrdinal("Color")

                products.Add(product);
            }

            connection.Close();

            return products;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
