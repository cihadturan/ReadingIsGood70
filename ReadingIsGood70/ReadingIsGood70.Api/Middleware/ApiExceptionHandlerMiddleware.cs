using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReadingIsGood70.BusinessLayer.Exceptions;
using ReadingIsGood70.BusinessLayer.ResponseModels.Auth;
using ReadingIsGood70.BusinessLayer.ResponseModels.Base;
using ReadingIsGood70.EntityLayer.Enum;

namespace ReadingIsGood70.Api.Middleware
{
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionHandlerMiddleware> _logger;

        /// <summary>
        /// Creates a new instance of the ExceptionHandlerMiddleware.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="logger"></param>
        public ApiExceptionHandlerMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlerMiddleware> logger)
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (Exception e)
            {
                this._logger.LogError($"Exception in middleware pipeline. [{e.Message}] [{e}]");

                context.Response.Clear();

                var errorCode = ErrorCodes.Internal;
                if (e is UnauthorizedAccessException || e is ForbiddenAccessException)
                {
                    errorCode = ErrorCodes.Unauthorized;
                }

                var errorResponse = new UnauthorizedResponse(context.TraceIdentifier)
                {
                    Error = new ErrorResponse
                    {
                        Message = e.Message,
                        Code = errorCode
                    }
                };

                await context
                    .Response
                    .WriteAsync(JsonSerializer.Serialize(errorResponse))
                    .ConfigureAwait(false);
            }
        }
    }
}