using Challenges.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Challenges.Helpers
{
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this IHtmlHelper helper,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                System.Web.Mvc.TagBuilder tag = new System.Web.Mvc.TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return new HtmlString(result.ToString());
        }
    }
}