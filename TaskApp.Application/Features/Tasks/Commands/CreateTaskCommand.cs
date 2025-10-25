using MediatR;
using TaskApp.Application.DTOs;

namespace TaskApp.Application.Features.Tasks.Commands
{
    public record CreateTaskCommand(string Title, string? Description) : IRequest<TodoTaskDto>;
}
