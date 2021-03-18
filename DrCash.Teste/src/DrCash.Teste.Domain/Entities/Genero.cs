namespace DrCash.Teste.Domain.Entities
{
    public class Genero : Entity
    {
        public string Descricao { get; set; }
        public Livro Livro { get; set; }
    }
}
