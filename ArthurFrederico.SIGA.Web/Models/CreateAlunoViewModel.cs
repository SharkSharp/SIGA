using ArthurFrederico.SIGA.Model;

namespace ArthurFrederico.SIGA.Web.Models
{
    public class CreateAlunoViewModel
    {
        public AlunoModel Aluno { get; set; }

        public TutorModel Tutor1 { get; set; }

        public TutorModel Tutor2 { get; set; }
    }
}