namespace ResponseModelWebApi.Models.Response;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public ExceptionModel? Exception { get; set; }
    public ApiResponse()
    {
        IsSuccess = true;
    }
}