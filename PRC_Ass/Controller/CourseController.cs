using Microsoft.AspNetCore.Mvc;
using PRC_Ass.Models;
using PRC_Ass.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService ;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var acc = await _courseService.GetAllCourse();
            return Ok(acc);
        }

        [HttpGet]
        [Route("/api/GetCoursesByLikeName/{name}")]
        public async Task<IActionResult> GetCoursesByLikeName(string name)
        {
            var cou = await _courseService.SearchCourseByName(name);
            return Ok(cou);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourses([FromBody] Courses cou)
        {
            try
            {
                var cous = await _courseService.CreateCourse(cou);
                return Ok(cous);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.ToString().Contains("duplicate"))
                    return Conflict("This course is created before");
                return BadRequest();
            }
           
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourses([FromBody] Courses cou)
        {
            var cous = await _courseService.UpdateCourse(cou);
            return Ok(cous);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var accs = await _courseService.DeleteCourse(id);
            if (accs != null)
            {
                return Ok(accs);
            }
            else
            {
                return NotFound("Cannot found id");
            }
        }

        [HttpGet]
        [Route("/api/GetCourseById/{id}")]
        public async Task<IActionResult> GetCourseById(string id)
        {
            var cou = await _courseService.GetCourseById(id);
            if(cou != null)
            {
                return Ok(cou);
            }
            else
            {
                return NotFound("Cannot found course");
            }
        }
    }
}
