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
            return View(categorias.OrderBy(
                c => c.Nome));
            /* OBS.: 0poderia ser uma ViewResult ao inves de 
             * ActionResult devido o retorno ser de uma View*/
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

        public ActionResult Edit(long id)
        {
            return View(categorias.Where(
                m => m.CategoriaID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(
                c => c.CategoriaID == categoria.CategoriaID).First());

            /* Uma maneira alternativa para alterar um item da lista, sem ter de remover e inseri-lo novamente, 
             * é fazer uso da implementação. Aqui o	List é manipulado como um array	e, por meio	do método 
             * IndexOf(), sua posição é	recuperada,	com	base na instrução LINQ 
             * Where(c => c.CategoriaId == categoria.CategoriaId).First())
             * veja o exemplo abaixo:
             */
            /*categorias[categorias.IndexOf(categorias.Where(
                c => c.CategoriaID == categoria.CategoriaID).First())] = categoria;*/


            categorias.Add(categoria);            

            return RedirectToAction("Index");
            //posso passar um caminho mais específico return RedirectToAction("views/blabla/parangole/Index");
        }

        public ActionResult Details(long id)
        {
            return View(categorias.Where(
                m => m.CategoriaID == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(categorias.Where(
                m => m.CategoriaID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(
                c => c.CategoriaID== categoria.CategoriaID).First());

            return RedirectToAction("Index");
        }

    }
}