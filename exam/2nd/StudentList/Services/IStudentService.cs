using Microsoft.EntityFrameworkCore;
using StudentList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentList
{
    public interface IStudentService : IRepository<Student> 
    {
        Task<List<Student>> GetTeachers();
        Task<int> Update(int id,Student student );

        Task<bool> Delete(int id);
    }
    public class StudentService :Repository<Student>, IStudentService
    {
        public StudentService(LiveCodingContext context): base(context)
        {

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await base.GetById(id);
            await base.Delete(obj);
            return true;
        }

        public async Task<List<Student>> GetTeachers()
        {
            return await context.Students.Include(x => x.Standard).Include(x => x.Teacher).ToListAsync();
        }

        public async Task<int> Update(int id, Student student)
        {
            var obj = await base.GetById(id);
            obj.RollNo = student.RollNo;
            obj.FirstName = student.FirstName;
            obj.LastName = student.LastName;
            obj.Gender = student.Gender;
            obj.StandardId = student.StandardId;
            obj.TeacherId = student.TeacherId;
            await base.Update(obj);
            return obj.StudentId;
        }
    }
}
