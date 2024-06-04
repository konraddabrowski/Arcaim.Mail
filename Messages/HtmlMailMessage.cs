using Arcaim.Event.Messages;
using Arcaim.Mail.Enums;

namespace Arcaim.Mail.Messages;

public class HtmlMailMessage : IMessage
{
  public Guid Id { get; set; }
  public AddressMessage? To { get; set; }
  public IEnumerable<string> Values { get; set; } = [];
  public HtmlTemplateTypeMode.Enum Type { get; set; }
  public LanguageMode.Enum Language { get; set; }
  public string CreatedBy { get; set; } = string.Empty;
  public DateTime CreatedOn { get; set; }
  
  public class AddressMessage
  {
    public string Value { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
  }
}
