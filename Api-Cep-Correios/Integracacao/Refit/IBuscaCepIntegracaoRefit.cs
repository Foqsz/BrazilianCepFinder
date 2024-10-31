using Api_Cep_Correios.Model;
using Refit;

namespace Api_Cep_Correios.Services.Refit;

public interface IBuscaCepIntegracaoRefit
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<CepResponse>> CheckCep(string cep);
}
