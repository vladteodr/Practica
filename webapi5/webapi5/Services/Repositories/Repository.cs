using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using webapi5.Contexts;
using webapi5.Entities;
using webapi5.Interfaces;

namespace webapi5.Services.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly RoomsContext _context;
        public Repository(RoomsContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var _deleted = await _context.Set<TEntity>().FindAsync(id);
            if (_deleted == null)
                return null;
            _deleted.IsDeleted = true;
            _context.Set<TEntity>().Update(_deleted);
            return _deleted;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _context.Set<TEntity>().Where(entity => !entity.IsDeleted).ToListAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(entity => !entity.IsDeleted).Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
            return entity;
        }
    }
}
