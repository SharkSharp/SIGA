using ArthurFrederico.SIGA.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ArthurFrederico.SIGA.Model.DAO
{
    public class AlunoModelDAO
    {
        SIGAContext context = new SIGAContext();

        public void Add(AlunoModel aluno)
        {
            context.Aluno.Add(aluno);
            context.SaveChanges();
        }

        public IEnumerable<AlunoModel> AlunosPorCidade(int idCidade)
        {
            return context.Aluno.Where(x => x.CidadeId == idCidade)
                .OrderBy(x => x.Nome);
            
        }

        public IEnumerable<AlunoModel> GetList(int qtd, int pagina, int id, string nome, string cpf, string dataNascimento, string dataCadastro)
        {
            if (id != -1)
            {
                return context.Aluno.Where(x=> x.Id == id && x.Nome.Contains(nome) && x.Cpf.Contains(cpf) && x.DataNascimento.ToString().Contains(dataNascimento) && x.DataCadastro.ToString().Contains(dataCadastro))
                    .OrderBy(x => x.Nome)
                    .Skip((pagina - 1) * qtd)
                    .Take(qtd);
            }
            else
            {
                return context.Aluno.Where(x => x.Nome.Contains(nome) && x.Cpf.Contains(cpf) && x.DataNascimento.ToString().Contains(dataNascimento) && x.DataCadastro.ToString().Contains(dataCadastro))
                    .OrderBy(x => x.Nome)
                    .Skip((pagina - 1) * qtd)
                    .Take(qtd);
            }
        }

        public AlunoModel Find(int id)
        {
            return context.Aluno.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            context.Aluno.Remove(context.Aluno.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public void Update(AlunoModel aluno)
        {
            var updated = context.Aluno.FirstOrDefault(x => x.Id == aluno.Id);

            updated.Nome = aluno.Nome;
            updated.Rg = aluno.Rg;
            updated.Cpf = aluno.Cpf;
            updated.EnderecoCompleto = aluno.EnderecoCompleto;
            updated.Matricula = aluno.Matricula;
            updated.Sexo = aluno.Sexo;
            updated.Telefone1 = aluno.Telefone1;
            updated.Telefone2 = aluno.Telefone2;
            updated.CidadeId = aluno.CidadeId;
            updated.Email = aluno.Email;
            updated.DataUltimaModificacao = aluno.DataUltimaModificacao;
            updated.UsuarioModificacao = aluno.UsuarioModificacao;

            context.SaveChanges();
        }

        public IEnumerable<AlunoModel> GetAll()
        {
            return context.Aluno.ToListAsync().Result;
        }

        public int Count
        {
            get
            {
                return context.Aluno.Count();
            }
        }

        public int SearchCount(int id, string nome, string cpf, string dataNascimento, string dataCadastro)
        {
            if (id != -1)
            {
                return context.Aluno.Where(x => x.Id == id && x.Nome.Contains(nome) && x.Cpf.Contains(cpf) && x.DataNascimento.ToString().Contains(dataNascimento) && x.DataCadastro.ToString().Contains(dataCadastro))
                   .Count();
            }
            else
            {
                return context.Aluno.Where(x => x.Nome.Contains(nome) && x.Cpf.Contains(cpf) && x.DataNascimento.ToString().Contains(dataNascimento) && x.DataCadastro.ToString().Contains(dataCadastro))
                    .Count();
            }
        }
    }
}
