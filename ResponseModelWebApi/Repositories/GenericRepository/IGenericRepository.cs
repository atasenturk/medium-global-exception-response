namespace ResponseModelWebApi.Repositories.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    Task<T> Create(T entity);
    Task Delete(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    void Update(T entity);
}