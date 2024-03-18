using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Model;
using PeopleManager.Sdk;
using PeopleManager.Services;

namespace PeopleManager.Cyb.Ui.Mvc.Controllers
{
    //[Authorize]
    public class PeopleController(
        PersonService personService,
        PersonSdk personSdk) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var people = await personSdk.Find();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            personService.Create(person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int id)
        {
            var person = personService.Get(id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            personService.Update(id, person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute]int id)
        {
            var person = personService.Get(id);
            return View(person);
        }

        [HttpPost("/people/delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            personService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
