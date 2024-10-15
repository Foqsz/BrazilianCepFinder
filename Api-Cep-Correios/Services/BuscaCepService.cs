using Api_Cep_Correios.Services.Interfaces;

namespace Api_Cep_Correios.Services;

public class BuscaCepService : IBuscaCepService
{
    private readonly HttpClient _httpClient;

    public BuscaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<object> CheckCep(string cep)
    {
        string baseUrl = "https://viacep.com.br/ws/";
        string fullUrl = $"{baseUrl}{cep}/json/";

        var response = await _httpClient.GetAsync(fullUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content; 
        }
        return null;
    }
}
