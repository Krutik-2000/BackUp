using Microsoft.EntityFrameworkCore;
using StudentList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentList
{
    public interface ITeacherService:IRepository<ClassTeacher>
    {
        Task<List<ClassTeacher>> GetTeacherByStdId(int id);
    }
    public class TeacherService : Repository<ClassTeacher>,ITeacherService
    {
        public TeacherService(LiveCodingContext context) : base(context)
        {
           
        }
        public async Task<List<ClassTeacher>> GetTeacherByStdId(int id)
        {
            var obj = await context.ClassTeachers.Where(x => x.StandardId == id).ToListAsync();
            return obj;
        }
    }
}
