using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Company
{
    class Program
    {
        static SqlConnection con = new SqlConnection("Data Source=tappqa;Initial Catalog=Training-LR-Company;Integrated Security=True");
        static SqlCommand cmd = new SqlCommand();
        static SqlDataReader reader;
        static SqlDataAdapter adapter;

        static void Main(string[] args)
        {
            PrintEmployees();
            AddOrUpdateCity();
            Console.ReadLine();
        }

        static void PrintEmployees()
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT * FROM dbo.viEmployee";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string firstName = reader["First Name"].ToString();
                string name = reader["Last Name"].ToString();
                string gender = reader["Gender"].ToString();
                string phone = reader["Phone"].ToString();
                string city = reader["City"].ToString();
                string street = reader["Street"].ToString();

                Console.WriteLine($"First Name: {firstName} \nLast Name: {name} \nGender: {gender} \nPhone: {phone} \nCity: {city} \nStreet: {street}");
            }
        }

        static void AddOrUpdateCity()
        {
            Console.WriteLine("enter postal code");
            string PostalCode = Console.ReadLine();
            Console.WriteLine("enter city");
            string City = Console.ReadLine();

            cmd.Connection = con;
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spAddOrUpdateCity";
            cmd.Parameters.Add(new SqlParameter("@PostalCode", "48720"));
            cmd.Parameters.Add(new SqlParameter("@City", City));
            cmd.ExecuteNonQuery();
        }
    }
}
