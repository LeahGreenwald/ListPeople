using ListPeople.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListPeople.Data;

namespace ListPeople.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=people;Integrated Security=true;";
        public IActionResult Index()
        {
            
            PeopleDb db = new PeopleDb(_connectionString);
            HomeViewModel vm = new HomeViewModel{
                People = db.GetPeople()
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult AddPeople()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {
            PeopleDb db = new(_connectionString);
            List<Person> people1 = people.Where(p => p.FirstName != null && p.LastName != null).ToList();
            db.AddPeople(people1);
            TempData["message"] = "People added successfully";
            return Redirect("/");
        }

    }
}
