using Microsoft.EntityFrameworkCore;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<List<TEntity>> Get();

        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity entity);

        Task<bool> Delete(TEntity entity);

        Task<TEntity> Add(TEntity entity);
    }
    public class Repository<T>:IRepository<T> where T: class
    {
        public LiveCoding2Context context { get; set; }

        public Repository(LiveCoding2Context context)
        {
            this.context = context;
        }

        public async Task<T> Add(T entity)
        {
           context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> Get()
        {
            return await context.Set<T>().ToListAsync();

        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
