using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Models
{
    public class Attendances
    {
        [Key]
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public string ScheduleId { get; set; }
        public Boolean IsPresent { get; set; }
        public string Note { get; set; }
    }
}
