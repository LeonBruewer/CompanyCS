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
                    FirstName = row[1].ToString(),
                    LastName = row[2].ToString(),
                    BirthDate = (DateTime)row[3],
                    Gender = row[4].ToString(),
                    PhoneNumber = row[5].ToString(),
                    City = row[6].ToString(),
                    Street  = row[7].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
