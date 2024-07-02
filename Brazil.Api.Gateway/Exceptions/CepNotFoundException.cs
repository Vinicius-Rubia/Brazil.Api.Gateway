namespace Brazil.Api.Gateway.Exceptions
{
    public class CepNotFoundException : Exception
    {
        public CepNotFoundException(string cep) : base($"CEP: {cep} não foi encontrado.") { }
    }
}
