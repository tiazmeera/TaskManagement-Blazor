using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;

namespace TaskApp.Application.Interfaces
{
    public interface ITodoDbContext
    {
        DbSet<TodoTask> Tasks { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
