namespace BookStore.Domain.Entities;

public class Genre : Entity
{
    public Genre(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = String.Empty;

    public void UpdateGenre(string name)
    {
        Name = name;
    }
}