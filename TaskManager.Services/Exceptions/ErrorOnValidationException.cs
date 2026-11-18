namespace TaskManager.Services.Exceptions;

public class ErrorOnValidationException : Exception
{
    public List<string> Errors { get; }

    public ErrorOnValidationException(List<string> errors)
    {
        Errors = errors;
    }
}
