using System.Collections.Generic;

namespace MaybeArchitecture.Core.Models
{
    public class Response
    {
        public Response(
            string message = default,
            bool isSuccess = default,
            bool hasError = default,
            List<string> errorList = default,
            bool isNotFound = default)
        {
            Message = message;
            IsSuccess = isSuccess;
            HasError = hasError;
            ErrorList = errorList;
            IsNotFound = isNotFound;
        }

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool HasError { get; set; }
        public bool IsNotFound { get; set; }
        public List<string> ErrorList { get; set; }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }

    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(isSuccess: true)
        {
        }
    }

    public class NotFoundResponse : Response
    {
        public NotFoundResponse() : base(isNotFound: true)
        {
        }
    }

    public class NotFoundResponse<T> : Response<T>
    {
        public NotFoundResponse()
        {
            IsNotFound = true;
        }
    }
}
