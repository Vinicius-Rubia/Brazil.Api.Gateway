using Brazil.Api.Gateway.Models;

namespace Brazil.Api.Gateway.Interfaces
{
    public interface IBrazilApiService
    {
        Task<CepModel> GetCepAsync(string cep);
        Task<List<BankModel>> GetAllBanksAsync();
        Task<BankModel> GetBankByCodeAsync(int bankCode);
    }
}
