using Microsoft.AspNetCore.Razor.TagHelpers;
using SkillsHubV2.BLL.Interfaces;

namespace SkillsHubV2.Web.TagHelpers;

[HtmlTargetElement("async-data")]
public class AsyncDataTagHelper : TagHelper
{
	private readonly ISkillService _dataService;

	public AsyncDataTagHelper(ISkillService dataService)
	{
		_dataService = dataService;
	}

	public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
	{
		output.TagName = "div";

		var data = await _dataService.GetAllSkillsAsync();

		output.Content.SetContent(data.ToString());
	}
}
