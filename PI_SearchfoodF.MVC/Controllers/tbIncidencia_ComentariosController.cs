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
    public class tbIncidencia_ComentariosController : Controller
    {

        private BD_SEARCHFOODEntities db = new BD_SEARCHFOODEntities();

        // GET: tbIncidencia_Comentarios
        public ActionResult Index()
        {
            var tbIncidencia_Comentarios = db.tbIncidencia_Comentarios.Include(t => t.tbEstado_Incidencia).Include(t => t.tbIncidencia);
            return View(tbIncidencia_Comentarios.ToList());
        }

        // GET: tbIncidencia_Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIncidencia_Comentarios tbIncidencia_Comentarios = db.tbIncidencia_Comentarios.Find(id);
            if (tbIncidencia_Comentarios == null)
            {
                return HttpNotFound();
            }
            return View(tbIncidencia_Comentarios);
        }

        // GET: tbIncidencia_Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.Estado_Incidencia_IDCom = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion");
            ViewBag.Id_Incidencia = new SelectList(db.tbIncidencia, "Id", "primer_nombre");
            return View();
        }

        // POST: tbIncidencia_Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_ICom,Id_Incidencia,Comentarios,Estado_Incidencia_IDCom")] tbIncidencia_Comentarios tbIncidencia_Comentarios)
        {
            if (ModelState.IsValid)
            {
                db.tbIncidencia_Comentarios.Add(tbIncidencia_Comentarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado_Incidencia_IDCom = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion", tbIncidencia_Comentarios.Estado_Incidencia_IDCom);
            ViewBag.Id_Incidencia = new SelectList(db.tbIncidencia, "Id", "primer_nombre", tbIncidencia_Comentarios.Id_Incidencia);
            return View(tbIncidencia_Comentarios);
        }

        // GET: tbIncidencia_Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIncidencia_Comentarios tbIncidencia_Comentarios = db.tbIncidencia_Comentarios.Find(id);
            if (tbIncidencia_Comentarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_Incidencia_IDCom = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion", tbIncidencia_Comentarios.Estado_Incidencia_IDCom);
            ViewBag.Id_Incidencia = new SelectList(db.tbIncidencia, "Id", "primer_nombre", tbIncidencia_Comentarios.Id_Incidencia);
            return View(tbIncidencia_Comentarios);
        }

        // POST: tbIncidencia_Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ICom,Id_Incidencia,Comentarios,Estado_Incidencia_IDCom")] tbIncidencia_Comentarios tbIncidencia_Comentarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbIncidencia_Comentarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_Incidencia_IDCom = new SelectList(db.tbEstado_Incidencia, "Id_EstdIncidencia", "EstdDescripcion", tbIncidencia_Comentarios.Estado_Incidencia_IDCom);
            ViewBag.Id_Incidencia = new SelectList(db.tbIncidencia, "Id", "primer_nombre", tbIncidencia_Comentarios.Id_Incidencia);
            return View(tbIncidencia_Comentarios);
        }

        // GET: tbIncidencia_Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIncidencia_Comentarios tbIncidencia_Comentarios = db.tbIncidencia_Comentarios.Find(id);
            if (tbIncidencia_Comentarios == null)
            {
                return HttpNotFound();
            }
            return View(tbIncidencia_Comentarios);
        }

        // POST: tbIncidencia_Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbIncidencia_Comentarios tbIncidencia_Comentarios = db.tbIncidencia_Comentarios.Find(id);
            db.tbIncidencia_Comentarios.Remove(tbIncidencia_Comentarios);
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
