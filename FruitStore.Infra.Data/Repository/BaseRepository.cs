using FruitStore.Domain.Entities;
using FruitStore.Domain.Interfaces;
using FruitStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FruitStore.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqLiteContext _context;

        public BaseRepository(SqLiteContext context)
        {
            _context = context;
        }

        public void Atualizar(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            _context.Set<TEntity>().Remove(Obter(id));
            _context.SaveChanges();
        }

        public void Inserir(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public IList<TEntity> Obter() =>
            _context.Set<TEntity>().ToList();

        public TEntity Obter(int id) =>
            _context.Set<TEntity>().Find(id);

        public IList<TEntity> Obter(Expression<Func<TEntity, bool>> predicado)
            => _context.Set<TEntity>().Where(predicado).ToList();
    }
}
