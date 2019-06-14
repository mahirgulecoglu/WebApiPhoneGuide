using PhoneGuide.API.Models;
using PhoneGuide.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneGuide.API.Controllers
{
    public class PersonController : ApiController
    {
        DataContext db = new DataContext();
        /// <summary>
        /// Person Listesini Getirir
        /// </summary>
        /// <returns></returns>
      
        public List<PersonsModel> GetPersons()
        {
            return db.Persons.Select(x => new PersonsModel
            {
                PersonID = x.PersonID,
                Name = x.Name,
                LastName = x.LastName,
                City = x.City,
                Country = x.Country,
                Email = x.Email,
                Phone = x.Phones.Where(a => a.CategoryID == 1).Select(a => a.PhoneNumber).FirstOrDefault()
            }).ToList();
        }
        /// <summary>
        /// Seçilen Person Detail Gösterir
        /// </summary>
        /// <param name="id">Detay Getirilecek Person</param>
        /// <returns></returns>
        public PersonsModel GetPersonDetail(int id)
        {
            return db.Persons.Where(x => x.PersonID == id).Select(x => new PersonsModel
            {
                PersonID = x.PersonID,
                Name = x.Name,
                LastName = x.LastName,
                City = x.City,
                Country = x.Country,
                Email = x.Email,
                Phone = x.Phones.Where(a => a.CategoryID == 1).Select(a => a.PhoneNumber).FirstOrDefault()
            }).FirstOrDefault();
        }
        /// <summary>
        /// Person Ekler
        /// </summary>
        /// <param name="prs">Eklenecek Person</param>
        public void PutPerson(Persons prs)
        {
            db.Persons.Add(prs);
            db.SaveChanges();
        }
        /// <summary>
        /// Person Update Eder
        /// </summary>
        /// <param name="prs">Güncellenecek Person</param>
        public void PostPerson(Persons prs)
        {
            var Person = db.Persons.FirstOrDefault(x => x.PersonID == prs.PersonID);
            Person.Name = prs.Name;
            Person.LastName = prs.LastName;
            Person.City = prs.City;
            Person.Country = prs.Country;
            Person.Email = prs.Email;
            db.SaveChanges();
        }
        /// <summary>
        /// Kişi Siler
        /// </summary>
        /// <param name="id">Silinecek Person</param>
        public void DeletePerson(int id)
        {
            var Person = db.Persons.FirstOrDefault(x => x.PersonID == id);
            var PersonPhone = db.Phones.Where(x => x.PersonID == id).ToList();
            db.Phones.RemoveRange(PersonPhone);
            db.Persons.Remove(Person);
            db.SaveChanges();
        }
    }
}
