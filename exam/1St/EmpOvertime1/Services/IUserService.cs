using EmpOvertime1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpOvertime1
{
    public interface IUserService:IRepository<User>
    {
        Task<List<VOvertime>> GetovertimebyId();
    }
    public class UserService : Repository<User>, IUserService
    {
        public UserService(MINIPROJECTContext context):base(context)
        {

        }

        public async Task<List<VOvertime>> GetovertimebyId()
        {
            return await context.VOvertimes.ToListAsync();
        }
    }
}
