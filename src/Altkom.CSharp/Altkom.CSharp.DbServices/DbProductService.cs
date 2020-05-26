using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using Altkom.CSharp.Models.SearchCriterias;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Altkom.CSharp.Extensions;

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
            string sql = "insert into dbo.Products values (@Name, @UnitPrice, @Color, @Weight)";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@Color", entity.Color);
            command.Parameters.AddWithValue("@Weight", entity.Weight);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(string color)
        {
            string sql = "select ProductId, Name, UnitPrice, Color, Weight from dbo.Products where Color = @Color";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Color", color);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = Map(reader);

                yield return product;
            }

            connection.Close();
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

            while(reader.Read())
            {
                Product product = Map(reader);

                yield return product;
            }

            connection.Close();
        }

        private static Product Map(SqlDataReader reader)
        {
            Product product = new Product
            {
                Id = reader.GetInt32("ProductId"),
                Name = reader.GetString("Name"),
                UnitPrice = reader.GetDecimal("UnitPrice"),
                Color = reader.IsDBNull(3) ? null: reader.GetString("Color"),
                Weight = reader.GetFloat("Weight"),
            };
           
            return product;
        }

        public int Count()
        {
            string sql = "select count(*) from dbo.Products";

            SqlCommand command = new SqlCommand(sql, connection);           
            connection.Open();
            
            int count = (int) command.ExecuteScalar();

            connection.Close();

            return count;
        }

        public Product Get(int id)
        {
            string sql = "select ProductId, Name, UnitPrice, Color, Weight from dbo.Products where ProductId = @ProductId";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ProductId", id);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Product product = null;

            if (reader.Read())
            {                
                product = Map(reader);
            }

            connection.Close();

            return product;

        }

        public void Remove(int id)
        {
            string sql = "delete from dbo.Products where ProductId = @ProductId";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ProductId", id);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected == 0)
                throw new InvalidOperationException();
        }

        public void Update(Product entity)
        {
            string sql = "update dbo.Products set Name=@Name, UnitPrice=@UnitPrice, Color=@Color, Weight=@Weight where ProductId = @ProductId";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ProductId", entity.Id);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@Color", entity.Color);
            command.Parameters.AddWithValue("@Weight", entity.Weight);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected == 0)
                throw new InvalidOperationException();
        }
    }
}
