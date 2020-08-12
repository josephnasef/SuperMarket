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

namespace Super.SuperMarket.InterFace.Controllers
{
    public class BillsController : Controller
    {
        private Context db = new Context();

        // GET: Bills
        public ActionResult Index()
        {
            var bill = db.Bill.Include(b => b.OperationType).Include(b => b.PaymentMethod);
            return View(bill.ToList());
        }

        // GET: Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

      

        // GET: Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.OperationTypeId = new SelectList(db.OperationType, "Id", "Name", bill.OperationTypeId);
            ViewBag.paymentMethodId = new SelectList(db.PaymentMethod, "Id", "Name", bill.paymentMethodId);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullPrice,DateOfExpire,OperationTypeId,paymentMethodId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OperationTypeId = new SelectList(db.OperationType, "Id", "Name", bill.OperationTypeId);
            ViewBag.paymentMethodId = new SelectList(db.PaymentMethod, "Id", "Name", bill.paymentMethodId);
            return View(bill);
        }

        // GET: Bills/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bill bill = db.Bill.Find(id);
        //    if (bill == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bill);
        //}

        //// POST: Bills/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Bill bill = db.Bill.Find(id);
        //    db.Bill.Remove(bill);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
