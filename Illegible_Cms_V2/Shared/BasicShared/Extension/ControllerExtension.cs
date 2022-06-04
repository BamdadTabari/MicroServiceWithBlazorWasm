using Illegible_Cms_V2.Shared.Infrastructure.Errors;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Shared.BasicShared.Extension
{

    public static IActionResult ReturnResponse(this ControllerBase controller, OperationResult operation)
    {
        var response = operation.Value;
        if (response is ErrorModel errorModel)
            response = new ErrorResponse(errorModel);

        return operation.Status switch
        {
            OperationResultStatus.Ok => controller.Ok(response),
            OperationResultStatus.Invalidated => controller.BadRequest(response),
            OperationResultStatus.NotFound => controller.NotFound(response),
            OperationResultStatus.Unauthorized => controller.UnprocessableEntity(response),
            OperationResultStatus.Unprocessable => controller.UnprocessableEntity(response),
            _ => controller.UnprocessableEntity(response)
        };
    }
}