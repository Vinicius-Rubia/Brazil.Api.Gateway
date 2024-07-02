namespace Brazil.Api.Gateway.Models
{
    public class CepModel
    {
        public string Cep { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}