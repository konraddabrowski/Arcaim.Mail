using Arcaim.Mail.Enums;

namespace Arcaim.Mail.Entities;

public class HtmlMail : AuditEntity<Guid>
{
  public static HtmlMail Register(HtmlMailOptions options) => CreateBase(options, HtmlTemplateTypeMode.Enum.Registration);

  private static HtmlMail CreateBase(HtmlMailOptions options, HtmlTemplateTypeMode.Enum htmlTemplate) => new ()
  {
    Id = Guid.NewGuid(),
    CreatedBy = options.CreatedBy,
    CreatedOn = options.CreatedOn,
    HtmlTemplate = htmlTemplate,
    To = options.To,
    Values = options.Values,
    Language = options.Language,
  };

  public required EmailAddress To { get; set; }
  public required IEnumerable<string> Values { get; set; }
  public required LanguageMode.Enum Language { get; set; }
  public required HtmlTemplateTypeMode.Enum HtmlTemplate { get; set; }
}