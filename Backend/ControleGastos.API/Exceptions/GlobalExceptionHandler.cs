using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Exceptions
{
    // Handler global responsável por capturar exceções da aplicação
    // e retornar respostas HTTP padronizadas para a API.
    public class GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Registra a exceção para facilitar o diagnóstico de erros.
            logger.LogError(exception, exception.Message);

            var response = new ProblemDetails();

            switch (exception)
            {
                // Recurso solicitado não foi encontrado.
                case NotFoundException:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

                    response.Title = "Recurso não encontrado.";
                    response.Detail = exception.Message;
                    response.Status = 404;

                    break;


                // Erro causado por uma regra de negócio da aplicação.
                case BusinessException:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                    response.Title = "Regra de negócio violada.";
                    response.Detail = exception.Message;
                    response.Status = 400;

                    break;


                // Trata erros inesperados que não possuem tratamento específico.
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