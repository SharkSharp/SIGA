using ArthurFrederico.SIGA.Model;
using ArthurFrederico.SIGA.Model.DAO;
using ArthurFrederico.SIGA.Web.Models;
using System;
using System.Web.Mvc;

namespace ArthurFrederico.SIGA.Web.Controllers
{
    [Authorize]
    public class AlunoController : Controller
    {
        public const int ItensPorPagina = 5;

        [Route("Aluno/Pagina{pagina}")]
        [Route("Aluno/List/Pagina{pagina}")]
        public ActionResult List(int pagina = 1, int id = -1, string nome = "", string cpf = "", string dataNascimento = "", string dataCadastro = "")
        {
            AlunoModelDAO alunoHandler = new AlunoModelDAO();

            ViewBag.Paginacao = new Paginacao()
            {
                PaginaAtual = pagina,
                ItensPorPagina = ItensPorPagina,
                TotalItens = alunoHandler.SearchCount(id, nome, cpf, dataNascimento, dataCadastro)
            };

            return View(alunoHandler.GetList(ItensPorPagina, pagina, id, nome, cpf, dataNascimento, dataCadastro));
        }

        [HttpGet]
        public ActionResult Create()
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Cidades = cidadeHandler.GetAll();

            return View(new CreateAlunoViewModel() { Aluno = new AlunoModel(), Tutor1 = new TutorModel(), Tutor2 = new TutorModel() });
        }

        [HttpPost]
        public ActionResult Create(CreateAlunoViewModel viewModel)
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Cidades = cidadeHandler.GetAll();

            if (ModelState.IsValid)
            {
                TutorModelDAO tutorHandler = new TutorModelDAO();
                AlunoModelDAO alunoHandler = new AlunoModelDAO();

                var tutor1 = tutorHandler.Find(viewModel.Tutor1.Cpf);
                if (tutor1 == null)
                {
                    tutor1 = viewModel.Tutor1;
                    tutor1.DataCadastro = DateTime.Now;

                    try
                    {
                        tutorHandler.Add(viewModel.Tutor1);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("ModelError", "Erro ao efetuar o cadastro, algum dado pode ter sido inserido incorretamente.");
                        return View(viewModel);
                    }
                }

                var tutor2 = tutorHandler.Find(viewModel.Tutor2.Cpf);
                if (tutor2 == null)
                {
                    tutor2 = viewModel.Tutor2;
                    tutor2.DataCadastro = DateTime.Now;

                    try
                    {
                        tutorHandler.Add(viewModel.Tutor2);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("ModelError", "Erro ao efetuar o cadastro, algum dado pode ter sido inserido incorretamente.");
                        return View(viewModel);
                    }
                }

                viewModel.Aluno.Tutor1Id = tutor1.Id;
                viewModel.Aluno.Tutor2Id = tutor2.Id;

                DateTime now = DateTime.Today;
                int idade = now.Year - viewModel.Aluno.DataNascimento.Year;
                if (now < viewModel.Aluno.DataNascimento.AddYears(idade)) idade--;

                viewModel.Aluno.Idade = idade;
                viewModel.Aluno.DataCadastro = DateTime.Now;
                viewModel.Aluno.DataUltimaModificacao = DateTime.Now;
                viewModel.Aluno.UsuarioModificacao = User.Identity.Name;

                try
                {
                    alunoHandler.Add(viewModel.Aluno);
                    return RedirectToAction("List");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ModelError", "Erro ao efetuar o cadastro, algum dado pode ter sido inserido incorretamente.");
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            AlunoModelDAO alunoHandler = new AlunoModelDAO();
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Cidades = cidadeHandler.GetAll();

            return View(alunoHandler.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(AlunoModel aluno)
        {
            AlunoModelDAO alunoHandler = new AlunoModelDAO();
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Cidades = cidadeHandler.GetAll();

            if (ModelState.IsValid)
            {
                aluno.DataUltimaModificacao = DateTime.Now;
                aluno.UsuarioModificacao = User.Identity.Name;

                try
                {
                    alunoHandler.Update(aluno);
                    return RedirectToAction("List");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ModelError", "Erro ao efetuar a edição, algum dado pode ter sido inserido incorretamente.");
                }

            }

            return View(aluno);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            AlunoModelDAO alunoHandler = new AlunoModelDAO();

            try
            {
                alunoHandler.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("List");
        }
    }
}