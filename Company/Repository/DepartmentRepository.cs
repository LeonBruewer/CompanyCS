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
    class DepartmentRepository
    {
        SqlConnection con = new SqlConnection(global::Company.Properties.Resources.tappqaConString);
        public List<DepartmentModel> GetModelList()
        {
            List<DepartmentModel> result = new List<DepartmentModel>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viDepartment", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                DepartmentModel model = new DepartmentModel()
                {
                    DepartmentName = row[1].ToString(),
                    Manager = row[2].ToString(),
                    Company = row[3].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
