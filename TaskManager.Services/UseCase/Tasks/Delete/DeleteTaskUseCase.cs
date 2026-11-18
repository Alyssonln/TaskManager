using TaskManager.Services.Storage;
using TaskManager.Services.UseCase.Tasks.GetById;

namespace TaskManager.Services.UseCase.Tasks.Delete;

public class DeleteTaskUseCase
{
    public void Execute(Guid id)
    {
        var task = new GetTaskByIdUseCase().Execute(id);

        TaskStorage.Tasks.Remove(task);
    }
}