using NHibernate;
using System.Collections.Generic;
using System.Linq;
using WpfVodovoz.Models;

public interface IRepository<T>
{
    IList<T> GetAll();
    void Save(T entity);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

public class Repository<T> : IRepository<T>
{
    private readonly ISession _session;

    public Repository(ISession session)
    {
        _session = session;
    }

    public IList<T> GetAll() => _session.Query<T>().ToList();

    public void Add(T entity)
    {
        var tx = _session.BeginTransaction();
        _session.Save(entity);
        tx.Commit();
    }

    public void Update(T entity)
    {
        var tx = _session.BeginTransaction();
        _session.Update(entity);
        tx.Commit();
    }

    public void Delete(T entity)
    {
        var tx = _session.BeginTransaction();
        _session.Delete(entity);
        tx.Commit();
    }

    public void Save(T entity)
    {
        var tx = _session.BeginTransaction();
        _session.SaveOrUpdate(entity);
        tx.Commit();
    }
}