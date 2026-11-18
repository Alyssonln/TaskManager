using TaskManager.Communication.Response;
using TaskManager.Services.Exceptions;
using TaskManager.Services.Storage;

namespace TaskManager.Services.UseCase.Tasks.GetById;

public class GetTaskByIdUseCase
{
    public TaskResponseJson Execute(Guid id)
    {
        var task = TaskStorage.Tasks.FirstOrDefault(task => task.Id == id);

        if (task is null)
            throw new NotFoundException("Tarefa não encontrada.");

        return task;
    }
}
