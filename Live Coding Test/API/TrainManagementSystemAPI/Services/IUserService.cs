using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;

namespace TrainManagementSystemAPI.Services
{
    public interface IUserService:IRepository<User>
    {
    }
    public class UserService : Repository<User>, IUserService
    {
        public UserService(TrainManagementSystemContext trainManagementSystemContext) : base(trainManagementSystemContext)
        {
        }
    }
}
