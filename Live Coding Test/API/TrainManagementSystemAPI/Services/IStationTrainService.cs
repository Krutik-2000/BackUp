using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;

namespace TrainManagementSystemAPI.Services
{
    public interface IStationTrainService:IRepository<StationTrain>
    {
        Task<List<StationTrain>> GetStationTrain();
    }
    public class StationTrainService : Repository<StationTrain>, IStationTrainService
    {
        public StationTrainService(TrainManagementSystemContext trainManagementSystemContext) : base(trainManagementSystemContext)
        {
        }

        public async Task<List<StationTrain>> GetStationTrain()
        {
            return await trainManagementSystemContext.StationTrains.Include(x => x.Train).Include(y => y.Station).ToListAsync();
        }
    }
}
