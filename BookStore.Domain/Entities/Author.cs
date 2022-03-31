namespace BookStore.Domain.Entities;

public class Author : Entity
{
    public Author(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = String.Empty;

    public void UpdateAuthor(string name)
    {
        Name = name;
    }
}