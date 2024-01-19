namespace ApiProcessoSeletivo.Models
{
    public class Funcionario
    {
        public int Id { get; init; }
        public string Nome { get; set; }
        public string? Foto { get; set; }
        public int Rg { get; set; }
        public int DepartamentoId { get; set; }
        public bool Ativo { get; set; }

        public Funcionario(string nome, string foto, int rg, int departamentoId)
        {
            Nome = nome;
            Foto = foto;
            Rg = rg;
            DepartamentoId = departamentoId;
            Ativo = true;
        }
    }
}
