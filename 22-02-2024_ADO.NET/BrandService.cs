using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_02_2024_ADO.NET
{
    internal class BrandService
    {
        private string connectionStr = "Server = LAPTOP-IGIN0GLR\\SQLEXPRESS; Database = ClothingStore; Trusted_Connection = true";

        public void InsertBrand(string name, int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "insert into brands(name, year) values (@name, @year)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void DeleteBrand(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "delete from brands where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Brand GetBrandById(int id)
        {
            Brand brand = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from brands where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;
                    while (reader.Read())
                    {
                        brand = new Brand();
                        brand.Id = reader.GetInt32(0);
                        brand.Name = reader.GetString(1);
                        brand.Year = reader.GetInt32(2);
                    }
                }
                
            }
            return brand;
        }

        public List<Brand> GetAllBrands()
        {
            List<Brand> brands = new List<Brand>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select  id, name, year from brands";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Brand brand = new Brand();
                        brand.Id = reader.GetInt32(0);
                        brand.Name = reader.GetString(1);
                        brand.Year = reader.GetInt32(2);
                        brands.Add(brand);
                    }
                }
            }
            return brands;
        }

        public void UpdateBrand(int id, string name, int year)
        {

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "update brands set name = @name, year = @year where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
