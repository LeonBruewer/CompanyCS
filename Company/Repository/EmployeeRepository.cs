using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Company.Model;

namespace Company.Repository
{
    class EmployeeRepository
    {
        SqlConnection con = new SqlConnection(global::Company.Properties.Resources.tappqaConString);
        public List<EmployeeModel> GetModelList()
        {
            List<EmployeeModel> result = new List<EmployeeModel>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viEmployee", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                EmployeeModel model = new EmployeeModel()
                {
                    FirstName = row[0].ToString(),
                    LastName = row[1].ToString(),
                    BirthDate = Convert.ToDateTime(row[2]),
                    Gender = row[3].ToString(),
                    PhoneNumber = row[4].ToString(),
                    City = row[5].ToString(),
                    Street  = row[6].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
