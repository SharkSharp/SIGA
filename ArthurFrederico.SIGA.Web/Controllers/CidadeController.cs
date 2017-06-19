using ArthurFrederico.SIGA.Model;
using ArthurFrederico.SIGA.Model.DAO;
using ArthurFrederico.SIGA.Web.Models;
using System;
using System.Web.Mvc;

namespace ArthurFrederico.SIGA.Web.Controllers
{
    [Authorize]
    public class CidadeController : Controller
    {
        public const int ItensPorPagina = 5;

        [Route("Cidade/Pagina{pagina}")]
        [Route("Cidade/List/Pagina{pagina}")]
        public ActionResult List(int pagina = 1, string nome = "", string estado = "", string cep = "")
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Paginacao = new Paginacao()
            {
                PaginaAtual = pagina,
                ItensPorPagina = ItensPorPagina,
                TotalItens = cidadeHandler.SearchCount(nome, estado, cep)
            };

            return View(cidadeHandler.GetCidadeList(ItensPorPagina, pagina, nome, estado, cep));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CidadeModel cidade)
        {
            if (ModelState.IsValid)
            {
                CidadeModelDAO cidadeHandler = new CidadeModelDAO();
                try
                {
                    cidadeHandler.Add(cidade);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ModelError", "Erro ao efetuar o cadastro, seu cadastro pode já ter sido efetuado ou algum dado pode ter sido inserido incorretamente.");
                }
                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            return View(cidadeHandler.GetCidade(id));
        }

        [HttpPost]
        public ActionResult Edit(CidadeModel cidade)
        {
            if (ModelState.IsValid)
            {
                CidadeModelDAO cidadeHandler = new CidadeModelDAO();
                try
                {
                    cidadeHandler.Update(cidade);
                    return RedirectToAction("List", new { pagina = 1 });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ModelError", "Erro ao efetuar o update, algum dado pode ter sido inserido incorretamente.");
                }
            }

            return View(cidade);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            try
            {
                cidadeHandler.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
            
            return RedirectToAction("List");
        }
    }
}