using Microsoft.EntityFrameworkCore;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service
{
    public interface IAllDataService:IRepository<AllDatum>
    {
        Task<int> Update(int id, AllDatum allDatum);
        //Task<AllDatum> UpdateEntities(int id);
        List<AllDatum> UpdateEntities(int id);

        Task<bool> DeleteData(int id);
    }
    public class AllDataService : Repository<AllDatum>, IAllDataService
    {
        public AllDataService(LiveCoding2Context context) : base(context)
        {
        }

        public async Task<bool> DeleteData(int id)
        {
            var obj = await base.GetById(id);
            await base.Delete(obj);
            return true;
        }

        public async Task<int> Update(int id, AllDatum allDatum)
        {
            var obj = await base.GetById(id);
            
            obj.ProductName = allDatum.ProductName;
            obj.CategoryId = allDatum.CategoryId;
            obj.Price = allDatum.Price;
            obj.ProductSku = allDatum.ProductSku;
            obj.Width = allDatum.Width;
            obj.Height = allDatum.Height;
            obj.Weight = allDatum.Weight;
            obj.Icon = allDatum.Icon;
            obj.Image = allDatum.Image;
            await base.Update(obj);
            return obj.DataId;
        }

        //public async Task<AllDatum> UpdateEntities(int id)
        //{
        //    return await context.AllData.FromSqlRaw<object>("EXEC Mergedata 7", id).FirstOrDefaultAsync();
        //}

        public  List<AllDatum> UpdateEntities(int id)
        {
            LiveCoding2Context dbContext = new LiveCoding2Context();
            List<AllDatum> temp = dbContext.AllData.FromSqlRaw<AllDatum>("exec Mergedata {0}", id).ToList();
            return temp;
        }
    }
}
