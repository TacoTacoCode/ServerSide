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
    public partial interface IAttendanceService : IBaseService<Attendances>
    {
        Task CreateAttendance(string scheduleId, List<int> listStudentId);
        Task<Boolean> UpdateAttendance(int studentId, string scheduleId);
        Task<int> UpdateAttendance(List<Attendances> attendances);
        Task<List<Attendances>> GetListAttendance(string scheduleId);
    }
    public partial class AttendanceService : BaseServices<Attendances>, IAttendanceService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public AttendanceService(IAttendanceRepository repository, IScheduleRepository scheduleRepository) : base(repository)
        {
            _scheduleRepository = scheduleRepository;
            
        }

        public async Task CreateAttendance(string scheduleId, List<int> listStudentId)
        {
            var realID = scheduleId.Substring(0, scheduleId.IndexOf("slot") + 4); 
            foreach (var studentId in listStudentId)
            {
                var check = await Get(x => x.StudentId == studentId && x.ScheduleId.Contains(scheduleId)).ToListAsync();
                if (check.Count > 0)
                {
                    continue;
                }
                var listSchdule = await _scheduleRepository.Get(x => x.ItemId.Contains(realID)).ToListAsync();
                foreach (var item in listSchdule)
                {
                    Attendances attendances = new Attendances
                    {
                        StudentId = studentId,
                        ScheduleId = item.ItemId,
                        IsPresent = false
                    };
                    await CreateAsyn(attendances);
                }
            }
            return;
        }
        public async Task<Boolean> UpdateAttendance(int studentId, string scheduleId)
        {
            var attendance = await Get(x => x.StudentId == studentId && x.ScheduleId == scheduleId).FirstOrDefaultAsync();
            if(attendance != null)
            {
                attendance.IsPresent = true;
                await UpdateAsync(attendance);
                return true;
            }
            return false;
        }
        public async Task<int> UpdateAttendance(List<Attendances> attendances)
        {
            int count = 0;
            foreach (var att in attendances)
            {
                var attendance = await Get(x => x.StudentId == att.StudentId && x.ScheduleId == att.ScheduleId).FirstOrDefaultAsync();
                if (attendance != null)
                {
                    attendance.IsPresent = att.IsPresent;
                    await UpdateAsync(attendance);
                    count++;
                }
            }
            return count;

        }
        public async Task<List<Attendances>> GetListAttendance(string scheduleId){
            var rs = await Get(x => x.ScheduleId == scheduleId).ToListAsync();
            return rs;
        }
    }
}