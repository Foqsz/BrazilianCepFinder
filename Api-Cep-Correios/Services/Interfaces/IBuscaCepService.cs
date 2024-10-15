namespace Api_Cep_Correios.Services.Interfaces;

public interface IBuscaCepService
{
    Task<object> CheckCep(string cep);
}
