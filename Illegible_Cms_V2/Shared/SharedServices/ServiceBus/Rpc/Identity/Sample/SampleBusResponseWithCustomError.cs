namespace Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity.Sample;

public class SampleBusResponseWithCustomError : BusResponse
{
    public string Text { get; set; }
    public new CustomError Error { get; set; }

    public override bool HasError()
    {
        if (this.Error != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}