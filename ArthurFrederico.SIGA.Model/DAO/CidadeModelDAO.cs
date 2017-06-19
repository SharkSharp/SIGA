using System.Collections.Generic;
using System.Linq;

namespace ArthurFrederico.SIGA.Model.DAO
{
    public class CidadeModelDAO
    {
        SIGAContext context = new SIGAContext();

        public void Add(CidadeModel cidade)
        {
            context.Cidade.Add(cidade);
            context.SaveChanges();
        }

        public IEnumerable<CidadeModel> GetCidadeList(int qtd, int pagina, string nome, string estado, string cep)
        {
            return context.Cidade.Where(x => x.Nome.Contains(nome) && x.Estado.Contains(estado) && x.Cep.Contains(cep))
                .OrderBy(x => x.Nome)
                .Skip((pagina - 1) * qtd)
                .Take(qtd);
        }

        public CidadeModel GetCidade(int id)
        {
            return context.Cidade.FirstOrDefault(x => x.Id == id);
        }

        public void Update(CidadeModel cidade)
        {
            var updated = GetCidade(cidade.Id);
            updated.Nome = cidade.Nome;
            updated.Estado = cidade.Estado;
            updated.Cep = cidade.Cep;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Cidade.Remove(context.Cidade.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public IEnumerable<CidadeModel> GetAll()
        {
            return context.Cidade;
        }

        public int Count
        {
            get
            {
                return context.Cidade.Count();
            }
        }

        public int SearchCount(string nome, string estado, string cep)
        {
            return context.Cidade.Where(x => x.Nome.Contains(nome) && x.Estado.Contains(estado) && x.Cep.Contains(cep)).Count();
        }
    }
}
