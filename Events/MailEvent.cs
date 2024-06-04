using Arcaim.Event.Events;

namespace Arcaim.Mail.Events;

public class MailEvent : BaseEvent
{
  public Entities.HtmlMail? HtmlMail { get; set; }
}
