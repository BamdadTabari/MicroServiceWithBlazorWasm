using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illegible_Cms_V2.Shared.Infrastructure.Operations
{
    public enum OperationResultStatus
    {
        Ok = 1,
        Invalidated,
        NotFound,
        Unauthorized,
        UnProcessable
    }
}
