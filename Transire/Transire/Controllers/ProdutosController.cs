using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transire.Models;
using System.IO;

namespace Transire.Controllers
{
    public class ProdutosController : Controller
    {
        private Context db = new Context();
        public ProdutosController()
        {
            ViewBag.Categorias = db.Categorias.ToList();
        }

        // GET: Produtos
        public async Task<ActionResult> Index()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(await produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Descricao,CategoriaId,Preco,Data")] Produto produto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {

                    var Imagem = new Produto
                    {
                        ImagemTipo = upload.ContentType
                    };

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        Imagem.Foto = reader.ReadBytes(upload.ContentLength);
                    }
                    produto.Foto = Imagem.Foto;
                    produto.ImagemTipo = Imagem.ImagemTipo;

                }
                db.Produtos.Add(produto);
                await db.SaveChangesAsync();
                TempData["msg"] = "Produto Inserido com Sucesso!";
                return RedirectToAction("Index");
            }


            /*
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }*/

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }
        // GET: Produtos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Descricao,CategoriaId,Preco, ImagemTipo, Foto")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(produto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["msg"] = "Produto Editado com Sucesso!";
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Produto produto = await db.Produtos.FindAsync(id);
            db.Produtos.Remove(produto);
            await db.SaveChangesAsync();
            TempData["msg"] = "Produto Removido com Sucesso!";
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
