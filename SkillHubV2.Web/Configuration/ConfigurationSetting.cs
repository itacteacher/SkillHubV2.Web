using System.ComponentModel.DataAnnotations;

namespace SkillsHubV2.Web.Configuration;

public class ConfigurationSetting
{
    [Required]
    public string Key { get; set; }
    [Required]
    public string Value { get; set; }
}