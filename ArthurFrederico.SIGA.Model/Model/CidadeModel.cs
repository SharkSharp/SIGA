using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArthurFrederico.SIGA.Model
{
    [Table("Cidade")]
    public class CidadeModel
    {
        [Key]
        [Required]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o Nome!")]
        [Display(Name = "Nome:")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o Estado!")]
        [Display(Name = "Estado:")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Estado deve sempre ter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Insira o Cep!")]
        [Display(Name = "Cep:")]
        [Index(IsUnique = true)]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Cep deve sempre ter 8 caracteres.")]
        public string Cep { get; set; }
    }
}
