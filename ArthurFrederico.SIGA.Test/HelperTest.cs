using ArthurFrederico.SIGA.Web;
using ArthurFrederico.SIGA.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArthurFrederico.SIGA.Test
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void PaginacaoHelperTest()
        {
            Paginacao p = new Paginacao()
            {
                PaginaAtual = 1,
                ItensPorPagina = 5,
                TotalItens = 20
            };

            var genereted = PaginacaoHelper.CreatePaginacaoLinks(null, p, x => string.Format("Teste/TestePaginacao/Pagina{0}", x)).ToString();

            Assert.AreEqual(genereted, "<a href=\"Teste/TestePaginacao/Pagina1\">&laquo;</a><a class=\"active\" href=\"Teste/TestePaginacao/Pagina1\">1</a><a href=\"Teste/TestePaginacao/Pagina2\">2</a><a href=\"Teste/TestePaginacao/Pagina3\">3</a><a href=\"Teste/TestePaginacao/Pagina4\">4</a><a href=\"Teste/TestePaginacao/Pagina2\">&raquo;</a>");
        }
    }
}
