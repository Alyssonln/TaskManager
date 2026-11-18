using TaskManager.Communication.Enum;

namespace TaskManager.Communication.Request;

public class TaskRequestJson
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PriorityEnum Priority { get; set; }
    public DateTime DueDate { get; set; }
    public StatusEnum Status { get; set; }
}
