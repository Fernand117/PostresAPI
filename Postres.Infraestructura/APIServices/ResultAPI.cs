namespace Postres.Infraestructura.APIServices
{
    public class ResultAPI
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }

        public static ResultAPI Ok() => new ResultAPI() { Success = true, Message = string.Empty, StatusCode = 200 };
        public static ResultAPI Ok(string message) => new ResultAPI() { Message = message, Success = true, StatusCode = 200 };
        public static ResultAPI<T> Ok<T>(T value, string message) => new ResultAPI<T> { Message = message, Response = value, Success = true, StatusCode = 200 };
        public static ResultAPI<T> Ok<T>(T value) => new ResultAPI<T> { Response = value, Success = true, StatusCode = 200 };
    }

    public class ResultAPI<T> : ResultAPI
    {
        public T Response { get; set; }

        public ResultAPI()
        {
            Success = false;
        }

        public ResultAPI(T value)
        {
            Success = value != null;
            Response = value;
        }

        public ResultAPI(T result, bool success)
        {
            Success = success;
            Response = result;
        }

        public ResultAPI(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResultAPI(T result, bool success, string message)
        {
            Success = success;
            Response = result;
            Message = message;
        }
    }
}
