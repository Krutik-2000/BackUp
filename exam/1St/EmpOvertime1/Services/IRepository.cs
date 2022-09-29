using EmpOvertime1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpOvertime1
{
    public interface IRepository<TDB> where TDB: class
    {
        Task<List<TDB>> Get();
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public MINIPROJECTContext context { get; set; }

        public Repository(MINIPROJECTContext context)
        {
            this.context = context;
        }
        public async Task<List<T>> Get()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}
