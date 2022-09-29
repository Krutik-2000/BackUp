using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service
{
    public interface ICategoryService:IRepository<Category>
    {
        Task<int> Update(int id,Category category);
        Task<bool> Delete(int id);

    }
    public class CategoryService : Repository<Category>, ICategoryService
    {
        public CategoryService(LiveCoding2Context context) : base(context)
        {
        }
        public async Task<bool> Delete(int id)
        {
            var obj = await base.GetById(id);
            await base.Delete(obj);
            return true;
        }



        public async Task<int> Update(int id, Category category)
        {
            var obj = await base.GetById(id);
            obj.CategoryName = category.CategoryName;
            await base.Update(obj);
            return obj.CategoryId;
        }
    }
}
