using Project.CrossCutting.Exceptions;
using Project.Layer.Data.Contexto;
using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Project.Layer.Data.Repositories
{
    public abstract class RepositorioBase<TEntity> : IDisposable,
          IRepository<TEntity> where TEntity : BaseEntity
    {
        protected ProjectContext ctx = new ProjectContext();

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAllEntitys(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                   params string[] navigationProperties)
        {
            var query = ctx.Set<TEntity>().AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetDistinct(Func<TEntity, bool> predicate, IEqualityComparer<TEntity> distinct)
        {
            return GetAll().Where(predicate).Distinct(distinct).AsQueryable();
        }

        public IQueryable<TEntity> GetEntitys(Func<TEntity, bool> predicate, string[] navigationProperties,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = GetAllEntitys(orderBy, navigationProperties).Where(predicate).AsQueryable();

            return query;
        }

        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Atualizar(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SalvarTodos()
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var mensagem = new StringBuilder();

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);

                        mensagem.AppendLine($"Campo: {ve.PropertyName}, Erro: {ve.ErrorMessage}");
                    }
                }

                throw new BusinessException(mensagem.ToString());
            }
        }

        public void Adicionar(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public void ExcluirPorId(int id)
        {
            this.Excluir(g => g.Id == id);
            this.SalvarTodos();
        }

        public void Excluir(TEntity obj)
        {
            ctx.Set<TEntity>().Remove(obj);
            ctx.SaveChanges();
        }

        public void SetDeletedState(TEntity entitade)
        {
            this.ctx.Entry(entitade).State = EntityState.Deleted;
        }
    }
}
