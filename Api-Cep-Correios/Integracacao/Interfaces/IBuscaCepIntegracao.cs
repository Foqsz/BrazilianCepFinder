using Api_Cep_Correios.Model;

namespace Api_Cep_Correios.Services.Interfaces
{
    public interface IBuscaCepIntegracao
    {
        Task<CepResponse> GetBuscaCep(string cep);
    }
}
