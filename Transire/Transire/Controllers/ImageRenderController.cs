using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transire.Models;

namespace Transire.Controllers
{
    public class ImageRenderController : Controller
    {
        // GET: ImageRender
        public ActionResult Mostrar(int id)
        {
            using (Context db = new Context())
            {
                var imagem = db.Produtos.Find(id);
                return File(imagem.Foto, imagem.ImagemTipo);
            }
        }
    }
}