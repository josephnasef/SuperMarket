using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Super.SuperMarket.DAl.SQLServer.Context;
using Super.SuperMarket.DAl.SQLServer.Model;
using Super.SuperMarket.Domain.Mangers;

namespace Super.SuperMarket.InterFace.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryManger _CategoryManger;
        private ProductManger _ProductManger;

        public CategoriesController(CategoryManger CategoryPram , ProductManger ProductMangerPram)
        {
            this._ProductManger = ProductMangerPram;
            this._CategoryManger = CategoryPram;
        }

        public ActionResult Index()
        {
            return View(_CategoryManger.GettAll().Where(C=>C.IsArchived==false).ToList());

        }
        public PartialViewResult Menu(string CategoryName = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = CategoryName;
            var list = _CategoryManger.categories();
            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryManger.GetBy(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                category.UpdatedDate = DateTime.Now;
                category.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                category.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                category.HiddInMenu = true;
                _CategoryManger.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryManger.GetBy(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.UpdatedDate = DateTime.Now;
                category.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;

                _CategoryManger.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryManger.GetBy(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _CategoryManger.GetBy(id);
            category.IsArchived = true;
            category.HiddInMenu = true;
            List<Product> MyProductList = new List<Product>();
            MyProductList = _ProductManger.GettAll().Where(c=>c.CategoryId== category.Id).ToList();
            foreach (var item in MyProductList)
            {
                item.IsArchived = true;
            }
            _ProductManger.Save();
            _CategoryManger.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
