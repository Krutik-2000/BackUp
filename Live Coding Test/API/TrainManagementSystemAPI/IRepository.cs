using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;

namespace TrainManagementSystemAPI
{
     public  interface IRepository<TEntity> where TEntity:class
    {
        Task<List<TEntity>> Get();
        TEntity GetById(int id);

        Task<TEntity> Post(TEntity entity);

        Task<TEntity> Update(TEntity entity, TEntity entity1);

        Task<TEntity> Delete( TEntity entity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public TrainManagementSystemContext trainManagementSystemContext { get; set; }
        public Repository(TrainManagementSystemContext trainManagementSystemContext)
        {
            this.trainManagementSystemContext = trainManagementSystemContext;
        }

        public async Task<List<T>> Get()
        {
            return await trainManagementSystemContext.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return trainManagementSystemContext.Set<T>().Find(id);
        }

        public async Task<T> Post(T entity)
        {
            trainManagementSystemContext.Add(entity);
            await trainManagementSystemContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity, T entity1)
        {
            trainManagementSystemContext.Entry<T>(entity).CurrentValues.SetValues(entity1);
            await trainManagementSystemContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            trainManagementSystemContext.Remove(entity);
            await trainManagementSystemContext.SaveChangesAsync();
            return entity;
        }
    }
}
