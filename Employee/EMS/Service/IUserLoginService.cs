using EMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS
{
    public interface IUserLoginService: IRepository<User>
    {
        Task<List<User>> GetUser();
    }
    public class UserLoginService : Repository<User>, IUserLoginService
    {
        public UserLoginService(EmployeeContext employeeContext) : base(employeeContext)
        {
        }

        public async Task<List<User>> GetUser()
        {
            return await employeeContext.Users.Include(x => x.PersonalDetails).ToListAsync();
        }
    }
}
