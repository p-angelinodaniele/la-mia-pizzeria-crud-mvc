using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Utils;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizze = PizzaData.GetPizze();

            return View("HomePage", pizze);
        }

        [HttpGet]
        public IActionResult Details(string name)
        {
            Pizza pizzaFound = null;

            foreach(Pizza pizze in PizzaData.GetPizze())
            {
                if(pizze.Name == name)
                {
                    pizzaFound = pizze;
                    break;
                }
            }

            if (pizzaFound != null)
            {
                return View("Details", pizzaFound);
            }
            else
            {
                return NotFound("La pizza con il nome " + name + " non è stato trovato");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPizza");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Pizza nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPizza", nuovaPizza);
            }

            PizzaData.GetPizze().Add(nuovaPizza);
            return RedirectToAction("Index");



        }







    }
}
