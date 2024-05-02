using SistemaDeTarefas.API.Integracao.Response;

namespace SistemaDeTarefas.API.Integracao.Interfaces;

public interface IViaCepIntegracao
{
    Task<ViaCepResponse> ObterDadosViaCep(string cep);
}
