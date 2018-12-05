﻿using System;
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
    public class LibroController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        // GET: Libro
        public ActionResult Index()
        {
            var libroes = db.Libroes.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.Genero).Include(l => l.Proveedor);
            return View(libroes.ToList());
        }

        // GET: Libro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libroes.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            ViewBag.autor_id = new SelectList(db.Autors, "autor_id", "autor_nombre");
            ViewBag.editorial_id = new SelectList(db.Editorials, "editorial_id", "editorial_nombre");
            ViewBag.genero_id = new SelectList(db.Generoes, "genero_id", "genero_nombre");
            ViewBag.proveedor_id = new SelectList(db.Proveedors, "proveedor_id", "proveedor_nombre");
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "libro_id,libro_nombre,libro_fecha,libro_precio,proveedor_id,editorial_id,autor_id,genero_id")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libroes.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.autor_id = new SelectList(db.Autors, "autor_id", "autor_nombre", libro.autor_id);
            ViewBag.editorial_id = new SelectList(db.Editorials, "editorial_id", "editorial_nombre", libro.editorial_id);
            ViewBag.genero_id = new SelectList(db.Generoes, "genero_id", "genero_nombre", libro.genero_id);
            ViewBag.proveedor_id = new SelectList(db.Proveedors, "proveedor_id", "proveedor_nombre", libro.proveedor_id);
            return View(libro);
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libroes.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.autor_id = new SelectList(db.Autors, "autor_id", "autor_nombre", libro.autor_id);
            ViewBag.editorial_id = new SelectList(db.Editorials, "editorial_id", "editorial_nombre", libro.editorial_id);
            ViewBag.genero_id = new SelectList(db.Generoes, "genero_id", "genero_nombre", libro.genero_id);
            ViewBag.proveedor_id = new SelectList(db.Proveedors, "proveedor_id", "proveedor_nombre", libro.proveedor_id);
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "libro_id,libro_nombre,libro_fecha,libro_precio,proveedor_id,editorial_id,autor_id,genero_id")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.autor_id = new SelectList(db.Autors, "autor_id", "autor_nombre", libro.autor_id);
            ViewBag.editorial_id = new SelectList(db.Editorials, "editorial_id", "editorial_nombre", libro.editorial_id);
            ViewBag.genero_id = new SelectList(db.Generoes, "genero_id", "genero_nombre", libro.genero_id);
            ViewBag.proveedor_id = new SelectList(db.Proveedors, "proveedor_id", "proveedor_nombre", libro.proveedor_id);
            return View(libro);
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libroes.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libroes.Find(id);
            db.Libroes.Remove(libro);
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