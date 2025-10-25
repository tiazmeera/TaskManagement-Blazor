using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Application.DTOs
{
    public record TodoTaskDto(Guid Id, string Title, string? Description, bool IsCompleted, DateTime CreatedAt);
}
