using Microsoft.AspNetCore.Mvc;
using PersonReader.Interface;
using PersonReader.Service;
using System.Collections.Generic;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult UseService()
        {
            IPersonReader reader = new ServiceReader();
            //var people = reader.GetPeople();
            IEnumerable<Person> people = reader.GetPeople();

            ViewData["Title"] = "Using a Web Service";
            return View("Index", people);
        }

        public IActionResult UseCSV()
        {
            ViewData["Title"] = "Using a CSV File";
            return View("Index", new List<Person>());
        }

        public IActionResult UseSQL()
        {
            ViewData["Title"] = "Using a SQL Database";
            return View("Index", new List<Person>());
        }
    }
}