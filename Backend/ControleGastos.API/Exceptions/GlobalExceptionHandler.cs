using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(exception, exception.Message);

            var response = new ProblemDetails();

            switch (exception)
            {
                case NotFoundException:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

                    response.Title = "Recurso não encontrado.";
                    response.Detail = exception.Message;
                    response.Status = 404;

                    break;

                case BusinessException:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                    response.Title = "Regra de negócio violada.";
                    response.Detail = exception.Message;
                    response.Status = 400;

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