using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Models;

namespace TagHelpers.TagHelpers
{
    [HtmlTargetElement("CompanyAddress")]
    public class CompanyAddressTagHelper : TagHelper
    {
        public Address Address1 { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "address";
            output.Content.SetHtmlContent(
                $@"{Address1.Street}<br />
                        {Address1.City}, {Address1.PostalCode}<br />
                        <abbr title=""Phone"">P:</abbr>
                                {Address1.Phone}");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}