using Api_Cep_Correios.Model;
using Api_Cep_Correios.Services.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

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

        try
        {
            var response = await _httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync(); //converte em string

                var cepJsonObject = JsonConvert.DeserializeObject<CepModel>(content);

                cepJsonObject.Complemento = cepJsonObject.Complemento.IfNullOrEmpty("Sem complemento definido");
                cepJsonObject.Unidade = cepJsonObject.Unidade.IfNullOrEmpty("Sem unidade definida");
                cepJsonObject.Gia = cepJsonObject.Gia.IfNullOrEmpty("Sem GIA definida");

                string cepStringFiltred = JsonConvert.SerializeObject(cepJsonObject, Formatting.Indented);

                return cepStringFiltred;
            }
            else
            {
                return $"Nenhuma localização para o CEP {cep}";
            }
        }
        catch (Exception ex)
        {
            return $"Erro! {ex.Message}";
        }
    }
}

public static class StringExtensions
{
    public static string IfNullOrEmpty(this string value, string defaultValue)
    {
        return string.IsNullOrEmpty(value) ? defaultValue : value;
    }
}

