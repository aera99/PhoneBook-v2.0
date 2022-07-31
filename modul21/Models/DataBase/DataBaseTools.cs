using Microsoft.EntityFrameworkCore;
using modul21.Models.DataBase.ContextFolder;
using modul21.Models.Entitys;

namespace modul21.Models.DataBase
{
    public static class DataBaseTools
    {
        public static List<Person> GetAllPersons()
        {
            using (var db = new DataContext())
            {
                return db.Persons.ToList();
            }
        }
        public static Person GetPerson(int? id)
        {
            if (id != null)
            {
                using (var db = new DataContext())
                {
                    Person person = db.Persons.FirstOrDefault(x => x.Id == id);
                    if (person != null) return person;
                }
            }
            return null;
        }
        public static void AddPerson(Person person)
        {
            if (person != null)
            {
                using (var db = new DataContext())
                {
                    db.Persons.Add(person);
                    db.SaveChanges();
                }
            }
        }
        public static void DeletePerson(Person person)
        {
            if (person != null)
            {
                using (var db = new DataContext())
                {
                    var prsn = db.Persons.Find(person.Id);
                    if (prsn != null)
                    {
                        db.Persons.Remove(prsn);
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void DeletePerson(int? id)
        {
            if (id != null)
            {
                using (var db = new DataContext())
                {
                    var prsn = db.Persons.Find(id);
                    if (prsn != null)
                    {
                        db.Persons.Remove(prsn);
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void UpdatePerson(Person oldPerson)
        {
            if (oldPerson != null)
            {
                using (var db = new DataContext())
                {
                    var person = db.Persons.Find(oldPerson.Id);
                    if (person != null)
                    {
                        person.FirstName = oldPerson.FirstName;
                        person.LastName = oldPerson.LastName;
                        person.MiddleName = oldPerson.MiddleName;
                        person.PhoneNumber = oldPerson.PhoneNumber;
                        person.Address = oldPerson.Address;
                        person.Description = oldPerson.Description;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
