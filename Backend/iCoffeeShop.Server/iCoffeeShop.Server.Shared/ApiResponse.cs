using System;

namespace iCoffeeShop.Server.Shared
{
    public class ApiResponse<T>
    {
        public ApiResponse(T result)
        {
            Successful = true;
            Result = result;
        }

        public ApiResponse(bool successful)
        {
            Successful = successful;
        }

        public ApiResponse(int? errorCode,
                           string errorMessage)
        {
            Successful = false;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public bool Successful { get; set; }

        public T Result { get; set; }

        public int? ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
