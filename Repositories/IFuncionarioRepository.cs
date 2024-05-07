namespace MvcNHibernate.Repositories;

public interface IFuncionarioRepository<T> where T : class
{
    Task Add(T item);

    Task Remove(int id);

    Task Update(T item);

    Task<T> FindById(int id);

    IEnumerable<T> FindAll();
}
