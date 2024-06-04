using Arcaim.Event;
using Arcaim.Event.Configurations;
using Arcaim.Event.Enums;
using Arcaim.Event.Services;
using Arcaim.Event.Settings;
using Arcaim.Mail.Events;
using Arcaim.Mail.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Arcaim.Mail.Services;

public class MailService : IMailService
{
    private readonly IBrokerConnection _brokerConnection;
    private readonly BrokerSchedulerOptions _schedulerOptions;
    private readonly BrokerMailOptions _mailOptions;

    public MailService(
        IBrokerConnection brokerConnection,
        IOptions<BrokerSchedulerOptions> schedulerOptionsAccessor,
        IOptions<BrokerMailOptions> notificationOptionsAccessor)
    {
        _brokerConnection = brokerConnection;
        _schedulerOptions = schedulerOptionsAccessor.Value.Environmentify();
        _mailOptions = notificationOptionsAccessor.Value.Environmentify();
    }

    public void SendHtmlMail(Entities.HtmlMail htmlMail)
    {
        var @event = new MailEvent
        {
            Id = htmlMail.Id,
            Exchange = _mailOptions.Exchange,
            Queue = _mailOptions.Queue,
            RoutingKey = _mailOptions.RoutingKey + EventTypeMode.SendHtmlMail,
            ExchangeType = ExchangeType.Topic,
            Status = StatusEnum.Ready,
            CreatedBy = htmlMail.CreatedBy,
            Payload = htmlMail.Serialize()
        };

        var schedulerOptions = new BrokerSchedulerOptions
        {
            Exchange = _schedulerOptions.Exchange,
            Queue = _schedulerOptions.Queue,
            RoutingKey = _schedulerOptions.RoutingKey + EventTypeMode.Create
        };
        var eventPublisherService = new EventPublisherService(_brokerConnection, schedulerOptions, ExchangeType.Topic);
        eventPublisherService.PublishEvent(@event.Serialize());
    }
}