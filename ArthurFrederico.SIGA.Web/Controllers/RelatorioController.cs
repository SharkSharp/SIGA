using ArthurFrederico.SIGA.Model;
using ArthurFrederico.SIGA.Model.DAO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArthurFrederico.SIGA.Web.Controllers
{
    [Authorize]
    public class RelatorioController : Controller
    {
        [Route("Relatorio/AlunosPorCidade")]
        [Route("Relatorio/AlunosPorCidade/Cidade{idCidade}")]
        public ActionResult AlunosPorCidade(int idCidade = -1)
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Cidades = cidadeHandler.GetAll();

            if (idCidade == -1)
            {
                return View(new List<AlunoModel>());
            }
            else
            {
                AlunoModelDAO alunoHandler = new AlunoModelDAO();
                return View(alunoHandler.AlunosPorCidade(idCidade));
            }
        }
    }
}