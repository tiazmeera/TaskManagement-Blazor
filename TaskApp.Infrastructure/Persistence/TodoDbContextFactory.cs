using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskApp.Infrastructure.Persistence
{
    public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
            // connection string fallback
            optionsBuilder.UseSqlite("Data Source=taskapp.db");

            return new TodoDbContext(optionsBuilder.Options);
        }
    }
}
