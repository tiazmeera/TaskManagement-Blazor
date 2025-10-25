using Microsoft.EntityFrameworkCore;
using TaskApp.Application.Features.Tasks.Commands;
using TaskApp.Application.Features.Tasks.Handlers;
using TaskApp.Infrastructure.Persistence;

namespace TaskApp.Application.Tests
{
    public class CreateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldAddNewTask()
        {
            // Arrange - guna in-memory DB
            var options = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(databaseName: "TaskDb_Test")
                .Options;

            using var context = new TodoDbContext(options);

            var handler = new CreateTaskHandler(context);
            var command = new CreateTaskCommand("Test Title", "Test Description");

            // Act
            var taskDto = await handler.Handle(command, CancellationToken.None);

            // Assert
            var task = await context.Tasks.FindAsync(taskDto.Id); //  guna Id property
            Assert.NotNull(task);
            Assert.Equal("Test Title", task.Title);
            Assert.False(task.IsCompleted);
        }
    }
}
