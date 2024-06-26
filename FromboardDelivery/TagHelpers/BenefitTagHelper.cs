using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FromboardDelivery.TagHelpers
{
    public class BenefitTagHelper : TagHelper
    {
        public string? Src { get; set; }
        public string? Head { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "col-xs-12 col-md-6 col-xxl-4 benefit");
            var childContext = await output.GetChildContentAsync();
            string content = childContext.GetContent();
            if (Src != null && Head != null)
            {
                content = $@"
                        <div class=""row"">
                            <div class=""col-3""><img class=""img-fluid benefits-image"" src=""{Src}"" alt=""box""></div>
                            <div class=""col-9"">
                                <h3>{Head}</h3>
                                <p>{content}</p>
                            </div>
                        </div>";
            }

            output.Content.SetHtmlContent(content);
        }
    }
}