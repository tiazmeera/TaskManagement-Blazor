using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskApp.Application.Interfaces;
using TaskApp.Application.DTOs;
using TaskApp.Application.Features.Tasks.Queries;

namespace TaskApp.Application.Features.Tasks.Handlers
{
    public class GetTasksHandler : IRequestHandler<GetTasksQuery, IEnumerable<TodoTaskDto>>
    {
        private readonly ITodoDbContext _db;
        public GetTasksHandler(ITodoDbContext db) => _db = db;

        public async Task<IEnumerable<TodoTaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var query = _db.Tasks.AsNoTracking();

            query = request.Filter switch
            {
                TaskFilter.Completed => query.Where(t => t.IsCompleted),
                TaskFilter.Pending => query.Where(t => !t.IsCompleted),
                _ => query
            };

            var list = await query.OrderByDescending(t => t.CreatedAt).ToListAsync(cancellationToken);

            return list.Select(t => new TodoTaskDto(t.Id, t.Title, t.Description, t.IsCompleted, t.CreatedAt));
        }
    }
}
