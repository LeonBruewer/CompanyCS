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
        public List<AddressModel> GetAddress()
        {
            List<AddressModel> result = new List<AddressModel>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viAddress", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (string row in table.Rows)
            {
                AddressModel model;
                
                    model = new AddressModel()
                    {
                        PostalCode = (int)row[0],
                        City = row[0].ToString(),
                        Street = row[0].ToString()
                    };
                result.Add(model);
            }

            return result;
        }
    }
}
