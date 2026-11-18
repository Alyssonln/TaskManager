using TaskManager.Communication.Request;
using TaskManager.Communication.Response;
using TaskManager.Services.UseCase.Tasks.GetById;
using TaskManager.Services.Validators;

namespace TaskManager.Services.UseCase.Tasks.Update;

public class UpdateTaskUseCase
{
    public TaskResponseJson Execute(Guid id, TaskRequestJson request)
    {
        var task = new GetTaskByIdUseCase().Execute(id);

        TaskValidator.Validate(request, isNewTask: false);

        task.Name = request.Name;
        task.Description = request.Description;
        task.Priority = request.Priority;
        task.DueDate = request.DueDate;
        task.Status = request.Status;

        return task;
    }
}
