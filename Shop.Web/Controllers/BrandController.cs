using Shop.BL.Brand;
using Shop.BL.ProductSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class BrandController : Controller
    {
        public BrandController()
        {
           // InitViewBags();
        }
        // GET: Brand
        public ActionResult Index()
        {
            BrandService BrandService = new BrandService();
            var list = BrandService.GetList();
            return View(list);
        }
        public ActionResult Edit(int id = 0)
        {
            BrandService BrandService = new BrandService();
            BrandViewModal model = new BrandViewModal();

            if (id > 0)
            {
                var entity = BrandService.GetById(id);
                model = BrandService.Mapper(entity);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandViewModal model)
        {
            if (ModelState.IsValid)
            {
                BrandService BrandService = new BrandService();
                BrandService.Edit(model);
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                BrandService srv = new BrandService();
                if (srv.Delete(id)) return RedirectToAction("index");
                else return View();
            }
            return View();
        }
    }
}