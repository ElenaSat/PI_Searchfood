using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PI_SearchfoodF.MVC.DAL;

namespace PI_SearchfoodF.MVC.Controllers
{
    public class tbTipoIncidenciasController : Controller
    {
        private BD_SEARCHFOODEntities db = new BD_SEARCHFOODEntities();

        // GET: tbTipoIncidencias
        public ActionResult Index()
        {
            return View(db.tbTipoIncidencia.ToList());
        }

        // GET: tbTipoIncidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoIncidencia tbTipoIncidencia = db.tbTipoIncidencia.Find(id);
            if (tbTipoIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoIncidencia);
        }

        // GET: tbTipoIncidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbTipoIncidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_TipoIncidencia,TipoInDescripcion")] tbTipoIncidencia tbTipoIncidencia)
        {
            if (ModelState.IsValid)
            {
                db.tbTipoIncidencia.Add(tbTipoIncidencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbTipoIncidencia);
        }

        // GET: tbTipoIncidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoIncidencia tbTipoIncidencia = db.tbTipoIncidencia.Find(id);
            if (tbTipoIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoIncidencia);
        }

        // POST: tbTipoIncidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_TipoIncidencia,TipoInDescripcion")] tbTipoIncidencia tbTipoIncidencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTipoIncidencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbTipoIncidencia);
        }

        // GET: tbTipoIncidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoIncidencia tbTipoIncidencia = db.tbTipoIncidencia.Find(id);
            if (tbTipoIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoIncidencia);
        }

        // POST: tbTipoIncidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTipoIncidencia tbTipoIncidencia = db.tbTipoIncidencia.Find(id);
            db.tbTipoIncidencia.Remove(tbTipoIncidencia);
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
