using MySiteApi.Database;
using MySiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySiteApi.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly AppDbContext context;

        public EmployeeServices(AppDbContext _context)
        {
            context = _context;
        }
        public void Add(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.AsEnumerable();
        }

        public void Update(Employee employee)
        {
            context.Update(employee);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Remove(Find(id));
            context.SaveChanges();
        }
        public IEnumerable<Employee> Search(string txt)
        {
            return context.Employees.Where(x => x.Name.Contains(txt)).AsEnumerable();
        }
        public Employee Find(int id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }
    }
}
