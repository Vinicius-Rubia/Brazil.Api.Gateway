namespace Brazil.Api.Gateway.Exceptions
{
    public class BankCodeNotFoundException : Exception
    {
        public BankCodeNotFoundException(int bankCode) : base($"Código: {bankCode} não foi encontrado.") { }
    }
}
