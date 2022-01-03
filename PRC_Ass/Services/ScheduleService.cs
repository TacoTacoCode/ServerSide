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
    public partial interface IScheduleService : IBaseService<Schedule>
    {
        Task<List<Schedule>> GetAllSchedule();
        Task<List<Schedule>> CreateSchedule(string courseId, string shiftId, DateTime time, int teacherId);
        Task<List<Schedule>> GetScheduleForTeacher(int teacherId);
    }
    public partial class ScheduleService : BaseServices<Schedule>, IScheduleService
    {
        public ScheduleService(IScheduleRepository repository) : base(repository) {
        
        }

        public async Task<List<Schedule>> GetAllSchedule()
        {
            var listSchedule = await Get().ToListAsync();
            return listSchedule;
        }

        public async Task<List<Schedule>> CreateSchedule(string courseId, string shiftId, DateTime time, int teacherId)
        {
            var timeStore = time;
            var dayInWeek = time.DayOfWeek;
            List<Schedule> ls = new List<Schedule>();
            if (dayInWeek.ToString().Contains("Tuesday") || dayInWeek.ToString().Contains("Thursday") || dayInWeek.ToString().Contains("Saturday"))
            {
                for (int i = 1; i <= 30; i++)
                {
                    var diw = timeStore.DayOfWeek;
                    if (diw.ToString().Contains("Saturday"))
                    {
                        string scheduleId = courseId + "" + shiftId + "" + time.Day + "-" + time.Month + "-" + time.Year + "" + "slot" + i;
                        Schedule sche = new Schedule
                        {
                            ItemId = scheduleId,
                            CourseId = courseId,
                            ShiftId = shiftId,
                            Date = timeStore,
                            teacherId = teacherId
                            
                        };
                        ls.Add(sche);
                        await CreateAsyn(sche);
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());
                        
                        timeStore = timeStore.AddDays(3);
                        //timeStore.DayOfWeek.ToString
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());
                    }
                    if (diw.ToString().Contains("Tuesday") || diw.ToString().Contains("Thursday"))
                    {
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());
                        string scheduleId = courseId + "" + shiftId + "" + time.Day + "-" + time.Month + "-" + time.Year + "" + "slot" + i;
                        Schedule sche = new Schedule
                        {
                            ItemId = scheduleId,
                            CourseId = courseId,
                            ShiftId = shiftId,
                            Date = timeStore,
                            teacherId = teacherId
                        };
                        ls.Add(sche);
                        await CreateAsyn(sche);
                        timeStore = timeStore.AddDays(2);
                        //timeStore.DayOfWeek.ToString
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());
                    }
                
                }
                return ls;
            }
            if (dayInWeek.ToString().Contains("Monday") || dayInWeek.ToString().Contains("Wednesday") || dayInWeek.ToString().Contains("Friday"))
            {
                for (int i = 1; i <= 30; i++)
                {
                    var diw = timeStore.DayOfWeek;
                    if (diw.ToString().Contains("Friday"))
                    {
                        string scheduleId = courseId + "" + shiftId + "" + time.Day + "-" + time.Month + "-" + time.Year + "" + "slot" + i;
                        Schedule sche = new Schedule
                        {
                            ItemId = scheduleId,
                            CourseId = courseId,
                            ShiftId = shiftId,
                            Date = timeStore,
                            teacherId = teacherId

                        };
                        ls.Add(sche);
                        await CreateAsyn(sche);
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());

                        timeStore = timeStore.AddDays(3);
                        //timeStore.DayOfWeek.ToString
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());
                    }
                    if (diw.ToString().Contains("Monday") || diw.ToString().Contains("Wednesday"))
                    {
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());
                        string scheduleId = courseId + "" + shiftId + "" + time.Day + "-" + time.Month + "-" + time.Year + "" + "slot" + i;
                        Schedule sche = new Schedule
                        {
                            ItemId = scheduleId,
                            CourseId = courseId,
                            ShiftId = shiftId,
                            Date = timeStore,
                            teacherId = teacherId

                        };
                        ls.Add(sche);
                        await CreateAsyn(sche);
                        timeStore = timeStore.AddDays(2);
                        //timeStore.DayOfWeek.ToString
                        //Console.WriteLine(timeStore.DayOfWeek.ToString());
                    }

                }
                return ls;
            }
            return null;
        }
        public async Task<List<Schedule>> GetScheduleForTeacher(int teacherId) {
            var today = DateTime.Now.Date;
            var previos = DateTime.Now.Date.AddDays(-2);
            if (today.DayOfWeek.ToString().Equals("Monday") || today.DayOfWeek.ToString().Equals("Tuesday"))
            {
                previos = DateTime.Now.Date.AddDays(-1);
            }

            var sch = await Get(x => x.teacherId == teacherId && (x.Date.Equals(today) || x.Date.Equals(previos))).ToListAsync();
            return sch;
        }

    }
}