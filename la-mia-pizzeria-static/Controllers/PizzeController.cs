using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Utils;
using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizze = new List<Pizza>();

            using (PizzeriaContext db = new PizzeriaContext())
            {
                pizze = db.Pizze.ToList<Pizza>();
            }

                return View("HomePage", pizze);
        }

        [HttpGet]
        public IActionResult Details(string name)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                try
                {
                    Pizza pizzaFound = db.Pizze
                        .Where(pizza => pizza.Name == name)
                        .First();
                    return View("Details", pizzaFound);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("La pizza con il nome " + name + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
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

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToCreate = new Pizza(nuovaPizza.Name, nuovaPizza.Description, nuovaPizza.Image, nuovaPizza.Prezzo);

                db.Pizze.Add(pizzaToCreate);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Update(string name)
        {
            Pizza pizzaToEdit = null;

            using (PizzeriaContext db = new PizzeriaContext())
            {
                pizzaToEdit = db.Pizze
                     .Where(post => post.Name == name)
                     .FirstOrDefault();

            }


            if (pizzaToEdit != null)
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
            Pizza pizzaToEdit = null;

            using (PizzeriaContext db = new PizzeriaContext())
            {
                pizzaToEdit = db.Pizze
                     .Where(post => post.Name == name)
                     .FirstOrDefault();


                if (pizzaToEdit != null)
                {
                    pizzaToEdit.Name = model.Name;
                    pizzaToEdit.Description = model.Description;
                    pizzaToEdit.Image = model.Image;
                    pizzaToEdit.Prezzo = model.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [HttpPost]
        public IActionResult Delete(string name)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToDelete = db.Pizze
                     .Where(post => post.Name == name)
                     .FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Pizze.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

        }

    }
}
