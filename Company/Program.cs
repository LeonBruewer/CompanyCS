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

        static DataSet employeeData = new DataSet("viEmployee");
        static DataTableReader reader;
        static Employee employee = new Employee();        

        static void Main(string[] args)
        {
            PrintEmployees();
            AddOrUpdateEmployee();
            Console.ReadLine();
        }

        static void PrintEmployees()
        {
            reader = employee.GetEmployee().CreateDataReader();

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
            con.Close();
        }

        static void AddOrUpdateEmployee()
        {
            Console.WriteLine("enter id or press enter");
            string Id = Console.ReadLine();
            Console.WriteLine("enter firtst name or press enter");
            string FirstName = Console.ReadLine();
            Console.WriteLine("enter last name or press enter");
            string LastName = Console.ReadLine();
            Console.WriteLine("enter date of birth or press enter");
            string BirthDate = Console.ReadLine();
            Console.WriteLine("enter Gender (1 = male, 2 = female) or press enter");
            string Gender = Console.ReadLine();
            Console.WriteLine("enter phonenumber or press enter");
            string PhoneNumber = Console.ReadLine();
            Console.WriteLine("enter departmentId or press enter");
            string DepartmentId = Console.ReadLine();
            Console.WriteLine("enter AddressId or press enter");
            string AddressId = Console.ReadLine();

            cmd.Connection = con;
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spAddOrUpdateEmployee";

            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
            cmd.Parameters.Add(new SqlParameter("@BirthDate", BirthDate));
            cmd.Parameters.Add(new SqlParameter("@Gender", Gender));
            cmd.Parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
            cmd.Parameters.Add(new SqlParameter("@DepartmentId", DepartmentId));
            cmd.Parameters.Add(new SqlParameter("@AddressId", AddressId));

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
