using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Livraria.Sistema.Models;

namespace Livraria.Sistema.Controllers
{
    public class DistribuidorasController : Controller
    {
        private BDLIVRARIAEntities db = new BDLIVRARIAEntities();

        // GET: Distribuidoras
        public ActionResult Index()
        {
            return View(db.DISTRIBUIDORAS.ToList());
        }

        // GET: Distribuidoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRIBUIDORAS distribuidoras = db.DISTRIBUIDORAS.Find(id);
            if (distribuidoras == null)
            {
                return HttpNotFound();
            }
            return View(distribuidoras);
        }

        // GET: Distribuidoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distribuidoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDISTRIBUIDORA,CNPJ,NOMEFANTASIA,EMAIL,TELEFONE,CIDADE,ESTADO")] DISTRIBUIDORAS distribuidoras)
        {
            if (ModelState.IsValid && (ValidacaoCnpj.IsCnpj(distribuidoras.CNPJ) == true))
            {
                db.DISTRIBUIDORAS.Add(distribuidoras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distribuidoras);
        }

        // GET: Distribuidoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRIBUIDORAS distribuidoras = db.DISTRIBUIDORAS.Find(id);
            if (distribuidoras == null)
            {
                return HttpNotFound();
            }
            return View(distribuidoras);
        }

        // POST: Distribuidoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDISTRIBUIDORA,CNPJ,NOMEFANTASIA,EMAIL,TELEFONE,CIDADE,ESTADO")] DISTRIBUIDORAS distribuidoras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribuidoras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribuidoras);
        }

        // GET: Distribuidoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRIBUIDORAS distribuidoras = db.DISTRIBUIDORAS.Find(id);
            if (distribuidoras == null)
            {
                return HttpNotFound();
            }
            return View(distribuidoras);
        }

        // POST: Distribuidoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISTRIBUIDORAS distribuidoras = db.DISTRIBUIDORAS.Find(id);
            db.DISTRIBUIDORAS.Remove(distribuidoras);
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
