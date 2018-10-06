using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PI_Searchfood.MVC.DAL;

namespace PI_Searchfood.MVC.Controllers
{
    public class tbTipoIncidentesController : Controller
    {
        private BD_SEARCHFOODEntities db = new BD_SEARCHFOODEntities();

        // GET: tbTipoIncidentes
        public ActionResult Index()
        {
            return View(db.tbTipoIncidente.ToList());
        }

        // GET: tbTipoIncidentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoIncidente tbTipoIncidente = db.tbTipoIncidente.Find(id);
            if (tbTipoIncidente == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoIncidente);
        }

        // GET: tbTipoIncidentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbTipoIncidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tipo,Descripcion")] tbTipoIncidente tbTipoIncidente)
        {
            if (ModelState.IsValid)
            {
                db.tbTipoIncidente.Add(tbTipoIncidente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbTipoIncidente);
        }

        // GET: tbTipoIncidentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoIncidente tbTipoIncidente = db.tbTipoIncidente.Find(id);
            if (tbTipoIncidente == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoIncidente);
        }

        // POST: tbTipoIncidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_tipo,Descripcion")] tbTipoIncidente tbTipoIncidente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTipoIncidente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbTipoIncidente);
        }

        // GET: tbTipoIncidentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoIncidente tbTipoIncidente = db.tbTipoIncidente.Find(id);
            if (tbTipoIncidente == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoIncidente);
        }

        // POST: tbTipoIncidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTipoIncidente tbTipoIncidente = db.tbTipoIncidente.Find(id);
            db.tbTipoIncidente.Remove(tbTipoIncidente);
            db.SaveChanges();
            return RedirectToAction("Index");
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
