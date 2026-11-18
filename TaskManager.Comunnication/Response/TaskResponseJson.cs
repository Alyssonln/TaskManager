using TaskManager.Communication.Enum;

namespace TaskManager.Communication.Response;

public class TaskResponseJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PriorityEnum Priority { get; set; }
    public DateTime DueDate { get; set; }
    public StatusEnum Status { get; set; }
}
