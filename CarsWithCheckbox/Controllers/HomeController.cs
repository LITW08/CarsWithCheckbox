using CarsWithCheckbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarsWithCheckbox.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=CarsLeather;Integrated Security=True";

        public IActionResult Index(string sort)
        {
            CarsWithCheckboxDb db = new CarsWithCheckboxDb(_connectionString);
            IEnumerable<Car> cars = db.GetCars();
            if (sort == "asc")
            {
                cars = cars.OrderBy(c => c.Year);
            }
            else if (sort == "desc")
            {
                cars = cars.OrderByDescending(c => c.Year);
            }
            HomePageViewModel vm = new HomePageViewModel();
            vm.Cars = cars.ToList();
            vm.SortAsc = sort == "asc";
            return View(vm);
        }

        public IActionResult ShowAddForm()
        {
            return View();
        }

        public ActionResult AddCar(Car car)
        {
            CarsWithCheckboxDb db = new CarsWithCheckboxDb(_connectionString);
            db.AddCar(car);
            return Redirect("/");
        }
    }
}
