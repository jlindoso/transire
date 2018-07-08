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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

    }
}