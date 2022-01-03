using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Models
{
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public Boolean IsActive { get; set; }
    }
}
