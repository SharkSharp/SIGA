using ArthurFrederico.SIGA.Model;
using ArthurFrederico.SIGA.Model.DAO;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace ArthurFrederico.SIGA.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Cidades = cidadeHandler.GetAll();

            return View(new UsuarioModel());
        }

        [HttpPost]
        public ActionResult Create(UsuarioModel usuario)
        {
            CidadeModelDAO cidadeHandler = new CidadeModelDAO();

            ViewBag.Cidades = cidadeHandler.GetAll();

            if (ModelState.IsValid)
            {
                UsuarioModelDAO usuarioHandler = new UsuarioModelDAO();

                var encryptor = SHA512.Create();
                usuario.HashSenha = Encoding.UTF8.GetString(encryptor.ComputeHash(Encoding.UTF8.GetBytes(usuario.HashSenha + usuario.Cpf)));
                usuario.DataCadastro = DateTime.Now;
                try
                {
                    usuarioHandler.Add(usuario);

                    return RedirectToAction("Login", "Autenticacao");
                }
                catch (Exception e)
                {

                    ModelState.AddModelError("ModelError", "Erro ao efetuar o cadastro, seu cadastro pode já ter sido efetuado ou algum dado pode ter sido inserido incorretamente.");
                }
            }

            return View(usuario);
        }
    }
}