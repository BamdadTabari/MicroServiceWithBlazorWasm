using Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity.Models;

namespace Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity;

public class GetUserBusResponse : BusResponse
{
    public enum Errors
    {
        NotFound = 1
    }

    public UserBusModel User { get; set; }
}