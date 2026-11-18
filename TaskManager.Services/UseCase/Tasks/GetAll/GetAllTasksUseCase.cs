using TaskManager.Communication.Response;
using TaskManager.Services.Storage;

namespace TaskManager.Services.UseCase.Tasks.GetAll;

public class GetAllTasksUseCase
{
    public ResponseGetAllTasksJson Execute()
    {
        return new ResponseGetAllTasksJson
        {
            Tasks = TaskStorage.Tasks
        };
    }
}
