namespace Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Events;

public class UserStateUpdatedBusEvent : BusEvent
{
    public int UserId { get; set; }
    public string State { get; set; }
}