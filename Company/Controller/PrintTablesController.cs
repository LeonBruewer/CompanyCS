using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Repository;
using Company.Model;

namespace Company.Controller
{
    class PrintTablesController
    {
        AddressRepository addressRepo = new AddressRepository();
        List<AddressModel> addressList;

        public PrintTablesController()
        {
            addressList = addressRepo.GetModelList();
            foreach (AddressModel model in addressList)
            {
                Console.WriteLine(model.PostalCode);
                Console.WriteLine(model.City);
                Console.WriteLine(model.Street);
                Console.WriteLine();
            }
        }
    }
}
