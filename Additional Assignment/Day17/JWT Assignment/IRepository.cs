using JWT_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Assignment
{
     public interface IRepository<TDB> where TDB:class
    {
        Task<TDB> Add(TDB dB);
        Task<List<TDB>> Get();

        Task<TDB> Update(TDB dB);

        Task<bool> Delete(TDB dB);

        Task<TDB> GetbyId(int id);

    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private HospitalContext hospital { get; set; }

        public Repository(HospitalContext context)
        {
            hospital = context;
        }

        public async Task<T> Add(T dB)
        {
            hospital.Add(dB);
            await hospital.SaveChangesAsync();
            return dB;
        }

        public async Task<List<T>> Get()
        {
            var db = await hospital.Set<T>().ToListAsync();
            return db;
        }

        public async Task<T> Update(T dB)
        {
            hospital.Update(dB);
            await hospital.SaveChangesAsync();
            return dB;
        }

        public async Task<bool> Delete(T dB)
        {
            hospital.Remove(dB);
            await hospital.SaveChangesAsync();
            return true;
        }

        public async Task<T> GetbyId(int id)
        {
            var obj = await hospital.Set<T>().FindAsync(id);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new Exception("Data not found!");
            }
        }

          
    }
}
