using FruitStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FruitStore.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Inserir(TEntity obj);

        void Atualizar(TEntity obj);

        void Excluir(int id);

        IList<TEntity> Obter();
        IList<TEntity> Obter(Expression<Func<TEntity, bool>> predicado);

        TEntity Obter(int id);
    }
}
