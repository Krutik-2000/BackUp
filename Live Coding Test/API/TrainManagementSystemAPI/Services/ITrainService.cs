using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;

namespace TrainManagementSystemAPI.Services
{
    public interface ITrainService:IRepository<Train>
    {
    }
    public class TrainService : Repository<Train>, ITrainService
    {
        public TrainService(TrainManagementSystemContext trainManagementSystemContext) : base(trainManagementSystemContext)
        {
        }
    }
}
