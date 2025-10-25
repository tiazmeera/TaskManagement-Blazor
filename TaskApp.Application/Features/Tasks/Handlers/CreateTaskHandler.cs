using MediatR;
using TaskApp.Application.Interfaces;
using TaskApp.Application.DTOs;
using TaskApp.Application.Features.Tasks.Commands;
using TaskApp.Domain.Entities;

namespace TaskApp.Application.Features.Tasks.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TodoTaskDto>
    {
        private readonly ITodoDbContext _db;
        public CreateTaskHandler(ITodoDbContext db) => _db = db;

        public async Task<TodoTaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                throw new ArgumentException("Title is required");

            var entity = new TodoTask { Title = request.Title.Trim(), Description = request.Description?.Trim() };
            await _db.Tasks.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return new TodoTaskDto(entity.Id, entity.Title, entity.Description, entity.IsCompleted, entity.CreatedAt);
        }
    }
}
