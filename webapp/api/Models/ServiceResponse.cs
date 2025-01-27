using System;
namespace api.Models
{
    public class ServiceResponse<T>
    {
        public ServiceResponse() { }
        public ServiceResponse(T? data, bool success, string message, string? token)
        {
            Data = data;
            Success = success;
            Message = message;
            Token = token;
        }
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}