using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Model;
using System.Data.SqlClient;
using System.Data;

namespace Company.Repository
{
    class AddressRepository
    {
        SqlConnection con = new SqlConnection("Data Source=tappqa;Initial Catalog=Training-LR-Company;Integrated Security=True");
        public List<AddressModel> GetModelList()
        {
            List<AddressModel> result = new List<AddressModel>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viAddress", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                AddressModel model = new AddressModel()
                {
                    PostalCode = (int)row[1],
                    City = row[2].ToString(),
                    Street = row[3].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
