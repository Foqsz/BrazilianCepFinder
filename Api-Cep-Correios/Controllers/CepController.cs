using Api_Cep_Correios.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Api_Cep_Correios.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CepController : ControllerBase
{
    private readonly IBuscaCepService _buscaCepService;

    public CepController(IBuscaCepService buscaCepService)
    {
        _buscaCepService = buscaCepService;
    }

    [HttpGet]
    public async Task <ActionResult> GetCheckCep(string cep)
    {
        var checkCep = await _buscaCepService.CheckCep(cep);

        if (checkCep is null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "CEP Não localizado");
        } 
        return StatusCode(StatusCodes.Status200OK, checkCep);

    }
}
