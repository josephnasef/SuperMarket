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
    public class SuppliersController : Controller
    {
        private readonly SupplierManger _supplierManger;
        private readonly AppUserManger _appUserManger;

        public SuppliersController(SupplierManger supplierMangerPram, AppUserManger appUserMangerPram)
        {
            this._supplierManger = supplierMangerPram;
            this._appUserManger = appUserMangerPram;
        }

        // GET: Suppliers
        public ActionResult Index()
        {
            var supplier = _supplierManger.GettAll().Include(s => s.AppUser);
            return View(supplier.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _supplierManger.GetBy(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.AppUserId = new SelectList(_appUserManger.GettAll(), "Id", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Email,Address,Rate,AppUserId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.CreatedDate = DateTime.Now;
                supplier.UpdatedDate = DateTime.Now;
                supplier.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                supplier.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _supplierManger.Add(supplier);
                
                return RedirectToAction("Index");
            }

            ViewBag.AppUserId = new SelectList(_appUserManger.GettAll(), "Id", "Name", supplier.AppUserId);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _supplierManger.GetBy(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppUserId = new SelectList(_appUserManger.GettAll(), "Id", "Name", supplier.AppUserId);

            return View(supplier);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Email,Address,Rate,AppUserId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.UpdatedDate = DateTime.Now;
                supplier.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;


                _supplierManger.Update(supplier);
                return RedirectToAction("Index");
            }
            ViewBag.AppUserId = new SelectList(_appUserManger.GettAll(), "Id", "Name", supplier.AppUserId);
            return View(supplier);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _supplierManger.GetBy(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = _supplierManger.GetBy(id);
            supplier.IsArchived = true;
            _supplierManger.Save();
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
