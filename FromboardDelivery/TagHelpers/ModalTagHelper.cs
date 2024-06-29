using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FromboardDelivery.TagHelpers
{
    public class ModalTagHelper : TagHelper
    {
        public string? Id { get; set; }
        public string? IdLabel { get; set; }
        public string? Title { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "modal fade");
            output.Attributes.SetAttribute("id", $"{Id}");
            output.Attributes.SetAttribute("tabindex", $"-1");
            output.Attributes.SetAttribute("aria-labelledby", $"{IdLabel}");
            output.Attributes.SetAttribute("aria-hidden", $"true");

            var childContext = await output.GetChildContentAsync();
            string content = childContext.GetContent();
            if (Id != null && IdLabel != null)
            {
                content = $@"
                    <div class=""modal-dialog modal-dialog-centered"" >
                        <div class=""modal-content"">
                            <div class=""modal-header"">
                                <h5 class=""modal-title"">{Title}</h5>
                                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                            </div>
                            <div class=""modal-body"">
                                <h6 id=""{IdLabel}"">{content}</h6>
                            </div>
                                <div class=""modal-footer"">
                                <button type=""button"" class=""btn btn-primary"" data-bs-dismiss=""modal"" style=""padding: 10px 40px"">Ок</button>
                            </div>
                        </div>
                    </div>";
            }
            output.Content.SetHtmlContent(content);
        }
    }
}
