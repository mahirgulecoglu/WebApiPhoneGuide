using PhoneGuide.WebUI.HTTPHelper;
using PhoneGuide.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneGuide.WebUI.Controllers
{
    public class PhonesController : Controller
    {
        // GET: Phones
        public ActionResult GetPersonPhones(int id)
        {
            var PersonPhones = HttpHelper.GetRequestByID<List<Phones>>("http://localhost:61601/", "Phones/GetPersonPhones", RestSharp.Method.GET, id);
            Session["PersonID"] = id;
            return View(PersonPhones);
        }
        public ActionResult NewPhoneForm()
        {
            Session["Category"] = HttpHelper.GetList<List<Categories>>("http://localhost:61601/", "Categories/GetCategories", RestSharp.Method.GET);

            return View(new PhoneAddModel());
        }
        public ActionResult AddPhone(PhoneAddModel ppm)
        {
            ppm.PersonID = (int)Session["PersonID"];
            HttpHelper.PostRequest("http://localhost:61601/", "Phones/PutPhone", RestSharp.Method.PUT, ppm);
            return RedirectToRoute(new { controller = "Phones", action = "GetPersonPhones", id = ppm.PersonID });
        }
        public ActionResult DeletePhone(int id)
        {
            HttpHelper.DeleteRequest("http://localhost:61601/", "Phones/DeletePhone", RestSharp.Method.DELETE, id);
            return RedirectToRoute(new { controller = "Phones", action = "GetPersonPhones", id = (int)Session["PersonID"] });
        }
    }
}