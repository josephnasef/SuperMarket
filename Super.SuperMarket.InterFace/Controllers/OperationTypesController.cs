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
    public class OperationTypesController : Controller
    {
        private readonly OperationTypeManger _operationTypeManger ;
        public OperationTypesController(OperationTypeManger operationTypeMangerPram)
        {
            this._operationTypeManger = operationTypeMangerPram;
        }

        public ActionResult Index()
        {
            return View(_operationTypeManger.GettAll().Where(o=>o.IsArchived==false).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationType operationType = _operationTypeManger.GetBy(id);
            if (operationType == null)
            {
                return HttpNotFound();
            }
            return View(operationType);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] OperationType operationType)
        {
            if (ModelState.IsValid)
            {
                operationType.CreatedDate = DateTime.Now;
                operationType.UpdatedDate = DateTime.Now;
                operationType.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                operationType.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _operationTypeManger.Add(operationType);
                return RedirectToAction("Index");
            }

            return View(operationType);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationType operationType = _operationTypeManger.GetBy(id);
            if (operationType == null)
            {
                return HttpNotFound();
            }
            return View(operationType);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] OperationType operationType)
        {
            if (ModelState.IsValid)
            {
                operationType.UpdatedDate = DateTime.Now;
                operationType.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _operationTypeManger.Update(operationType);
                return RedirectToAction("Index");
            }
            return View(operationType);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationType operationType = _operationTypeManger.GetBy(id);
            if (operationType == null)
            {
                return HttpNotFound();
            }
            return View(operationType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OperationType operationType = _operationTypeManger.GetBy(id);
            operationType.IsArchived = true;
            _operationTypeManger.Save();
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
