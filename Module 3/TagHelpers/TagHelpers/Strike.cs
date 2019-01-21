using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.TagHelpers
{
    //[HtmlTargetElement("MyStrike")]
    //[HtmlTargetElement("strike", Attributes = "strike")]
    [HtmlTargetElement(Attributes = "strike")]
    public class Strike : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("strike");
            output.PreContent.SetHtmlContent("<strike>");
            output.PostContent.SetHtmlContent("</strike>");
        }
    }
}
 