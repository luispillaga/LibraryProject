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
    public class PrestamoController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        // GET: Prestamo
        public ActionResult Index()
        {
            var prestamoes = db.Prestamoes.Include(p => p.Cliente);
            return View(prestamoes.ToList());
        }

        // GET: Prestamo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamo/Create
        public ActionResult Create()
        {
            ViewBag.cliente_id = new SelectList(db.Clientes, "cliente_id", "cliente_name");
            return View();
        }

        // POST: Prestamo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prestamo_id,prestamo_fecha_desde,prestamo_fecha_hasta,prestamo_fecha_entrega,prestamo_estado_devolucion,prestamo_estado,cliente_id")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamoes.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente_id = new SelectList(db.Clientes, "cliente_id", "cliente_name", prestamo.cliente_id);
            return View(prestamo);
        }

        // GET: Prestamo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente_id = new SelectList(db.Clientes, "cliente_id", "cliente_name", prestamo.cliente_id);
            return View(prestamo);
        }

        // POST: Prestamo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prestamo_id,prestamo_fecha_desde,prestamo_fecha_hasta,prestamo_fecha_entrega,prestamo_estado_devolucion,prestamo_estado,cliente_id")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente_id = new SelectList(db.Clientes, "cliente_id", "cliente_name", prestamo.cliente_id);
            return View(prestamo);
        }

        // GET: Prestamo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamoes.Find(id);
            db.Prestamoes.Remove(prestamo);
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
