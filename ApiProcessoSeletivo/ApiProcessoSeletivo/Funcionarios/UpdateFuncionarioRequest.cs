namespace ApiProcessoSeletivo.Funcionarios
{
    public record UpdateFuncionarioRequest(string nome, string foto, int rg, int departamentoId);

}
