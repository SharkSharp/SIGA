using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArthurFrederico.SIGA.Model
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        [Required]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o Nome!")]
        [Display(Name = "Nome:")]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o CPF!")]
        [Display(Name = "CPF:")]
        [DisplayFormat(DataFormatString = "{0:###.###.###-##}")]
        [Index(IsUnique = true)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter exatamente 11 caracteres.")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Sexo:")]
        public bool Sexo { get; set; }

        [Required(ErrorMessage = "Insira o Telefone!")]
        [Display(Name = "Telefone:")]
        [Index(IsUnique = true)]
        [StringLength(11)]
        public string Telefone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Insira a Cidade!")]
        [Display(Name = "Cidade:")]
        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        public virtual CidadeModel Cidade { get; set; }

        [Required(ErrorMessage = "Insira o Email!")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira a Senha!")]
        [Display(Name = "Senha:")]
        public string HashSenha { get; set; }
    }
}
