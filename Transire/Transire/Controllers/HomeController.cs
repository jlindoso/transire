using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;
using Transire.Models;

namespace Transire.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();
        public HomeController()
        {
            ViewBag.CategoriasMenu = db.Categorias.ToList();
        }

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var produtoes = db.Produtos.Include(p => p.Categoria);
            ViewBag.Produtos = await produtoes.ToListAsync();

            return View();
        }
        public ActionResult Produtos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.categoria = db.Categorias.Find(id);
            ViewBag.Produtos = db.Produtos.Where(x => x.CategoriaId == id).ToList();
            return View();
        }
        




    }
}