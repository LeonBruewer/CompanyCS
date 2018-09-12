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
    class CompanyRepository
    {
        SqlConnection con = new SqlConnection(global::Company.Properties.Resources.tappqaConString);
        public List<CompanyModel> GetModelList()
        {
            List<CompanyModel> result = new List<CompanyModel>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viCompany", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                CompanyModel model = new CompanyModel()
                {
                    CompanyName = row[1].ToString(),
                    PostalCode = (int)row[2],
                    City = row[3].ToString(),
                    Street = row[4].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
