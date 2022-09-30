using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;

namespace TrainManagementSystemAPI.Services
{
    public interface IStationService: IRepository<Station>
    {
    }
    public class StationService : Repository<Station>, IStationService
    {
        public StationService(TrainManagementSystemContext trainManagementSystemContext) : base(trainManagementSystemContext)
        {
        }
    }
}
