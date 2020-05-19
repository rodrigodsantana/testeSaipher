using CrossCutting;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Services
{
    public abstract class ServicoBase<TEntity> : IServiceBase<TEntity> where TEntity : EntidadeBase
    {

        protected readonly IRepository<TEntity> _repositorio;

        protected LNoty _notificacoes = new LNoty();

        protected ServicoBase(IRepository<TEntity> repositorio,LNoty notificacoes)
        {

            _notificacoes = notificacoes;
            _repositorio = repositorio;

        }

        public async Task Adicionar(TEntity entity)
        {
            await _repositorio.Adicionar(entity);
        }

        public async Task Atualizar(TEntity entity)
        {
            await _repositorio.Atualizar(entity);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositorio.Buscar(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _repositorio.ObterPorId(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _repositorio.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _repositorio.Remover(id);
        }
    }
}
