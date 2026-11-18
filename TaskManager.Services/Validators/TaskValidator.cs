using TaskManager.Communication.Request;
using TaskManager.Services.Exceptions;

namespace TaskManager.Services.Validators;

public static class TaskValidator
{
    public static void Validate(TaskRequestJson request, bool isNewTask)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("O nome é obrigatório.");
        else if (request.Name.Length > 100)
            errors.Add("O nome deve ter no máximo 100 caracteres.");

        if (request.Description is not null && request.Description.Length > 500)
            errors.Add("A descrição deve ter no máximo 500 caracteres.");

        if (isNewTask && request.DueDate.Date < DateTime.Today)
            errors.Add("A data limite não pode ser no passado.");

        if (errors.Count > 0)
            throw new ErrorOnValidationException(errors);
    }
}
