using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Models
{
    public class Schedule
    {
        [Key]
        public string ItemId { get; set; }
        public string CourseId { get; set; }
        public string ShiftId { get; set; }
        public DateTime Date { get; set; }
        public int teacherId { get; set; }
    }
}
