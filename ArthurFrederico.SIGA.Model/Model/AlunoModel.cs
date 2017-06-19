using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArthurFrederico.SIGA.Model
{
    [Table("Aluno")]
    public class AlunoModel
    {
        [Key]
        [Required]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o Nome!")]
        [Display(Name = "Nome:")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o RG!")]
        [Display(Name = "RG:")]
        [DisplayFormat(DataFormatString = "{0:##.###.###-#}")]
        [Index(IsUnique = true)]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "RG deve conter exatamente 9 caracteres.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Insira o CPF!")]
        [Display(Name = "CPF:")]
        [DisplayFormat(DataFormatString = "{0:###.###.###-##}")]
        [Index(IsUnique = true)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter exatamente 11 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Insira a Data de Nascimento!")]
        [Display(Name = "Data de Nascimento:")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Tutor Principal")]
        [ForeignKey("Tutor1")]
        public int Tutor1Id { get; set; }

        public TutorModel Tutor1 { get; set; }

        [Display(Name = "Tutor Secundário")]
        [ForeignKey("Tutor2")]
        public int Tutor2Id { get; set; }

        public TutorModel Tutor2 { get; set; }

        [Required(ErrorMessage = "Insira o Endereço Completo!")]
        [Display(Name = "Endereço Completo:")]
        [StringLength(250)]
        public string EnderecoCompleto { get; set; }

        [Required(ErrorMessage = "Insira a Matrícula!")]
        [Display(Name = "Matrícula:")]
        [Index(IsUnique = true)]
        [StringLength(10)]
        public string Matricula { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        [Display(Name = "Sexo:")]
        public bool Sexo { get; set; }

        [Required(ErrorMessage = "Insira o Telefone Principal!")]
        [Display(Name = "Telefone Principal:")]
        [Index(IsUnique = true)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone deve conter 11 caracteres.")]
        public string Telefone1 { get; set; }

        [Required(ErrorMessage = "Insira o Telefone Secundário!")]
        [Display(Name = "Telefone Secundário:")]
        [Index(IsUnique = true)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone deve conter 11 caracteres.")]
        public string Telefone2 { get; set; }

        [Display(Name = "Data de Cadastro:")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Insira a Cidade!")]
        [Display(Name = "Cidade:")]
        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        public virtual CidadeModel Cidade { get; set; }

        [Required(ErrorMessage = "Insira o Email!")]
        [Display(Name = "Email:")]
        [Index(IsUnique = true)]
        [MaxLength(50), MinLength(5)]
        public string Email { get; set; }

        public DateTime DataUltimaModificacao { get; set; }

        public string UsuarioModificacao { get; set; }

    }
}
