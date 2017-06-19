using ArthurFrederico.SIGA.Web.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace ArthurFrederico.SIGA.Web
{
    public static class PaginacaoHelper
    {
        public static MvcHtmlString CreatePaginacaoLinks(this HtmlHelper helper, Paginacao paginacao, Func<int, string> linkGenerator)
        {
            StringBuilder linksBuilder = new StringBuilder();

            TagBuilder backTag = new TagBuilder("a");
            backTag.MergeAttribute("href", linkGenerator((paginacao.PaginaAtual > 1) ? (paginacao.PaginaAtual - 1) : paginacao.PaginaAtual));
            backTag.InnerHtml = "&laquo;";
            linksBuilder.Append(backTag);

            for (int i = 1; i < paginacao.NumeroDePaginas + 1; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", linkGenerator(i));
                tag.InnerHtml = i.ToString();

                if (paginacao.PaginaAtual == i)
                {
                    tag.AddCssClass("active");
                }
                linksBuilder.Append(tag);
            }

            TagBuilder prevTag = new TagBuilder("a");
            prevTag.MergeAttribute("href", linkGenerator((paginacao.PaginaAtual < paginacao.NumeroDePaginas) ? (paginacao.PaginaAtual + 1) : paginacao.PaginaAtual));
            prevTag.InnerHtml = "&raquo;";
            linksBuilder.Append(prevTag);

            return MvcHtmlString.Create(linksBuilder.ToString());
        }
    }
}