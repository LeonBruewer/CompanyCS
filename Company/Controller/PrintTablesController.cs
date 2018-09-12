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
        CityRepository cityRepo = new CityRepository();
        CompanyRepository companyRepo = new CompanyRepository();
        DepartmentRepository departmentRepo = new DepartmentRepository();
        EmployeeRepository employeeRepo = new EmployeeRepository();
        

        public PrintTablesController(string table)
        {
            switch (table)
            {
                case "address":
                    PrintAddress();
                    break;
                case "city":
                    PrintCity();
                    break;
                case "company":
                    PrintCompany();
                    break;
                case "department":
                    PrintDepartment();
                    break;
                case "employee":
                    PrintEmployee();
                    break;
                default:
                    break;
            }
        }

        public void PrintAddress()
        {
            List<AddressModel> modelList = addressRepo.GetModelList();
            foreach (AddressModel model in modelList)
            {
                Console.WriteLine(model.PostalCode);
                Console.WriteLine(model.City);
                Console.WriteLine(model.Street);
                Console.WriteLine();
            }
        }

        public void PrintCity()
        {
            List<CityModel> modelList = cityRepo.GetModelList();
            foreach (CityModel model in modelList)
            {
                Console.WriteLine(model.PostalCode);
                Console.WriteLine(model.City);
                Console.WriteLine();
            }

        }

        public void PrintCompany()
        {
            List<CompanyModel> modelList = companyRepo.GetModelList();
            foreach (CompanyModel model in modelList)
            {
                Console.WriteLine(model.CompanyName);
                Console.WriteLine(model.PostalCode);
                Console.WriteLine(model.City);
                Console.WriteLine(model.Street);
                Console.WriteLine();
            }
        }

        public void PrintDepartment()
        {
            List<DepartmentModel> modelList = departmentRepo.GetModelList();
            foreach (DepartmentModel model in modelList)
            {
                Console.WriteLine(model.DepartmentName);
                Console.WriteLine(model.Company);
                Console.WriteLine(model.Manager);
                Console.WriteLine();
            }
        }

        public void PrintEmployee()
        {
            List<EmployeeModel> modelList = employeeRepo.GetModelList();
            foreach (EmployeeModel model in modelList)
            {
                Console.WriteLine(model.FirstName);
                Console.WriteLine(model.LastName);
                Console.WriteLine(model.BirthDate);
                Console.WriteLine(model.Gender);
                Console.WriteLine(model.PhoneNumber);
                Console.WriteLine(model.City);
                Console.WriteLine(model.Street);
                Console.WriteLine();
            }
        }
    }
}
