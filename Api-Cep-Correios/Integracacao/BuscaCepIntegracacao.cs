using Api_Cep_Correios.Model;
using Api_Cep_Correios.Services.Interfaces;
using Api_Cep_Correios.Services.Refit;
using Refit;

public class BuscaCepIntegracacao : IBuscaCepIntegracao
{
    private readonly IBuscaCepIntegracaoRefit _buscaCepRefitService;

    public BuscaCepIntegracacao(IBuscaCepIntegracaoRefit buscaCepRefit)
    {
        _buscaCepRefitService = buscaCepRefit;
    }
    public async Task<CepResponse> GetBuscaCep(string cep)
    {
        try
        {
            var cepResponse = await _buscaCepRefitService.CheckCep(cep);

            return cepResponse.Content;
        }
        catch (ApiException ex)
        {
            return null;
        }
    }
}
