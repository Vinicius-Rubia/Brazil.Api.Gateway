namespace Brazil.Api.Gateway.Exceptions
{
    public class CepBadRequestException : Exception
    {
        public CepBadRequestException(string cep) : base($"CEP: {cep} não é um CEP válido.") { }
    }
}
