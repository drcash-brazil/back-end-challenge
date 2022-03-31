using System;
using System.Collections.Generic;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;

namespace BookStore.Domain.Tests;

public class FakeRepository : IAuthorRepository
{
    public void Create(Author entity)
    { }

    public IEnumerable<Author> GetAll()
    {
        return new List<Author>();
    }

    public Author GetById(Guid id)
    {
        return new Author("Author");
    }

    public void Update(Author entity)
    { }
}