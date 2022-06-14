using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illegible_Cms_V2.Shared.Infrastructure.Operations
{
    public class OperationResult
    {
        public readonly OperationResultStatus Status;
        public readonly bool IsPersistAble;
        public readonly object Value;
        public readonly Dictionary<string, string> OperationValues;

        public OperationResult(OperationResultStatus status, object value, bool isPersistAble = false,
            Dictionary<string, string> operationValues = null)
        {
            Status = status;
            Value = value;
            IsPersistAble = isPersistAble;
            OperationValues = operationValues;
        }

        public OperationResult(OperationResult operation, bool succeeded)
        {
            Status = succeeded ? OperationResultStatus.Ok : OperationResultStatus.UnProcessable;
            IsPersistAble = operation.IsPersistAble;
            Value = operation.Value;
            OperationValues = operation.OperationValues;
        }

        public bool Succeeded => IsSucceeded(Status);

        private bool IsSucceeded(OperationResultStatus status) => status switch
        {
            _ when 
                status == OperationResultStatus.Ok => true,
            _ when
                status == OperationResultStatus.Invalidated || 
                status == OperationResultStatus.NotFound ||
                status == OperationResultStatus.Unauthorized ||
                status == OperationResultStatus.UnProcessable => false,
            _ => false
        };
    }
}

