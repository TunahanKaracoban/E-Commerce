using Shopping.Context;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        ContextDb db = new ContextDb();
        // GET: Home
        public ActionResult Index()
        {
            var model = db.Products.Where(i=>i.HomePage&&i.IsActive).ToList();
           
            return View(model);
        }
        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i =>i.Id==id).FirstOrDefault());
        }
        public ActionResult Product()
        {
            return View(db.Products.Where(i=>i.IsActive).ToList());
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i => i.CategoryId == id).ToList());
        }
        public ActionResult Search(string a)
        {
            var model = db.Products.Where(i => i.IsActive == true);
            if (!string.IsNullOrEmpty(a))
            {
                model = model.Where(i => i.Name.Contains(a) || i.Description.Contains(a));
            }
            return View(model.ToList());
        }
        public ActionResult _Slider()
        {
            return PartialView(db.Products.Where(x => x.Slider && x.IsActive).ToList());
        }
    }
}