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
    public class EjemplarController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        // GET: Ejemplar
        public ActionResult Index()
        {
            var ejemplars = db.Ejemplars.Include(e => e.Libro);
            return View(ejemplars.ToList());
        }

        // GET: Ejemplar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // GET: Ejemplar/Create
        public ActionResult Create()
        {
            ViewBag.libro_id = new SelectList(db.Libroes, "libro_id", "libro_nombre");
            return View();
        }

        // POST: Ejemplar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ejemplar_id,ejemplar_numero,ejemplar_estado,libro_id")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                db.Ejemplars.Add(ejemplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.libro_id = new SelectList(db.Libroes, "libro_id", "libro_nombre", ejemplar.libro_id);
            return View(ejemplar);
        }

        // GET: Ejemplar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            ViewBag.libro_id = new SelectList(db.Libroes, "libro_id", "libro_nombre", ejemplar.libro_id);
            return View(ejemplar);
        }

        // POST: Ejemplar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ejemplar_id,ejemplar_numero,ejemplar_estado,libro_id")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejemplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.libro_id = new SelectList(db.Libroes, "libro_id", "libro_nombre", ejemplar.libro_id);
            return View(ejemplar);
        }

        // GET: Ejemplar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // POST: Ejemplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            db.Ejemplars.Remove(ejemplar);
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
