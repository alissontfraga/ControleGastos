namespace ControleGastos.API.Exceptions
{
    // Exception utilizada quando uma regra de negócio da aplicação
    // é violada.
    public class BusinessException(string message) : Exception(message)
    {
    }
}