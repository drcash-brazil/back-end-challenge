namespace DrCash.Teste.Domain.Entities
{
    public class Autor : Entity
    {
        public string Nome { get; set; }
        public Livro Livro { get; set; }
    }
}
