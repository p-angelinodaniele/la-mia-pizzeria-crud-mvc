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
            Pizza pizzaFound = GetPizzaByName(name);

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


        [HttpGet]
        public IActionResult Update(string name)
        {
            Pizza pizzaToEdit = GetPizzaByName(name);
            if(pizzaToEdit != null)
            {
                return View("Update", pizzaToEdit);
            }
            else
            {
                return NotFound("La pizza con il nome " + name + " non è stato trovato");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(string name, Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }
            Pizza pizzaOriginal = GetPizzaByName(name);
            if(pizzaOriginal != null)
            {
                pizzaOriginal.Prezzo = model.Prezzo;
                pizzaOriginal.Description = model.Description;
                pizzaOriginal.Name = model.Name;
                pizzaOriginal.Image = model.Image;

                return RedirectToAction("Index");
            } else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Delete(string name)
        {
            string PizzaToRemove = null;
            List<Pizza> pizzaList = PizzaData.GetPizze();
            foreach (Pizza pizza in pizzaList)
            {
                if(pizza.Name == name)
                {
                    PizzaData.GetPizze().Remove(pizza);

                    return RedirectToAction("Index");
                }
               
            }
            return NotFound();

        }









        private Pizza GetPizzaByName(string name)
        {
            Pizza pizzaFound = null;

            foreach (Pizza pizze in PizzaData.GetPizze())
            {
                if (pizze.Name == name)
                {
                    pizzaFound = pizze;
                    break;
                }
            }
            return pizzaFound;
        }






    }
}
