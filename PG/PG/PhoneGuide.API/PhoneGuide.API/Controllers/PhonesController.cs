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
    public class PhonesController : ApiController
    {
        DataContext db = new DataContext();
        /// <summary>
        /// Telefon Numarası Ekler
        /// </summary>
        /// <param name="phone">Eklenecek Telefon Numarası</param>
        public void PutPhone(Phones phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
        }
        /// <summary>
        /// Kişinin Telefonlarını Gösterir
        /// </summary>
        /// <param name="id">Person id</param>
        /// <returns></returns>
        public List<PhonesModel> GetPersonPhones(int id)
        {
            return db.Phones.Where(x => x.PersonID == id).Select(a => new PhonesModel
            {
                TelephoneID = a.TelephoneID,
                PersonID = a.PersonID,
                Category = a.Categories.CategoryName,
                PhoneNumber = a.PhoneNumber
            }).ToList();
        }
        /// <summary>
        /// Telefon Numarası Siler
        /// </summary>
        /// <param name="id">Silinecek Telefon id</param>
        public void DeletePhone(int id)
        {
            var Phone = db.Phones.FirstOrDefault(x => x.TelephoneID == id);
            db.Phones.Remove(Phone);
            db.SaveChanges();
        }
        /// <summary>
        /// Telefon Numarası Günceller
        /// </summary>
        /// <param name="p">Güncellenecek Telefon</param>
        public void PostPhone(Phones p)
        {
            var Phone = db.Phones.FirstOrDefault(x => x.TelephoneID == p.TelephoneID);
            Phone.PhoneNumber = p.PhoneNumber;
            Phone.CategoryID = p.CategoryID;
            Phone.PersonID = p.PersonID;
            db.SaveChanges();
        }
    }
}
