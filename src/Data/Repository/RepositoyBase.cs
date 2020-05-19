using Dominio;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class RepositoyBase<TEntity> : IRepository<TEntity> where TEntity : EntidadeBase, new()
    {

        protected readonly IContexto _contexto;

        protected RepositoyBase(IContexto contexto)
        {
            _contexto = contexto;
        }

        public Task<TEntity> Adicionar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Atualizar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<TEntity> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
