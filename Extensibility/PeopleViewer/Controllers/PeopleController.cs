using Microsoft.AspNetCore.Mvc;
using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQL;
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

            ViewData["ReaderType"] = reader.GetType().ToString();
            ViewData["Title"] = "Using a Web Service";
            return View("Index", people);
        }

        public IActionResult UseCSV()
        {
            IPersonReader reader = new CSVReader();
            IEnumerable<Person> people = reader.GetPeople();

            ViewData["ReaderType"] = reader.GetType().ToString();
            ViewData["Title"] = "Using a CSV File";
            return View("Index", people);
        }

        public IActionResult UseSQL()
        {
            IPersonReader reader = new SQLReader();
            IEnumerable<Person> people = reader.GetPeople();

            ViewData["ReaderType"] = reader.GetType().ToString();
            ViewData["Title"] = "Using a SQL Database";
            return View("Index", people);
        }
    }
}