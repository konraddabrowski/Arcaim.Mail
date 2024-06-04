namespace Arcaim.Mail.Services;

public interface IMailService
{
  void SendHtmlMail(Entities.HtmlMail @event);
}