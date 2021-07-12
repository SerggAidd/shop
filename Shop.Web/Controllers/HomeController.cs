using Shop.Db.Context;
using Shop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ShopContext appContext = new ShopContext();
            ProductSectionEntity section = new ProductSectionEntity();
            appContext.ProductSection.Add(section);

            section.Name = "Test";
            appContext.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}