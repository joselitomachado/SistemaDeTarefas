using Refit;
using SistemaDeTarefas.API.Integracao.Response;

namespace SistemaDeTarefas.API.Integracao.Refit;

public interface IViaCepIntegracaoRefit
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
}
