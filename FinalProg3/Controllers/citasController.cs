using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProg3.Models;

namespace FinalProg3.Controllers
{
    public class citasController : Controller
    {
        private consultorioEntities6 db = new consultorioEntities6();

        // GET: citas
        public ActionResult Index()
        {
            return View(db.citas.ToList());
        }

        // GET: citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citas citas = db.citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // GET: citas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fechaOtorgada,duracion,fechaRealizada,nombreMedico,nombrePaciente,nombreAsistenteRealizada")] citas citas)
        {
            if (ModelState.IsValid)
            {
                db.citas.Add(citas);
                db.SaveChanges();
                return RedirectToAction("Index","facturas");
            }

            return View(citas);
        }

        // GET: citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citas citas = db.citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fechaOtorgada,duracion,fechaRealizada,nombreMedico1,nombrePaciente,nombreAsistenteRealizada")] citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citas);
        }

        // GET: citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citas citas = db.citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            citas citas = db.citas.Find(id);
            db.citas.Remove(citas);
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
