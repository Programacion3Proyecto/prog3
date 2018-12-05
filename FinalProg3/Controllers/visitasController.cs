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
    public class visitasController : Controller
    {
        private consultorioEntities8 db = new consultorioEntities8();

        // GET: visitas
        public ActionResult Index()
        {
            return View(db.visitas.ToList());
        }

        // GET: visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visitas visitas = db.visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
        }

        // GET: visitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FechaRealizada,Motivo,nombreMedico,nombrePaciente,Comentario,RecetaMedicamento,FechaProxVisita")] visitas visitas)
        {
            if (ModelState.IsValid)
            {
                db.visitas.Add(visitas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitas);
        }

        // GET: visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visitas visitas = db.visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
        }

        // POST: visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FechaRealizada,Motivo,nombreMedico,nombrePaciente,Comentario,RecetaMedicamento,FechaProxVisita")] visitas visitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitas);
        }

        // GET: visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visitas visitas = db.visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
        }

        // POST: visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visitas visitas = db.visitas.Find(id);
            db.visitas.Remove(visitas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Receta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visitas visitas = db.visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
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
