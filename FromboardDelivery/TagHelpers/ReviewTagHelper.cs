using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FromboardDelivery.TagHelpers
{
    public class ReviewTagHelper : TagHelper
    {
        public string? Author { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "col-6");
            var childContext = await output.GetChildContentAsync();
            string content = childContext.GetContent();
            if (Author != null)
            {
                content = $@"
                        <div class=""card rounded-4"">
                            <div class=""card-body"">
                                <p class=""card-text"">{content}</p>
                                <div class=""card-body-flex""><p class=""card-link"">{Author}</p><img class=""quotes"" src=""img/mini-icon/Quotes.svg"" alt=""quote""></div>
                            </div>
                        </div>";
            }

            output.Content.SetHtmlContent(content);
        }
    }
}
