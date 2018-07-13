using System;
using System.Linq;

namespace Project.Layer.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        void Atualizar(TEntity obj);
        void SalvarTodos();
        void Adicionar(TEntity obj);
        void Excluir(Func<TEntity, bool> predicate);

        void Excluir(TEntity obj);

        IQueryable<TEntity> GetEntitys(Func<TEntity, bool> predicate, string[] navigationProperties,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        void ExcluirPorId(int id);

        void Dispose();

        void SetDeletedState(TEntity entitade);

    }
}
