using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;

namespace TrainManagementSystemAPI.Services
{
    public interface IBookingService:IRepository<Booking>
    {
    }
    public class BookingService : Repository<Booking>, IBookingService
    {
        public BookingService(TrainManagementSystemContext trainManagementSystemContext) : base(trainManagementSystemContext)
        {
        }
    }
}
