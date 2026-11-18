using TaskManager.Communication.Request;
using TaskManager.Communication.Response;
using TaskManager.Services.Exceptions;
using TaskManager.Services.Storage;
using TaskManager.Services.Validators;

namespace TaskManager.Services.UseCase.Tasks.Register;

public class RegisterTaskUseCase
{
    public TaskResponseJson Execute(TaskRequestJson request)
    {
        TaskValidator.Validate(request, isNewTask: true);

        var task = new TaskResponseJson()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            Status = request.Status,
        };

        TaskStorage.Tasks.Add(task);
        return task;
    }
}
