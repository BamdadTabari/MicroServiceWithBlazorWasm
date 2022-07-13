namespace Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity;

public class GetUserBusRequest : BusRequest
{
    public int UserId { get; set; }
}