using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Modelo.Cadastros;
using System.Net;
using Servico.Cadastros;
using Servico.Tabelas;

namespace ProjetoMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

       // private EFContext context = new EFContext();

        // GET: Produtos
        /*public ActionResult Index()
        {
            return View(context.Produtos.OrderBy(c => c.Nome));
        }*/

        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());

            /*var produtos = context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
            return View(produtos);*/
        }

        //	GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).
                Include(c => c.Categoria).
                Include(f => f.Fabricante).First();

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);*/

            return ObterVisaoProdutoPorId(id);
        }


        // GET: Produtos/Create
        public ActionResult Create()
        {
            /*ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome");
            return View();*/

            PopularViewBag();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)/*FormCollection collection*/
        {
            /*try
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }*/
            return GravarProduto(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome", produto.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome", produto.FabricanteId);

            return View(produto);*/

            PopularViewBag(produtoServico.ObterProdutoPorId((long)id));
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            /* try
              {
                  if (ModelState.IsValid)
                  {
                      context.Entry(produto).State = EntityState.Modified;
                      context.SaveChanges();
                      return RedirectToAction("Index");
                  }
                  return View(produto);
              }
              catch
              {
                  return View(produto);
              }*/

            return GravarProduto(produto);

        }

        //	GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).
                Include(c => c.Categoria).
                Include(f => f.Fabricante).First();

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);*/

            return ObterVisaoProdutoPorId(id);
        }


        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                /*Produto produto = context.Produtos.Find(id);
                context.Produtos.Remove(produto);
                context.SaveChanges();
                TempData["Message"] = "Produto	" + produto.Nome.ToUpper() + "	foi	removido";
                return RedirectToAction("Index");*/

                Produto produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto	" + produto.Nome.ToUpper()
                                + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
 
            Produto produto = produtoServico.ObterProdutoPorId((long)id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }


        /*ViewBag é apenas um invólucro dinâmico em torno de ViewData, 
         * sendo uma propriedade dinâmica baseada no recurso dynamic da plataforma .NET. 
         * Com ViewBag você não precisa escrever a palavra-chave dynamic, ele usa a 
         * palavra-chave dynamic internamente.*/
        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.
                    ObterCategoriaClassificadasPorNome(),
                    "CategoriaId", 
                    "Nome");

                ViewBag.FabricanteId = new SelectList(fabricanteServico.
                    ObterFabricantesClassificadosPorNome(),
                    "FabricanteId",
                    "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.
                    ObterCategoriaClassificadasPorNome(),
                    "CategoriaId",
                    "Nome",
                    produto.CategoriaId);

                ViewBag.FabricanteId = new SelectList(fabricanteServico.
                    ObterFabricantesClassificadosPorNome(),
                    "FabricanteId",
                    "Nome",
                    produto.FabricanteId);
            }
        }

        /*O ModeState é uma propriedade da classe Controller e 
         * pode ser acessada a partir das classe que herdam de System.*/
        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }

    }
}
