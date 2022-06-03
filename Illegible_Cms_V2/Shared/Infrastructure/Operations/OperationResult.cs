namespace Illegible_Cms_V2.Shared.Infrastructure.Operations;

public class OperationResult
{
    public readonly bool IsPersistable;
    public readonly Dictionary<string, string> OperationValues;
    public readonly OperationResultStatus Status;
    public readonly object Value;

    public OperationResult(OperationResultStatus status, object value,
        bool isPersistable = false, Dictionary<string, string> operationValues = null)
    {
        Status = status;
        Value = value;
        IsPersistable = isPersistable;
        OperationValues = operationValues;
    }

    public OperationResult(OperationResult operation, bool succeeded)
    {
        Status = succeeded ? OperationResultStatus.Ok : OperationResultStatus.Unprocessable;
        IsPersistable = operation.IsPersistable;
        Value = operation.Value;
        OperationValues = operation.OperationValues;
    }

    public bool Succeeded => IsSucceeded(Status);

    private bool IsSucceeded(OperationResultStatus status)
    {
        return status switch
        {
            _ when
                status == OperationResultStatus.Ok => true,
            _ when
                status == OperationResultStatus.Invalidated ||
                status == OperationResultStatus.NotFound ||
                status == OperationResultStatus.Unauthorized ||
                status == OperationResultStatus.Unprocessable => false,
            _ => false
        };
    }
}