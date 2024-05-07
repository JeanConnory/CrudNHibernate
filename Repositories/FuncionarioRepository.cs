using MvcNHibernate.Models;
using NHibernate;

namespace MvcNHibernate.Repositories;

public class FuncionarioRepository : IFuncionarioRepository<Funcionario>
{
    private NHibernate.ISession _session;

    public FuncionarioRepository(NHibernate.ISession session) => _session = session;

    public async Task Add(Funcionario item)
    {
        ITransaction transaction = null;
        try
        {
            transaction = _session.BeginTransaction();            
            await _session.SaveAsync(item);
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            await transaction?.RollbackAsync();
        }
        finally
        {
            transaction?.Dispose();
        }
    }

    public IEnumerable<Funcionario> FindAll() => _session.Query<Funcionario>().ToList();

    public async Task<Funcionario> FindById(int id) => await _session.GetAsync<Funcionario>(id);

    public async Task Remove(int id)
    {
        ITransaction transaction = null;
        try
        {
            transaction = _session.BeginTransaction();
            var item = await _session.GetAsync<Funcionario>(id);
            await _session.DeleteAsync(item);
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            await transaction?.RollbackAsync();
        }
        finally
        {
            transaction?.Dispose();
        }
    }

    public async Task Update(Funcionario item)
    {
        ITransaction transaction = null;
        try
        {
            transaction = _session.BeginTransaction();
            await _session.UpdateAsync(item);
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            await transaction?.RollbackAsync();
        }
        finally
        {
            transaction?.Dispose();
        }
    }
}
