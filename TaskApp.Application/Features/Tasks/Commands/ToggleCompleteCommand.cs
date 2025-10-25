using MediatR;
namespace TaskApp.Application.Features.Tasks.Commands
{
    public record ToggleCompleteCommand(Guid Id, bool IsCompleted) : IRequest<Unit>;
}
