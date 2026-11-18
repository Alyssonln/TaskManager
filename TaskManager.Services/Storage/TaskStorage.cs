using TaskManager.Communication.Response;

namespace TaskManager.Services.Storage;

public static class TaskStorage
{
    public static List<TaskResponseJson> Tasks { get; } = [];
}