using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Identity.Application.Helpers
{
    public static class PartialUpdate<T>
    {
        public static T? Run(T sourceProperty, T inputProperty, PartialUpdateOperand op)
        {
            if (op == PartialUpdateOperand.Replace) return inputProperty;
            if (op == PartialUpdateOperand.Remove) return default;
            return default;
        }
    }
}
