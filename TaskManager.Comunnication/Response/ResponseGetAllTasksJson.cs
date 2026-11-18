namespace TaskManager.Communication.Response;

public class ResponseGetAllTasksJson
{
    public List<TaskResponseJson> Tasks { get; set; } = [];
}
