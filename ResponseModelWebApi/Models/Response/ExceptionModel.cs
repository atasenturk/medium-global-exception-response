namespace ResponseModelWebApi.Models.Response;

public class ExceptionModel
{
    public string? ExceptionType { get; set; }
    public string? ExceptionMessage { get; set; }
    public string? StackTrace { get; set; }
}