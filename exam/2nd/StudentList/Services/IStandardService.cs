using StudentList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentList
{
    public  interface IStandardService:IRepository<Standard>
    {
        Task<bool> Delete(int id);
       
    }
    public class StandardService: Repository<Standard>, IStandardService
    {
        public StandardService(LiveCodingContext context) : base(context)
        {

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await base.GetById(id);
            await base.Delete(obj);
            return true;
        }

       
    }
}
