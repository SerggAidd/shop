using Shop.BL.Tag;
using Shop.BL.ProductSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.BL.Brand;

namespace Shop.Web.Controllers
{
    public class TagController : Controller
    {
        public TagController()
        {
           // InitViewBags();
        }
        // GET: Tag
        public ActionResult Index()
        {
            TagService TagService = new TagService();
            var list = TagService.GetList();
            return View(list);
        }
        public ActionResult Edit(int id = 0)
        {
            TagService TagService = new TagService();
            TagViewModal model = new TagViewModal();

            if (id > 0)
            {
                var entity = TagService.GetById(id);
                model = TagService.Mapper(entity);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TagViewModal model)
        {
            if (ModelState.IsValid)
            {
                TagService TagService = new TagService();
                TagService.Edit(model);
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                TagService srv = new TagService();
                if (srv.Delete(id)) return RedirectToAction("index");
                else return View();
            }
            return View();
        }
    }
}