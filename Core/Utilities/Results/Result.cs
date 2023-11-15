namespace Core.Utilities.Results;

public class Result : IResult
{
    public Result(bool success)
    {
        Success = success;
    }

    public Result(string message, bool success) : this(success)
    {
        Message = message;

    }

    public bool Success { get; }
    public string Message { get; }

    
}