using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WEB_053504_Mazurenko.TagHelpers
{
    [HtmlTargetElement(tag: "img", Attributes = "action, controller")]
    public class ImageTagHelper : TagHelper
    {
        LinkGenerator _linkGenerator;
        IHttpContextAccessor _contextAccessor;

        public string Action { get; set; }
        public string Controller { get; set; }

        public ImageTagHelper(LinkGenerator linkGenerator, IHttpContextAccessor accessor)
        {
            _linkGenerator = linkGenerator;
            _contextAccessor = accessor;
        }
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            // контейнер разметки пейджера
            output.TagName = "img";
            // пейджер
            output.TagMode = TagMode.SelfClosing;
            output.Attributes.SetAttribute("src", _linkGenerator.GetPathByAction(Action, Controller));

        }
    }
}