using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Models
{
    public class Courses
    {
        [Key]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
