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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService ;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSchedule()
        {
            var acc = await _scheduleService.GetAllSchedule();
            return Ok(acc);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSchedule(string cId, string sId, DateTime startDate, int teacherId)
        {
            try {
                var acc = await _scheduleService.CreateSchedule(cId, sId, startDate, teacherId);
                return Ok(acc);
            }
            catch (Exception ex)
            {
                if(ex.InnerException.ToString().Contains("duplicate"))
                    return Conflict("The teacher is not free at this time");
                return BadRequest();
            }
           
        }
        [HttpGet]
        [Route("/api/GetTodaySchedule/{id}")]
        public async Task<IActionResult> GetTodaySchedule(int id)
        {
            var sches = await _scheduleService.GetScheduleForTeacher(id);
            return Ok(sches);
        }
        [HttpGet]
        [Route("/api/GetAllFirstSchedule")]
        public async Task<IActionResult> GetAllFirstSchedule()
        {
            var acc = await _scheduleService.GetAllSchedule();
            acc = acc.FindAll(x => x.ItemId.EndsWith("slot1")).ToList();
            return Ok(acc);
        }
    }
}
