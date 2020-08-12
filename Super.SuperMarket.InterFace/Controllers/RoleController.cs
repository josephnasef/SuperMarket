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
    public class RoleController : Controller
    {
        private readonly RoleManger _roleManger;
        public RoleController(RoleManger roleMangerPram)
        {
            this._roleManger = roleMangerPram;
        }

        public ActionResult Index()
        {
            return View(_roleManger.GettAll().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleManger.GetBy(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] Role role)
        {
            if (ModelState.IsValid)
            {
                role.CreatedDate = DateTime.Now;
                role.UpdatedDate = DateTime.Now;
                role.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                role.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _roleManger.Add(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleManger.GetBy(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] Role role)
        {
            if (ModelState.IsValid)
            {
                role.UpdatedDate = DateTime.Now;               
                role.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _roleManger.Update(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleManger.GetBy(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = _roleManger.GetBy(id);
            role.IsArchived = true;
            _roleManger.Save();
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
