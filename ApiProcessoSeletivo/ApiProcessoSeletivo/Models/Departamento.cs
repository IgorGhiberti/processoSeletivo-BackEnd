namespace ApiProcessoSeletivo.Models
{
    public class Departamento
    {
        public int Id { get; init; }
        public string Nome { get; set; }
        public string? Sigla { get; set; }
        public bool Ativo { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

        public Departamento(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
            Ativo = true;
            
        }

    }
}
