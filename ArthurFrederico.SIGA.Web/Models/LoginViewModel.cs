using System.ComponentModel.DataAnnotations;

namespace ArthurFrederico.SIGA.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira o Nome!")]
        [Display(Name = "Nome:")]
        public string Nick { get; set; }

        [Required(ErrorMessage = "Insira a Senha!")]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }
    }
}