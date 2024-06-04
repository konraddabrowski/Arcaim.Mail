using Arcaim.Mail.Enums;

namespace Arcaim.Mail.Entities;

public class HtmlMailOptions
{
    public required EmailAddress To { get; set; }
    public required IEnumerable<string> Values { get; set; }
    public required LanguageMode.Enum Language { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedOn { get; set; }
}