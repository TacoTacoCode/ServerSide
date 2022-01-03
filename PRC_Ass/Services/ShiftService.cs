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
    public partial interface IShiftService : IBaseService<Shifts>
    {
        Task<List<Shifts>> GetAllShifts();
        Task<Shifts> UpdateShift(Shifts shi);
        Task<Shifts> GetShiftById(string id);
    }
    public partial class ShiftService : BaseServices<Shifts>, IShiftService
    {
        public ShiftService(IShiftRepository repository) : base(repository) {     
        }

        public async Task<List<Shifts>> GetAllShifts()
        {
            var listShift = await Get().ToListAsync();
            return listShift;
        }

        public async Task<Shifts> GetShiftById(string id)
        {
            return await Get(x => x.ShiftId == id).FirstOrDefaultAsync();
        }

        public async Task<Shifts> UpdateShift(Shifts shift)
        {
            var shi = await Get(x => x.ShiftId == shift.ShiftId).FirstOrDefaultAsync();
            if (shi != null)
            {
                if (shift.StartTime != null)
                {
                    shi.StartTime = shift.StartTime;
                }
                if (shift.EndTime != null)
                {
                    shi.EndTime = shift.EndTime;
                }
                await UpdateAsync(shi);
                return shi;
            }
            else
            {
                return null;
            }
        }
    }
}
