using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var response = new ProblemDetails();

            switch (exception)
            {
                case NotFoundException:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

                    response.Title = "Recurso não encontrado.";
                    response.Detail = exception.Message;
                    response.Status = 404;

                    break;

                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    response.Title = "Erro interno do servidor.";
                    response.Detail = "Ocorreu um erro inesperado.";
                    response.Status = 500;

                    break;
            }

            await httpContext.Response.WriteAsJsonAsync(
                response,
                cancellationToken
            );

            return true;
        }
    }
}