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
    public class PaymentMethodsController : Controller
    {
        private readonly PaymentMethodManger _paymentMethodManger;
        public PaymentMethodsController(PaymentMethodManger paymentMethodMangerPram)
        {
            this._paymentMethodManger = paymentMethodMangerPram;
        }

        public ActionResult Index()
        {
            return View(_paymentMethodManger.GettAll().ToList().Where(c=>c.IsArchived==false));
        }

        public PartialViewResult Menu(string CategoryName = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedPaymentMethod = CategoryName;
            var list = _paymentMethodManger.PaymentMethods();
            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = _paymentMethodManger.GetBy(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                paymentMethod.CreatedDate = DateTime.Now;
                paymentMethod.UpdatedDate = DateTime.Now;
                paymentMethod.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                paymentMethod.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _paymentMethodManger.Add(paymentMethod);
                return RedirectToAction("Index");
            }

            return View(paymentMethod);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = _paymentMethodManger.GetBy(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                paymentMethod.UpdatedDate = DateTime.Now;
                paymentMethod.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _paymentMethodManger.Update(paymentMethod);
                return RedirectToAction("Index");
            }
            return View(paymentMethod);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = _paymentMethodManger.GetBy(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentMethod paymentMethod = _paymentMethodManger.GetBy(id);
            paymentMethod.IsArchived = true;
            _paymentMethodManger.Save();
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
