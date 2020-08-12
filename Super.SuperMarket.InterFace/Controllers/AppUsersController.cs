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
    public class AppUsersController : Controller
    {
        private readonly AppUserManger _appUserManger;
        private readonly RoleManger _roleManger;
        public AppUsersController(AppUserManger appUserMangerPram,RoleManger roleMangerPram)
        {
            this._appUserManger = appUserMangerPram;
            this._roleManger = roleMangerPram;
        }

        public ActionResult Index()
        {
            var appUser = _appUserManger.GettAll().Include(a => a.Role);
            return View(appUser.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = _appUserManger.GetBy(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(_roleManger.GettAll(), "Id", "Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,RoleId,BirthDay,PhotoUrl,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                appUser.CreatedDate = DateTime.Now;
                appUser.UpdatedDate = DateTime.Now;
                appUser.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                appUser.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _appUserManger.Add(appUser);
                
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(_roleManger.GettAll(), "Id", "Name", appUser.RoleId);
            return View(appUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = _appUserManger.GetBy(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(_roleManger.GettAll(), "Id", "Name");
            return View(appUser);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Phone,RoleId,BirthDay,PhotoUrl,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsArchived")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                appUser.UpdatedDate = DateTime.Now;
                appUser.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _appUserManger.Update(appUser);
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(_roleManger.GettAll(), "Id", "Name", appUser.RoleId);
            return View(appUser);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = _appUserManger.GetBy(id);
          
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppUser appUser = _appUserManger.GetBy(id);

            _appUserManger.Remove(appUser);
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
