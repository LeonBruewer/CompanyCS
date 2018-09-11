using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Company
{
    class Employee : ITable
    {
        SqlConnection con = new SqlConnection("Data Source=tappqa;Initial Catalog=Training-LR-Company;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTableReader reader;
        

        public DataSet GetView()
        {
            Console.WriteLine("Console");
            DataSet employeeData = new DataSet("viEmployee");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.viEmployee", con);

            con.Open();
            adapter.Fill(employeeData);
            reader = employeeData.CreateDataReader();

            
            con.Close();

            return employeeData;
        }

        public void AddOrUpdate(string[] param)
        {
            string Id = param[0];
            string FirstName = param[1];
            string LastName = param[2];
            string BirthDate = param[3];
            string Gender = param[4];
            string PhoneNumber = param[5];
            string DepartmentId = param[6];
            string AddressId = param[7];

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