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
    class CityRepository
    {
        SqlConnection con = new SqlConnection(global::Company.Properties.Resources.tappqaConString);
        public List<CityModel> GetModelList()
        {
            List<CityModel> result = new List<CityModel>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viCity", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                CityModel model = new CityModel()
                {
                    PostalCode = (int)row[1],
                    City = row[2].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
