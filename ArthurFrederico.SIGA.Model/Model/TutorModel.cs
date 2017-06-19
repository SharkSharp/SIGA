using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArthurFrederico.SIGA.Model
{
    [Table("Tutor")]
    public class TutorModel
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

        [Required]
        [Display(Name = "Sexo:")]
        public bool Sexo { get; set; }

        [Required(ErrorMessage = "Insira a profissão!")]
        [Display(Name = "Profissão:")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "A profissão deve conter entre 3 e 50 caracteres.")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "Insira o Telefone!")]
        [Display(Name = "Telefone:")]
        [Index(IsUnique = true)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone deve conter 11 caracteres.")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
