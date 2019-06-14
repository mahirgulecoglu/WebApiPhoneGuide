using PhoneGuide.WebUI.Models;
using PhoneGuide.WebUI.HTTPHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneGuide.WebUI.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult PersonList()
        {
            var PersonList = HttpHelper.GetList<List<Persons>>("http://localhost:61601/", "Person/GetPersons", RestSharp.Method.GET);
            return View(PersonList);
        }
        public ActionResult AddPerson(Persons prs)
        {
            HttpHelper.PostRequest("http://localhost:61601/", "Person/PutPerson", RestSharp.Method.PUT, prs);
            return RedirectToAction("PersonList");
        }
        public ActionResult GetByIDPerson(int id)
        {
            var Person = HttpHelper.GetRequestByID<Persons>("http://localhost:61601/", "Person/GetPersonDetail", RestSharp.Method.GET, id);

            var PersonPhones = HttpHelper.GetRequestByID<List<Phones>>("http://localhost:61601/", "Phone/GetPersonPhones", RestSharp.Method.GET, id);

            var PersonDetailModel = new PersonDetailModel { Person = Person, Phones = PersonPhones };
            return View(PersonDetailModel);
        }
        public ActionResult UpdatePerson(PersonDetailModel prs)
        {
            HttpHelper.PostRequest("http://localhost:61601/", "Person/PostPerson", RestSharp.Method.POST, prs.Person);
            return RedirectToAction("PersonList");
        }
        public ActionResult DeletePerson(int id)
        {
            HttpHelper.DeleteRequest("http://localhost:61601/", "Person/DeletePerson", RestSharp.Method.DELETE, id);
            return RedirectToAction("Personlist");
        }

        public ActionResult PersonForm()
        {
            return View(new Persons());
        }


    }
}