using MySiteMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MySiteMvc.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly HttpClient httpClient;

        public EmployeeServices(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public void Add(Employee employee)
        {
            string content = System.Text.Json.JsonSerializer.Serialize(employee);
            httpClient.PostAsync("https://localhost:44345/api/Employee/", new StringContent(content, Encoding.UTF8, "application/json"));
        }

        public async Task<IEnumerable<Employee>> Search(string txt)
        {
            List<Employee> employees = new List<Employee>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44345/api/Employee/{txt}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            return employees;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44345/api/Employee/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            return employees;
        }

        public void Update(int id, Employee employee)
        {
            string content = System.Text.Json.JsonSerializer.Serialize(employee);
            httpClient.PutAsync($"https://localhost:44345/api/Employee/{id}", new StringContent(content, Encoding.UTF8, "application/json"));
        }
        public void Delete(int id)
        {
            httpClient.DeleteAsync($"https://localhost:44345/api/Employee/{id}");
        }
        
        public async Task<Employee> Find(int id)
        {
            Employee employees = new Employee();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44345/api/Employee/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }
            return employees;
        }
    }
}
