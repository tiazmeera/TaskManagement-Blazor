using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskApp.Application.Interfaces;
using TaskApp.Application.Features.Tasks.Commands;

namespace TaskApp.Application.Features.Tasks.Handlers
{
    public class ToggleCompleteHandler : IRequestHandler<ToggleCompleteCommand, Unit>
    {
        private readonly ITodoDbContext _db;
        public ToggleCompleteHandler(ITodoDbContext db) => _db = db;

        public async Task<Unit> Handle(ToggleCompleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (entity == null) throw new KeyNotFoundException("Task not found");

            entity.IsCompleted = request.IsCompleted;
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
