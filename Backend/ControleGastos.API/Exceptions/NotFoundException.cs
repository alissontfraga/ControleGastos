namespace ControleGastos.API.Exceptions
{
    // Exception utilizada quando um recurso solicitado
    // não é encontrado no sistema.
    public class NotFoundException(string message) : Exception(message)
    {
    }
}