using SistemaDeTarefas.API.Enums;

namespace SistemaDeTarefas.API.Models;

public class TarefaModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao {  get; set; } = string.Empty;
    public StatusTarefa Status { get; set; }
    public int? UsuarioId { get; set; }
    public virtual UsuarioModel? Usuario { get; set; }
}
