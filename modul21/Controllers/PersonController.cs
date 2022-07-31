using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modul21.Models.DataBase;
using modul21.Models.DataBase.ContextFolder;
using modul21.Models.Entitys;

namespace modul21.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Persons = DataBaseTools.GetAllPersons();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Person person = DataBaseTools.GetPerson(id);
                return View(person);
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Person person = DataBaseTools.GetPerson(id);
                if (person != null) return View(person);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Person person = DataBaseTools.GetPerson(id);
                if (person != null)
                {
                    DataBaseTools.DeletePerson(person);
                    return Redirect("~/");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            DataBaseTools.UpdatePerson(person);
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult AddNewPerson(string firstName, string lastName, string middleName, string phoneNumber, string address, string description)
        {
            if ((firstName ?? lastName ?? middleName ?? phoneNumber ?? address ?? description) != null)
            {
                Person newPerson = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    Description = description
                };
                DataBaseTools.AddPerson(newPerson);
            }
            return Redirect("~/");
        }
    }
}
