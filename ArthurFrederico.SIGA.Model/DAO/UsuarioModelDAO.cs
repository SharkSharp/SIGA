using ArthurFrederico.SIGA.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ArthurFrederico.SIGA.Model.DAO
{
    public class UsuarioModelDAO
    {
        SIGAContext context = new SIGAContext();

        public void Add(UsuarioModel usuario)
        {
            context.Usuario.Add(usuario);
            context.SaveChanges();
        }

        public UsuarioModel Find(string identifier)
        {
            return context.Usuario.FirstOrDefault(x => x.Nome == identifier || x.Cpf == identifier || x.Telefone == identifier || x.Email == identifier);
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            return context.Usuario;
        }

        public int Count
        {
            get
            {
                return context.Usuario.Count();
            }
        }
    }
}
