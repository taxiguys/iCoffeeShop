using System.Net;
using iCoffeeShop.Server.Shared.Strings;
using Microsoft.AspNetCore.Mvc;

namespace iCoffeeShop.Server.Shared
{
    public static class ApiResultExtensions
    {
        public static IActionResult ErrorResult(this ControllerBase controller,
                                                ErrorCode errorCode,
                                                HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return JsonResult(new ApiResponse<object>((int) errorCode,
                                                      ErrorResource.ResourceManager.GetString(errorCode.ToString())),
                              statusCode);
        }

        public static IActionResult ErrorResult(this ControllerBase controller,
                                                int? errorCode,
                                                string errorMessage,
                                                HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return JsonResult(new ApiResponse<object>(errorCode,
                                                      errorMessage),
                              statusCode);
        }

        public static IActionResult OkResult(this ControllerBase controller)
        {
            return JsonResult(new ApiResponse<object>(true));
        }

        public static IActionResult OkResult<T>(this ControllerBase controller,
                                                T result)
        {
            return JsonResult(new ApiResponse<T>(result));
        }

        public static IActionResult OkResult(this ControllerBase controller,
                                             object result)
        {
            return JsonResult(new ApiResponse<object>(result));
        }

        private static IActionResult JsonResult(object result,
                                                HttpStatusCode httpStatus = HttpStatusCode.OK)
        {
            return new ApiJsonResult(result,
                                     httpStatus);
        }
    }
}
