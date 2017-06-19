using ArthurFrederico.SIGA.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace ArthurFrederico.SIGA.Model.DAO
{
    public class TutorModelDAO
    {
        SIGAContext context = new SIGAContext();

        public void Add(TutorModel tutor)
        {
            context.Tutor.Add(tutor);
            context.SaveChanges();
        }

        public TutorModel Find(string cpf)
        {
            return context.Tutor.FirstOrDefault(x => x.Cpf == cpf);
        }

        public IEnumerable<TutorModel> GetAll()
        {
            return context.Tutor;
        }

        public int Count
        {
            get
            {
                return context.Tutor.Count();
            }
        }
    }
}
