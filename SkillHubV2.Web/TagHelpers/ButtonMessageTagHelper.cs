using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SkillsHubV2.Web.TagHelpers;

[HtmlTargetElement("button", Attributes = "asp-user-message")]
public class ButtonMessageTagHelper : TagHelper
{
	public string AspUserMessage { get; set; }

	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
		output.Attributes.SetAttribute("data-message", AspUserMessage);
		output.TagName = "button";
	}
}
