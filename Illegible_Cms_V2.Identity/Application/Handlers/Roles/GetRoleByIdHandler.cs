using AutoMapper;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Roles;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRoleByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.RoleNotFoundError);
        var model = new RoleModel();
        model = _mapper.Map<RoleModel>(entity);

        return new OperationResult(OperationResultStatus.Ok, value: model);
    }
}