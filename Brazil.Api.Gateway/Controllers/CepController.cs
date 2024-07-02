using Brazil.Api.Gateway.Exceptions;
using Brazil.Api.Gateway.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Brazil.Api.Gateway.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> Get(string cep)
        {
            try
            {
                var cepModel = await _cepService.GetCepAsync(cep);
                return Ok(cepModel);
            }
            catch (CepNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Erro ao comunicar com a BrasilAPI: {ex.Message}");
            }
        }

        [HttpGet("banks")]
        public async Task<IActionResult> GetAllBanks()
        {
            try
            {
                var banks = await _cepService.GetAllBanksAsync();
                return Ok(banks);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Erro ao comunicar com a BrasilAPI: {ex.Message}");
            }
        }

        [HttpGet("banks/{bankCode}")]
        public async Task<IActionResult> GetBankByCode(int bankCode)
        {
            try
            {
                var bank = await _cepService.GetBankByCodeAsync(bankCode);
                return Ok(bank);
            }
            catch (BankCodeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Erro ao comunicar com a BrasilAPI: {ex.Message}");
            }
        }
    }
}