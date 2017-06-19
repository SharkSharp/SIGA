using System;

namespace ArthurFrederico.SIGA.Web.Models
{
    public class Paginacao
    {
        public int TotalItens { get; set; }

        public int ItensPorPagina { get; set; }

        public int PaginaAtual { get; set; }

        public int NumeroDePaginas
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItens / ItensPorPagina);
            }
        }
    }
}