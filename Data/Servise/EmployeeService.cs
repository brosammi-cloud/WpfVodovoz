using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfVodovoz.Models;

namespace WpfVodovoz.Data.Servise
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> Repo;

        public EmployeeService(IRepository<Employee> repo)
        {
            Repo = repo;
        }

        public IList<Employee> GetAllEmployees()
            => Repo.GetAll();

        public void AddEmployee(Employee employee)
        {
            Repo.Add(employee);
        }
        public void DeleteEmployee(Employee emp)
        {
            Repo.Delete(emp);
        }
        public void UpdateEmployee(Employee emp)
        {
            Repo.Update(emp);
        }
    }
}
