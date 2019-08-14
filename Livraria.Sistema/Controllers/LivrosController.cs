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
    public class LivrosController : Controller
    {
        private BDLIVRARIAEntities db = new BDLIVRARIAEntities();

        // GET: Livros
        public ActionResult Index()
        {
            var livros = db.LIVROS.Include(l => l.CATEGORIAS).Include(l => l.DISTRIBUIDORAS).Include(l => l.EDITORAS);
            return View(livros.ToList());
        }

        // GET: Livros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVROS livros = db.LIVROS.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIAS, "IDCATEGORIA", "NOME");
            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA");
            ViewBag.IDEDITORA = new SelectList(db.EDITORAS, "IDEDITORA", "NOMEFANTASIA");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLIVRO,EAN13,ISBN,TITULO,AUTOR,EDICAO,ANOEDICAO,FORMATO,NUMEROPAGINAS,ORIGEM,PRECO,IDDISTRIBUIDORA,IDEDITORA,IDCATEGORIA")] LIVROS livros)
        {
            if (ModelState.IsValid)
            {
                db.LIVROS.Add(livros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIAS, "IDCATEGORIA", "NOME", livros.IDCATEGORIA);
            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA", livros.IDDISTRIBUIDORA);
            ViewBag.IDEDITORA = new SelectList(db.EDITORAS, "IDEDITORA", "NOMEFANTASIA", livros.IDEDITORA);
            return View(livros);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVROS livros = db.LIVROS.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIAS, "IDCATEGORIA", "NOME", livros.IDCATEGORIA);
            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA", livros.IDDISTRIBUIDORA);
            ViewBag.IDEDITORA = new SelectList(db.EDITORAS, "IDEDITORA", "NOMEFANTASIA", livros.IDEDITORA);
            return View(livros);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLIVRO,EAN13,ISBN,TITULO,AUTOR,EDICAO,ANOEDICAO,FORMATO,NUMEROPAGINAS,ORIGEM,PRECO,IDDISTRIBUIDORA,IDEDITORA,IDCATEGORIA")] LIVROS livros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIAS, "IDCATEGORIA", "NOME", livros.IDCATEGORIA);
            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA", livros.IDDISTRIBUIDORA);
            ViewBag.IDEDITORA = new SelectList(db.EDITORAS, "IDEDITORA", "NOMEFANTASIA", livros.IDEDITORA);
            return View(livros);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVROS livros = db.LIVROS.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIVROS livros = db.LIVROS.Find(id);
            db.LIVROS.Remove(livros);
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
