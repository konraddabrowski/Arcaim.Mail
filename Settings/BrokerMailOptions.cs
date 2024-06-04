using System.ComponentModel;
using Arcaim.Event.Settings;

namespace Arcaim.Mail.Settings;

[Description("Broker:Mail")]
public class BrokerMailOptions : IBrokerMessageOptions
{
    public required string Exchange { get; set; }
    public string? Queue { get; set; }
    public required string RoutingKey { get; set; }
}