using Shop.BL.Product;
using Shop.BL.ProductSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
            InitViewBags();
        }
        // GET: Product
        public ActionResult Index()
        {
            ProductService productService = new ProductService();
            var list = productService.GetList();
            return View(list);
        }
        public ActionResult Edit(int id = 0)
        {
            ProductService productService = new ProductService();
            ProductViewModal model = new ProductViewModal();

            if (id > 0)
            {
                var entity = productService.GetById(id);
                model = productService.Mapper(entity);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModal model)
        {
            if (ModelState.IsValid)
            {
                ProductService productService = new ProductService();
                productService.Edit(model);
                return RedirectToAction("Index");
                
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                ProductService srv = new ProductService();
                if (srv.Delete(id)) return RedirectToAction("index");
                else return View();
            }
            return View();
        }

        private void InitViewBags()
        {
            ProductSectionService sectionService = new ProductSectionService();
            ViewBag.ListSections = new SelectList(sectionService.GetList(), "ID", "Name");
        }
    }
}