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
    public class CategoriesController : ApiController
    {
        DataContext db = new DataContext();
        /// <summary>
        /// Kategorileri Getirir
        /// </summary>
        /// <returns></returns>
        public List<CategoriesModel> GetCategories()
        {
            return db.Categories.Select(x => new CategoriesModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            }).ToList();
        }
    }
}
