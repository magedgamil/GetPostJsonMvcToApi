using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySiteMvc.Models;
using MySiteMvc.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MySiteMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeServices api;

        public HomeController(ILogger<HomeController> logger, IEmployeeServices _api)
        {
            _logger = logger;
            api = _api;
        }


        public async Task<IActionResult> Index()
        {
            return View(await api.GetAll());
        }

        public async Task<IActionResult> Search(string txt)
        {
            return View(await api.Search(txt));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await api.Find(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            api.Add(employee);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await api.Find(id));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            api.Update(id, employee);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await api.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            api.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
