using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Company
{
    class Employee
    {
        SqlConnection con = new SqlConnection("Data Source=tappqa;Initial Catalog=Training-LR-Company;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTableReader reader;
        

        public DataSet GetEmployee()
        {
            DataSet employeeData = new DataSet("viEmployee");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.viEmployee", con);

            con.Open();
            adapter.Fill(employeeData);
            reader = employeeData.CreateDataReader();

            
            con.Close();

            return employeeData;
        }
    }
}
