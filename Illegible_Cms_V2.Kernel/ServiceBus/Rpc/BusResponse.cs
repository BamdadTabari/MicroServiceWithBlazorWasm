namespace Illegible_Cms_V2.Kernel.ServiceBus.Rpc
{
    public class BusResponse
    {
        public virtual Error Error { get; set; }

        public virtual bool HasError()
        {
            return Error != null;
        }
    }
}
