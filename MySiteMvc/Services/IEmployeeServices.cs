using MySiteMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySiteMvc.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<IEnumerable<Employee>> Search(string txt);
        void Add(Employee employee);
        void Update(int id, Employee employee);
        void Delete(int id);
        Task<Employee> Find(int id);

    }
}
