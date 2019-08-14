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
    public class MovimentacoesController : Controller
    {
        private BDLIVRARIAEntities db = new BDLIVRARIAEntities();

        // GET: Movimentacoes
        public ActionResult Index()
        {
            var movimentacao = db.MOVIMENTACAO.Include(m => m.DISTRIBUIDORAS).Include(m => m.FUNCIONARIOS).Include(m => m.LIVROS);
            return View(movimentacao.ToList());
        }

        // GET: Movimentacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMENTACAO movimentacao = db.MOVIMENTACAO.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacao);
        }

        // GET: Movimentacoes/Create
        public ActionResult Create()
        {
            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA");
            ViewBag.IDFUNCIONARIO = new SelectList(db.FUNCIONARIOS, "IDFUNCIONARIOS", "NOME");
            ViewBag.IDLIVRO = new SelectList(db.LIVROS, "IDLIVRO", "TITULO");
            return View();
        }

        // POST: Movimentacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMOVIMENTACAO,QUANTIDADEPRODUTO,OPERACAO,DATA,IDDISTRIBUIDORA,IDLIVRO,IDFUNCIONARIO")] MOVIMENTACAO movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.MOVIMENTACAO.Add(movimentacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA", movimentacao.IDDISTRIBUIDORA);
            ViewBag.IDFUNCIONARIO = new SelectList(db.FUNCIONARIOS, "IDFUNCIONARIOS", "NOME", movimentacao.IDFUNCIONARIO);
            ViewBag.IDLIVRO = new SelectList(db.LIVROS, "IDLIVRO", "TITULO", movimentacao.IDLIVRO);
            return View(movimentacao);
        }

        // GET: Movimentacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMENTACAO movimentacao = db.MOVIMENTACAO.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA", movimentacao.IDDISTRIBUIDORA);
            ViewBag.IDFUNCIONARIO = new SelectList(db.FUNCIONARIOS, "IDFUNCIONARIOS", "NOME", movimentacao.IDFUNCIONARIO);
            ViewBag.IDLIVRO = new SelectList(db.LIVROS, "IDLIVRO", "TITULO", movimentacao.IDLIVRO);
            return View(movimentacao);
        }

        // POST: Movimentacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMOVIMENTACAO,QUANTIDADEPRODUTO,OPERACAO,DATA,IDDISTRIBUIDORA,IDLIVRO,IDFUNCIONARIO")] MOVIMENTACAO movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDISTRIBUIDORA = new SelectList(db.DISTRIBUIDORAS, "IDDISTRIBUIDORA", "NOMEFANTASIA", movimentacao.IDDISTRIBUIDORA);
            ViewBag.IDFUNCIONARIO = new SelectList(db.FUNCIONARIOS, "IDFUNCIONARIOS", "NOME", movimentacao.IDFUNCIONARIO);
            ViewBag.IDLIVRO = new SelectList(db.LIVROS, "IDLIVRO", "TITULO", movimentacao.IDLIVRO);
            return View(movimentacao);
        }

        // GET: Movimentacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMENTACAO movimentacao = db.MOVIMENTACAO.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacao);
        }

        // POST: Movimentacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVIMENTACAO movimentacao = db.MOVIMENTACAO.Find(id);
            db.MOVIMENTACAO.Remove(movimentacao);
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
