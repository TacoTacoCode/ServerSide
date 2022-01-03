using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using PRC_Ass.Repositories;
using PRC_Ass.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Services
{
    public partial interface ICourseService : IBaseService<Courses>
    {
        Task<List<Courses>> GetAllCourse();
        Task<List<Courses>> SearchCourseByName(string name);
        Task<Courses> CreateCourse(Courses course);
        Task<Courses> UpdateCourse(Courses course);
        Task<Courses> DeleteCourse(string id);
        Task<Courses> GetCourseById(string id);
    }
    public partial class CourseService : BaseServices<Courses>, ICourseService
    {
        public CourseService(ICourseRepository repository) : base(repository)
        {
        }
        public async Task<List<Courses>> GetAllCourse()
        {
            var listCourse = await Get().ToListAsync();
            return listCourse;
        }

        public async Task<List<Courses>> SearchCourseByName(string name)
        {
            var course = await Get(x => x.CourseName.ToLower().Contains(name)).ToListAsync();
            return course;
        }

        public async Task<Courses> CreateCourse(Courses course)
        {
            await CreateAsyn(course);
            return course;
        }

        public async Task<Courses> UpdateCourse(Courses course)
        {
            var acc = await Get(x => x.CourseId == course.CourseId).FirstOrDefaultAsync();
            if (acc != null)
            {
                if (course.CourseName != null)
                {
                    acc.CourseName = course.CourseName;
                }
                await UpdateAsync(acc);
                return acc;
            }
            else
            {
                return null;
            }
        }

        public async Task<Courses> DeleteCourse(string id)
        {
            var acc = await Get(x => x.CourseId == id).FirstOrDefaultAsync();
            if (acc != null)
            {
                await DeleteAsync(acc);
                //acc. = false;
                //await UpdateAsync(acc);
                return acc;
            }
            else
            {
                return null;
            }
        }

        public async Task<Courses> GetCourseById(string id)
        {
            return await Get(x => x.CourseId == id).FirstOrDefaultAsync();
        }
    }
}
