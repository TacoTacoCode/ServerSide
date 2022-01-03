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
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService ;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShift()
        {
            var acc = await _shiftService.GetAllShifts();
            return Ok(acc);
        }
        [HttpGet]
        [Route("/api/GetShiftById/{id}")]
        public async Task<IActionResult> GetShiftById(string id)
        {
            var cou = await _shiftService.GetShiftById(id);
            return Ok(cou);
        }
    }
}
