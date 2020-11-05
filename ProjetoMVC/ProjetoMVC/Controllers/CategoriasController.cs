using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaID = 1,
                Nome = "Notebooks"
            },
            new Categoria()
            {
                CategoriaID = 2,
                Nome = "Monitores"
            },
            new Categoria()
            {
                CategoriaID = 3,
                Nome = "Impressoras"
            },
            new Categoria
            {
                CategoriaID = 4,
                Nome = "Mouses"
            },
            new Categoria()
            {
                CategoriaID = 5,
                Nome = "Desktops"
            }
        };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);//poderia ser uma ViewResult ao inves de ActionResult devido o retorno ser de uma View
        }

        //	GET:	Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaID = categorias.Select(m => m.CategoriaID).Max() + 1;
            return RedirectToAction("Index");
        }
    }
}