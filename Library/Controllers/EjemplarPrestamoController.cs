using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library;

namespace Library.Controllers
{
    public class EjemplarPrestamoController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        // GET: EjemplarPrestamo
        public ActionResult Index()
        {
            var ejemplarPrestamoes = db.EjemplarPrestamoes.Include(e => e.Ejemplar).Include(e => e.Prestamo);
            return View(ejemplarPrestamoes.ToList());
        }

        // GET: EjemplarPrestamo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EjemplarPrestamo ejemplarPrestamo = db.EjemplarPrestamoes.Find(id);
            if (ejemplarPrestamo == null)
            {
                return HttpNotFound();
            }
            return View(ejemplarPrestamo);
        }

        // GET: EjemplarPrestamo/Create
        public ActionResult Create()
        {
            ViewBag.ejemplar_id = new SelectList(db.Ejemplars, "ejemplar_id", "ejemplar_numero");
            ViewBag.prestamo_id = new SelectList(db.Prestamoes, "prestamo_id", "prestamo_estado_devolucion");
            return View();
        }

        // POST: EjemplarPrestamo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eje_prestamo_id,ejemplar_id,prestamo_id")] EjemplarPrestamo ejemplarPrestamo)
        {
            if (ModelState.IsValid)
            {
                db.EjemplarPrestamoes.Add(ejemplarPrestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ejemplar_id = new SelectList(db.Ejemplars, "ejemplar_id", "ejemplar_numero", ejemplarPrestamo.ejemplar_id);
            ViewBag.prestamo_id = new SelectList(db.Prestamoes, "prestamo_id", "prestamo_estado_devolucion", ejemplarPrestamo.prestamo_id);
            return View(ejemplarPrestamo);
        }

        // GET: EjemplarPrestamo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EjemplarPrestamo ejemplarPrestamo = db.EjemplarPrestamoes.Find(id);
            if (ejemplarPrestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ejemplar_id = new SelectList(db.Ejemplars, "ejemplar_id", "ejemplar_numero", ejemplarPrestamo.ejemplar_id);
            ViewBag.prestamo_id = new SelectList(db.Prestamoes, "prestamo_id", "prestamo_estado_devolucion", ejemplarPrestamo.prestamo_id);
            return View(ejemplarPrestamo);
        }

        // POST: EjemplarPrestamo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eje_prestamo_id,ejemplar_id,prestamo_id")] EjemplarPrestamo ejemplarPrestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejemplarPrestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ejemplar_id = new SelectList(db.Ejemplars, "ejemplar_id", "ejemplar_numero", ejemplarPrestamo.ejemplar_id);
            ViewBag.prestamo_id = new SelectList(db.Prestamoes, "prestamo_id", "prestamo_estado_devolucion", ejemplarPrestamo.prestamo_id);
            return View(ejemplarPrestamo);
        }

        // GET: EjemplarPrestamo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EjemplarPrestamo ejemplarPrestamo = db.EjemplarPrestamoes.Find(id);
            if (ejemplarPrestamo == null)
            {
                return HttpNotFound();
            }
            return View(ejemplarPrestamo);
        }

        // POST: EjemplarPrestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EjemplarPrestamo ejemplarPrestamo = db.EjemplarPrestamoes.Find(id);
            db.EjemplarPrestamoes.Remove(ejemplarPrestamo);
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
