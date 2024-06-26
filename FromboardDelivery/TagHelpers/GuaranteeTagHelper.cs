using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FromboardDelivery.TagHelpers
{
    public class GuaranteeTagHelper : TagHelper
    {
        public string? Src { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "col-xxl-3 col-md-6 col-xs-12 quality-item");
            var childContext = await output.GetChildContentAsync();
            string content = childContext.GetContent();
            if (Src != null)
            {
                content = $@"
                        <a href=""{Src}""><img class=""img-fluid"" src=""{Src}"" alt=""image""></a>
                        <p>{content}</p>";
            }

            output.Content.SetHtmlContent(content);
        }
    }
}
