namespace Task.Core.ResponseWrapper
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public static Response<T> Success(T data, string message = "Success")
            => new Response<T> { IsSuccess = true, Message = message, Data = data };

        public static Response<T> Fail(string message)
            => new Response<T> { IsSuccess = false, Message = message };
    }

}
