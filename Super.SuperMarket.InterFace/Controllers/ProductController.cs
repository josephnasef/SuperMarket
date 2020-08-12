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
using Super.SuperMarket.InterFace.Models;

namespace Super.SuperMarket.InterFace.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManger _productManger;
        private readonly CategoryManger _categoryManger;
        private readonly SupplierManger _supplierManger;

        public ProductController(ProductManger productMangerPram, CategoryManger categoryMangerPram, SupplierManger supplierMangerPram)
        {
            this._categoryManger = categoryMangerPram;
            this._productManger = productMangerPram;
            this._supplierManger = supplierMangerPram;
        }

        #region CRUD
        public ActionResult List(string CategoryName)
        {
            List<Product> Mylist = new List<Product>();
            ProductsListViewModel model = new ProductsListViewModel();
            if (CategoryName==null)
            {
                Mylist = _productManger.GettAll().Where(p => p.IsArchived == false&&p.Category.HiddInMenu==false).ToList();
                model.Products = Mylist;

            }
            else
            {
                Mylist = _productManger.GettAll().Where(p => 
                p.Category.Name == CategoryName 
                && p.IsArchived == false 
                && p.Category.HiddInMenu == false ).ToList();
                model.Products =  Mylist;
            }
             
            return View(model);
        }
        public ActionResult Index()
        {
            var product = _productManger.GettAll().Include(p => p.Category).Include(p => p.Supplier).Where(t=>t.IsArchived==false);
            return View(product.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManger.GetBy(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            setCategoryAndSupplierlist();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BarcodeNumber,Name,PurchasePrice,SellingPrice,MadeInCountry,ProductionDate,ExpiryDate,HasGuarantee,CategoryId,SupplierId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived,Quentity")] Product product)
        {
            if (ModelState.IsValid)
            {
                
              var maybe = _productManger.GetAllBind().Where(c=>c.CategoryId== product.CategoryId && c.IsArchived==false);
                if (maybe.FirstOrDefault()==null)
                {
                    Category category = _categoryManger.GetBy(product.CategoryId);
                    category.HiddInMenu = false;
                    _categoryManger.Save();
                }
               
                product.CreatedDate = DateTime.Now;
                product.UpdatedDate = DateTime.Now;
                product.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                product.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                setCategoryAndSupplierlist();
                _productManger.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManger.GetBy(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            GetChoiceSupplierAndCategory(product);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BarcodeNumber,Name,PurchasePrice,SellingPrice,MadeInCountry,ProductionDate,ExpiryDate,HasGuarantee,CategoryId,SupplierId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived,Quentity")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.UpdatedDate = DateTime.Now;
                product.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _productManger.Update(product);

                return RedirectToAction("Index");
            }
            GetChoiceSupplierAndCategory(product);
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManger.GetBy(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _productManger.GetBy(id);
            var Myproduct = product.CategoryId;
            var maybe = _productManger.GetAllBind().Where(c => c.CategoryId == Myproduct && c.IsArchived == false);
            product.IsArchived = true;

            if (maybe.FirstOrDefault() == null)
            {
                Category category = _categoryManger.GetBy(product.CategoryId);
                category.HiddInMenu = true;
                _categoryManger.Save();
            }

            _productManger.Save();

            return RedirectToAction("Index");
        }
        #endregion
        public ActionResult Vview()
        {
            return View();
        }
        #region help

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void setCategoryAndSupplierlist()
        {
            ViewBag.CategoryId = new SelectList(_categoryManger.GettAll().Where(c=>c.IsArchived==false), "Id", "Name");
            ViewBag.SupplierId = new SelectList(_supplierManger.GettAll().Where(c => c.IsArchived == false), "Id", "Name");
        }
        private void GetChoiceSupplierAndCategory(Product product)
        {
            ViewBag.CategoryId = new SelectList(_categoryManger.GettAll().Where(c => c.IsArchived == false), "Id", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(_supplierManger.GettAll().Where(c => c.IsArchived == false), "Id", "Name", product.SupplierId);
        }
        
        #endregion

    }


}
