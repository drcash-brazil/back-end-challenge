namespace BookStore.Domain.Repositories;

public interface IGenericRepository<T>
{
    void Create(T entity);
    void Update(T entity);
    IEnumerable<T> GetAll();
    T GetById(Guid id);
}