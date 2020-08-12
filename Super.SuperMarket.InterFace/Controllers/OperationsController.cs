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
    public class OperationsController : Controller
    {
        private Context db = new Context();

        // GET: Operations
        public ActionResult Index()
        {
            var operation = db.Operation.Include(o => o.Bill).Include(o => o.OperationType).Include(o => o.Product);
            return View(operation.ToList());
        }

        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operation.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

       
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
