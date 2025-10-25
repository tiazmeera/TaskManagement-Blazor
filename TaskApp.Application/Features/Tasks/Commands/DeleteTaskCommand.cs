using MediatR;
namespace TaskApp.Application.Features.Tasks.Commands
{
    public record DeleteTaskCommand(Guid Id) : IRequest<Unit>;
}
