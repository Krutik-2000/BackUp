using EMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<List<TEntity>> Get();
        TEntity GetById(int id);
        Task<TEntity> Post(TEntity entity);
        TEntity Update(TEntity entity,TEntity entity1);
        Task<TEntity> Delete(TEntity entity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public EmployeeContext employeeContext { get; set; }
        public Repository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public async Task<List<T>> Get()
        {
            return await employeeContext.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return employeeContext.Set<T>().Find(id);
        }

        public async Task<T> Post(T entity)
        {
           employeeContext.Add(entity);
            await employeeContext.SaveChangesAsync();
            return entity;
        }

        public T Update(T entity, T entity1)
        {
            employeeContext.Entry<T>(entity).CurrentValues.SetValues(entity1);
             employeeContext.SaveChanges();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            employeeContext.Remove(entity);
            await employeeContext.SaveChangesAsync();
            return entity;
        }
    }
}
