using EMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS
{
    public interface IAttendanceService:IRepository<Attendance>
    {
        Task<List<Attendance>> GetAttendancesbyUserID(int id);

        Task<List<TypeOfObject>> GetAttendanceValue(int id);
    }
    public class AttendanceService : Repository<Attendance>, IAttendanceService
    {
        public AttendanceService(EmployeeContext employeeContext) : base(employeeContext)
        {
        }

        public async Task<List<Attendance>> GetAttendancesbyUserID(int id)
        {
            return await employeeContext.Attendances.Include(x => x.Attendance1Navigation).Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<List<TypeOfObject>> GetAttendanceValue(int id)
        {
            return await employeeContext.TypeOfObjects.Where(x => x.ObjectId == id).ToListAsync();
        }
    }
}
