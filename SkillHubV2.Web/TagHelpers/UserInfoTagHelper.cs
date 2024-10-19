using Microsoft.AspNetCore.Razor.TagHelpers;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.Web.TagHelpers;

[HtmlTargetElement("user-info")]
public class UserInfoTagHelper : TagHelper
{
	public User? User { get; set; }

	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
		if (User != null)
		{
			output.TagName = "div"; // Генерируем <div>
			output.Content.SetHtmlContent($@"
                <p>Name: {User.Username} </p>
                <p>Email: {User.Email}</p>
            ");
		}
		else
		{
			output.Content.SetContent("User not provided");
		}
	}
}

//<user-info user="user"></user-info>
