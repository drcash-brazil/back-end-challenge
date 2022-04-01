using System.Text.Json.Serialization;

namespace BookStore.Domain.Entities;

public class Author : Entity
{
    public Author(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = String.Empty;

    [JsonIgnore]
    public Guid BookId { get; set; }

    [JsonIgnore]
    public Book? Book { get; set; }

    public void UpdateAuthor(string name)
    {
        Name = name;
    }

}