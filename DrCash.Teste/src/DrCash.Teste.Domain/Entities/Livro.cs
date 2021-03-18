namespace DrCash.Teste.Domain.Entities
{
    public class Livro : Entity
    {
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public Genero Genero { get; set; }
    }
}
