using Microsoft.AspNetCore.Mvc;
using MySiteApi.Models;
using MySiteApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeServices DbServices;

        public EmployeeController(IEmployeeServices _dbServices)
        {
            DbServices = _dbServices;
        }

        // GET api/<EmployeeController>/john
        [HttpGet("{txt}")]
        public IEnumerable<Employee> Search(string txt)
        {
            return DbServices.Search(txt);
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return DbServices.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id:int}")]
        public Employee Find(int id)
        {
            return DbServices.Find(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Add([FromBody] Employee employee)
        {
            DbServices.Add(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Employee employee)
        {
            DbServices.Update(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DbServices.Delete(id);
        }
    }
}
