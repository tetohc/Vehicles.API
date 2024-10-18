using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vehicles.Application.Features;

namespace Vehicles.Application.Exceptions
{
    /// Captures and handles unhandled exceptions, configuring an HTTP response with error information.
    public class ExceptionManager : IExceptionFilter
    {
        /// <summary>
        /// Method that executes when an unhandled exception occurs.
        /// </summary>
        /// <param name="context">Exception context, containing details about the occurred exception.</param>
        public void OnException(ExceptionContext context)
        {
            var info = ResponseApiService.Response(statusCode: StatusCodes.Status500InternalServerError, message: context.Exception.Message, data: null);
            context.Result = new ObjectResult(info);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}