using Microsoft.AspNetCore.Mvc;
using SiGIn.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace SiGIn.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var tests = new List<TestViewModel>();
            for (int i = 0; i < 10; i++)
            {
                var t = new TestViewModel
                {
                    Age = i * 5,
                    Name = "Name " + i,
                    Id = i + 1
                };
                tests.Add(t);
            }
            return View(tests);
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