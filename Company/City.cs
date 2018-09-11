using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Company
{
    class City : ITable
    {
        SqlConnection con = new SqlConnection("Data Source=tappqa;Initial Catalog=Training-LR-Company;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTableReader reader;

        public void AddOrUpdate(string[] param)
        {
            for (int i = 0; i < param.Length; i++)
            {
                if (param[i] == "")
                    param[i] = null;
            }

            string PostalCode = param[0];
            string City = param[1];

            cmd.Connection = con;
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spAddOrUpdateCity";
            cmd.Parameters.Add(new SqlParameter("@PostalCode", PostalCode));
            cmd.Parameters.Add(new SqlParameter("@City", City));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet GetView()
        {
            throw new NotImplementedException();
        }
    }
}
