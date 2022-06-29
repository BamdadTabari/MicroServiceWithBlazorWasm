using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Users;
using Illegible_Cms_V2.Kernel.ServiceBus.Rpc.Identity;
using Illegible_Cms_V2.Kernel.ServiceBus.Rpc.Identity.Models;
using MassTransit;
using MediatR;

namespace Illegible_Cms_V2.Identity.ServiceBus.Consumers
{
    public class GetUserBusRequestConsumer : IConsumer<GetUserBusRequest>
    {
        private readonly IMediator _mediator;

        public GetUserBusRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<GetUserBusRequest> context)
        {
            // Payload
            var userId = context.Message.UserId;

            // Operation
            var operation = await _mediator.Send(new GetUserByIdQuery { UserId = userId });

            var value = operation.Value as UserModel;

            // Response
            await context.RespondAsync(new GetUserBusResponse
            {
                User = new UserBusModel
                {
                    Id = value.Id,
                    Username = value.Username,
                    Email = value.Email
                }
            });
        }
    }
}