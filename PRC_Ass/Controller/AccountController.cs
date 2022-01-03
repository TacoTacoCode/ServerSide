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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService ;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        [Route("/api/GetAllStudent")]
        public async Task<IActionResult> GetAllStudentAccount()
        {
            var acc = await _accountService.GetAllStudent();
            return Ok(acc);
        }
        [HttpGet]
        [Route("/api/GetAllTeacher")]
        public async Task<IActionResult> GetAllTeacherAccount()
        {
            var acc = await _accountService.GetAllTeacher();
            return Ok(acc);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var acc = await _accountService.GetAllAccount();
            return Ok(acc);
        }
        [HttpPost]
        [Route("/api/Login")]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            var acc = await _accountService.Login(username, password);
            if(acc != null)
            {
                acc.Password = string.Empty;
                return Ok(acc);
            }
            else
            {
                return NotFound("Username or password is wrong");
            }
        }
        [HttpGet]
        [Route("/api/GetStudentsByLikeName/{name}")]
        public async Task<IActionResult> GetStudentsByLikeName(string name)
        {
            var accs = await _accountService.GetStudentsByName(name);
            return Ok(accs);
        }
        [HttpGet]
        [Route("/api/GetAccountByID/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var accs = await _accountService.GetAccountByID(id);
            return Ok(accs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccounts([FromBody] Accounts acc)
        {
            var accs = await _accountService.CreateAccount(acc);
            if (accs != null)
                return Ok(accs);
            else
                return Conflict("Duplicate Username or Password");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAccounts([FromBody] Accounts acc)
        {
            var accs = await _accountService.UpdateAccount(acc);
            return Ok(accs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAccounts(int id)
        {
            var accs = await _accountService.DeleteAccount(id);
            if(accs!= null)
            {
                return Ok(accs);
            }
            else
            {
                return NotFound("Cannot found id");
            }
        }
    }
}
