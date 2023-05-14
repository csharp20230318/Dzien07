using Microsoft.AspNetCore.Mvc;
using System;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class PersonController : Controller
    {
        static IList<Person> peopleList = new List<Person>
        {
            new Person {PersonId = 1 , PersonName= "Jan Kowalski", PersonAge=33},
            new Person {PersonId = 6 , PersonName= "Marian Kowalski", PersonAge=44},
            new Person {PersonId = 4 , PersonName= "Jan Rokita", PersonAge=39},
            new Person {PersonId = 3 , PersonName= "Zenon Martyniuk", PersonAge=65},
            new Person {PersonId = 5 , PersonName= "Agnieszka Osiecka", PersonAge=21},
            new Person {PersonId = 2 , PersonName= "Jacek Cygan", PersonAge=33},
        };

        public IActionResult Index()
        {
            return View(peopleList.OrderBy(x => x.PersonId).ToList());
        }

        public IActionResult Edit(int Id)
        {
            var person = peopleList.Where(x => x.PersonId == Id).FirstOrDefault();
            if (person==null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
			// update
			var p = peopleList.Where(x => x.PersonId == person.PersonId).FirstOrDefault();
			if (p == null)
			{
				return NotFound();
			}
            peopleList.Remove(p);
            peopleList.Add(person);
			return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
			var p = peopleList.Where(x => x.PersonId == Id).FirstOrDefault();
			if (p == null)
			{
				return NotFound();
			}
            //peopleList.Remove(p);
            //return RedirectToAction("Index");
            return View(p);
		}

        [HttpPost]
        public IActionResult DeleteConfirmed(Person person)
        {
			var p = peopleList.Where(x => x.PersonId == person.PersonId).FirstOrDefault();
			if (p == null)
			{
				return NotFound();
			}
			peopleList.Remove(p);
			return RedirectToAction("Index");
		}

	}
}
