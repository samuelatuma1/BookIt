using System;
using System.Net;
using System.Text.Json;
using BookIt.Api.Model;
using BookIt.Core.Application.Exceptions;

namespace BookIt.Api.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(ex, httpContext);
            }
        }

        public async Task HandleExceptionAsync(Exception ex, HttpContext httpContext)
        {
            ErrorModel problem;

            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            switch (ex)
            {
                case BadRequestException exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    problem = new ErrorModel() {
                        Message = exception.Message,
                        Errors = exception.Errors
                    };
                    break;

                case KeyDoesNotMatchException exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    problem = new ErrorModel()
                    {
                        Message = exception.Message,
                        Errors = exception.Errors
                    };
                    break;
                default:
                    problem = new ErrorModel()
                    {
                        Message = ex.Message
                    };
                    break;
            }

            await httpContext.Response.WriteAsJsonAsync(problem);

        }
    }
}

