using MySiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySiteApi.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> Search(string txt);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        Employee Find(int id);

    }
}
