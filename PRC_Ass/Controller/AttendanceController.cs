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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAttendance(string scheduleId, List<int> listStudentId)
        {
            scheduleId = scheduleId.Replace("%2F", "-");
            await _attendanceService.CreateAttendance(scheduleId, listStudentId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAttendance(List<Attendances> attendances)
        {
            var result = await _attendanceService.UpdateAttendance(attendances);
            return Ok(result);
        }
        [HttpGet]
        [Route("/api/GetListAttendance/{scheduleId}")]
        public async Task<IActionResult> GetListAttendance(string scheduleId)
        {
            scheduleId = scheduleId.Replace("%2F", "-");
            var result = await _attendanceService.GetListAttendance(scheduleId);
            return Ok(result);
        }
    }
}
