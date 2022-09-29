using JWT_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Assignment
{
     public interface IDoctorService : IRepository<Doctor>
    {
        Task<int> Update(int id, Doctor doctor);

        Task<bool> Delete(int id);
    }
    public class DoctorService : Repository<Doctor>, IDoctorService
    {
        public DoctorService(HospitalContext hospital): base(hospital)
        {

        }


        public async Task<bool> Delete(int id)
        {
            var obj = await base.GetbyId(id);
            await base.Delete(obj);
            return true;
        }

        public async Task<int> Update(int id, Doctor doctor)
        {
            var obj = await base.GetbyId(id);
            obj.DoctorName = doctor.DoctorName;
            await base.Update(obj);
            return obj.DoctorId;
        }
    }
}
