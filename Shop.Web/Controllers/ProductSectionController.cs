using Shop.BL.ProductSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ProductSectionController : Controller
    {
        // GET: ProductSection
        public ActionResult Index()
        {
            ProductSectionService productSectionService = new ProductSectionService();
            var list = productSectionService.GetList();
            return View(list);
        }
        public ActionResult Edit(int id = 0)
        {
            ProductSectionViewModal model = new ProductSectionViewModal();
            if (id > 0)
            {
                ProductSectionService productSectionService = new ProductSectionService();

                var entity = productSectionService.GetById(id);
                model = productSectionService.Mapper(entity);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSectionViewModal model)
        {
            if (ModelState.IsValid)
            {
                ProductSectionService productSectionService = new ProductSectionService();
                productSectionService.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                ProductSectionService srv = new ProductSectionService();
                if (srv.Delete(id)) return RedirectToAction("index");
                else return View();
            }
            return View();
        }
    }
}