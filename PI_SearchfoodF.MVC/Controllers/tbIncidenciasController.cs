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
    public class tbIncidenciasController : Controller
    {
        private BD_SEARCHFOODEntities db = new BD_SEARCHFOODEntities();

        // GET: tbIncidencias
        public ActionResult Index()
        {
            var tbIncidencia = db.tbIncidencia.Include(t => t.tbEstado_Incidencia).Include(t => t.tbTipoIncidencia);
            return View(tbIncidencia.ToList());
        }

        // GET: tbIncidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIncidencia tbIncidencia = db.tbIncidencia.Find(id);
            if (tbIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tbIncidencia);
        }

        // GET: tbIncidencias/Create
        public ActionResult Create()
        {
            ViewBag.Estado_Indicencia = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion");
            ViewBag.Tipo_Incidencia = new SelectList(db.tbTipoIncidencia, "Id_TipoIncidencia", "TipoInDescripcion");
            return View();
        }

        // POST: tbIncidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Identificacion,primer_nombre,segundo_nombrre,primer_apellido,segundo_apellido,direccion,telefono,correo,Estado_Indicencia,Tipo_Incidencia")] tbIncidencia tbIncidencia)
        {
            if (ModelState.IsValid)
            {
                db.tbIncidencia.Add(tbIncidencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado_Indicencia = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion", tbIncidencia.Estado_Indicencia);
            ViewBag.Tipo_Incidencia = new SelectList(db.tbTipoIncidencia, "Id_TipoIncidencia", "TipoInDescripcion", tbIncidencia.Tipo_Incidencia);
            return View(tbIncidencia);
        }

        // GET: tbIncidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIncidencia tbIncidencia = db.tbIncidencia.Find(id);
            if (tbIncidencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_Indicencia = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion", tbIncidencia.Estado_Indicencia);
            ViewBag.Tipo_Incidencia = new SelectList(db.tbTipoIncidencia, "Id_TipoIncidencia", "TipoInDescripcion", tbIncidencia.Tipo_Incidencia);
            return View(tbIncidencia);
        }

        // POST: tbIncidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Identificacion,primer_nombre,segundo_nombrre,primer_apellido,segundo_apellido,direccion,telefono,correo,Estado_Indicencia,Tipo_Incidencia")] tbIncidencia tbIncidencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbIncidencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_Indicencia = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion", tbIncidencia.Estado_Indicencia);
            ViewBag.Tipo_Incidencia = new SelectList(db.tbTipoIncidencia, "Id_TipoIncidencia", "TipoInDescripcion", tbIncidencia.Tipo_Incidencia);
            return View(tbIncidencia);
        }

        // GET: tbIncidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIncidencia tbIncidencia = db.tbIncidencia.Find(id);
            if (tbIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tbIncidencia);
        }

        // POST: tbIncidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbIncidencia tbIncidencia = db.tbIncidencia.Find(id);
            db.tbIncidencia.Remove(tbIncidencia);
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
