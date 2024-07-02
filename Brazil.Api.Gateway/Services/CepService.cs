using Brazil.Api.Gateway.Exceptions;
using Brazil.Api.Gateway.Interfaces;
using Brazil.Api.Gateway.Models;
using System.Net;
using System.Text.Json;

namespace Brazil.Api.Gateway.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepModel> GetCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new CepNotFoundException(cep);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var cepModel = JsonSerializer.Deserialize<CepModel>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return cepModel;
        }

        public async Task<List<BankModel>> GetAllBanksAsync()
        {
            var response = await _httpClient.GetAsync("https://brasilapi.com.br/api/banks/v1");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var banks = JsonSerializer.Deserialize<List<BankModel>>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return banks;
        }

        public async Task<BankModel> GetBankByCodeAsync(int bankCode)
        {
            var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/banks/v1/{bankCode}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new BankCodeNotFoundException(bankCode);
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var bank = JsonSerializer.Deserialize<BankModel>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return bank;
        }
    }
}