﻿namespace Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Events;

public class BusEvent
{
    public Guid EventId { get; set; } = Guid.NewGuid();
    public ServiceName Owner { get; set; }
    public DateTime EventTime { get; set; } = DateTime.UtcNow;
}