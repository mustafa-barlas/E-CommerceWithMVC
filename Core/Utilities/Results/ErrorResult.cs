namespace Core.Utilities.Results;

public class ErrorResult : Result
{
    public ErrorResult() : base(false)
    {
    }

    public ErrorResult(string message) : base(message, false)
    {
    }
}