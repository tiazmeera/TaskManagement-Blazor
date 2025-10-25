using MediatR;
using TaskApp.Application.DTOs;

namespace TaskApp.Application.Features.Tasks.Queries
{
    public enum TaskFilter { All, Completed, Pending }
    public record GetTasksQuery(TaskFilter Filter) : IRequest<IEnumerable<TodoTaskDto>>;
}