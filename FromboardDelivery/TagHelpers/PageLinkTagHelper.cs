using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using FromboardDelivery.Models;
using Microsoft.Extensions.Hosting;
using System.Security;

namespace FromboardDelivery.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;
        public GroupViewModel PageModel { get; set; } = null!;
        public string PageQuery { get; set; } = null!;
        public string AspPage { get; set; } = "";
        public string AspFragment { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            string innerContent = "";

                for (int page = 1; page <= PageModel.TotalPages; page++)
                {
                    innerContent += CreateLi(PageModel, page);

                }
            output.Content.SetHtmlContent($"<ul class=\"pagination\">{innerContent}</ul>");
        }
        private string CreateLi(GroupViewModel? pageModel, int pageNumber = 1)
        {
            string content = "";
            string itemClass = "page-item ";
            string anchorAttribute = "";
            if (pageNumber == pageModel?.PageNumber)
            {
                itemClass += "active";
            }
            else
            {
                anchorAttribute = $"href=\"/{AspPage}?{PageQuery}={pageNumber}#{AspFragment}\"";
            }
            content = $@"<li class=""{itemClass}""><a class=""page-link"" {anchorAttribute}>{pageNumber}</a></li>";
            return content;
        }
    }
}

