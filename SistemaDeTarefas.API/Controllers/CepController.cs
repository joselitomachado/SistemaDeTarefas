using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.API.Integracao.Interfaces;
using SistemaDeTarefas.API.Integracao.Response;

namespace SistemaDeTarefas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CepController : ControllerBase
{
    private readonly IViaCepIntegracao _viaCepIntegracao;

    public CepController(IViaCepIntegracao viaCepIntegracao)
    {
        _viaCepIntegracao = viaCepIntegracao;
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
    {
        var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

        if(responseData == null)
        {
            return BadRequest("CEP não encontrado.");
        }

        return Ok(responseData);
    }
}
