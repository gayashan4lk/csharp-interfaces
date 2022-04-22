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
            ViewData["Title"] = "Using a Web Service";
            IPersonReader reader = new ServiceReader();
            return PopulatePeopleView(reader);
        }

        public IActionResult UseCSV()
        {
            ViewData["Title"] = "Using a CSV File";
            IPersonReader reader = new CSVReader();
            return PopulatePeopleView(reader);
        }

        public IActionResult UseSQL()
        {
            ViewData["Title"] = "Using a SQL Database";
            IPersonReader reader = new SQLReader();
            return PopulatePeopleView(reader);
        }

        private IActionResult PopulatePeopleView(IPersonReader reader)
        {
            IEnumerable<Person> people = reader.GetPeople();
            ViewData["ReaderType"] = reader.GetType().ToString();
            return View("Index", people);
        }
    }
}