using ArthurFrederico.SIGA.Model.DAO;
using ArthurFrederico.SIGA.Web.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace ArthurFrederico.SIGA.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UsuarioModelDAO usuarioHandler = new UsuarioModelDAO();

                var user = usuarioHandler.Find(login.Nick);
                if (user != null)
                {
                    var encryptor = SHA512.Create();
                    var pass = Encoding.UTF8.GetString(encryptor.ComputeHash(Encoding.UTF8.GetBytes(login.Senha + user.Cpf)));
                    if (user.HashSenha == pass)
                    {
                        FormsAuthentication.SetAuthCookie(user.Nome, false);

                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return Redirect("/");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ModelError", "Usuário e senha não conferem!");
                    }
                }
                else
                {
                    ModelState.AddModelError("ModelError", "Usuário e senha não conferem!");
                }
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }
    }
}