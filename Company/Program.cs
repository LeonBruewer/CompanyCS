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
        static City city = new City();

        static void Main(string[] args)
        {
            PrintEmployees();
            AddOrUpdateEmployee();
            Console.ReadLine();
        }

        static void PrintEmployees()
        {
            reader = employee.GetView().CreateDataReader();

            while (reader.Read())
            {
                string firstName = reader["First Name"].ToString();
                string name = reader["Last Name"].ToString();
                string gender = reader["Gender"].ToString();
                string phone = reader["Phone"].ToString();
                string city = reader["City"].ToString();
                string street = reader["Street"].ToString();

                Console.WriteLine($"First Name: {firstName} \nLast Name: {name} \nGender: {gender} \nPhone: {phone} \nCity: {city} \nStreet: {street}\n");
            }
            
        }

        static void AddOrUpdateCity()
        {
            string[] param = new string[2];
            Console.WriteLine("enter postal code");
            param[0] = Console.ReadLine();
            Console.WriteLine("enter city");
            param[1] = Console.ReadLine();

            city.AddOrUpdate(param);
        }

        static void AddOrUpdateEmployee()
        {
            string[] param = new string[8];
            
            Console.WriteLine("enter id or press enter");
            param[0] = Console.ReadLine();
            Console.WriteLine("enter firtst name or press enter");
            param[1] = Console.ReadLine();
            Console.WriteLine("enter last name or press enter");
            param[2] = Console.ReadLine();
            Console.WriteLine("enter date of birth or press enter");
            param[3] = Console.ReadLine();
            Console.WriteLine("enter Gender (1 = male, 2 = female) or press enter");
            param[4] = Console.ReadLine();
            Console.WriteLine("enter phonenumber or press enter");
            param[5] = Console.ReadLine();
            Console.WriteLine("enter departmentId or press enter");
            param[6] = Console.ReadLine();
            Console.WriteLine("enter AddressId or press enter");
            param[7] = Console.ReadLine();

            employee.AddOrUpdate(param);
        }
    }
}
