using KARYA.CORE.Abstarct;
using KARYA.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KARYA.CORE.Concrete.EntityFramework
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : CoreEntity, new() where TContext : DbContext, new()
    {
        public int SCOPE_IDENTY_ID { get; set; }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
        }

        public async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await (filter == null ? context.Set<TEntity>().ToListAsync() : context.Set<TEntity>().Where(filter).ToListAsync());
            }
        }

        public async Task Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }
        }

        public async Task Add(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var item in entities)
                {
                    var addedEntity = context.Entry(item);
                    addedEntity.State = EntityState.Added;
                }
                
                await context.SaveChangesAsync();
                
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);

                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;

            }
        }

        public async Task Update(IEnumerable<TEntity> entities)
        {
            using ( var context = new TContext())
            {
                foreach (var item in entities)
                {
                    var updatedEntity = context.Entry(item);
                    updatedEntity.State = EntityState.Modified;
                }

                await context.SaveChangesAsync();


            }
        }

        public async Task Update(TEntity entity, IEnumerable<string> fields)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                foreach (var field in fields)
                {
                    updatedEntity.Property(field).IsModified = true;
                }

                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }

        }

        public async Task Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;
            }
        }

        public async Task Delete(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entities);

                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await (filter == null ? context.Set<TEntity>().CountAsync() : context.Set<TEntity>().CountAsync(filter));
            }
        }


    }
}
