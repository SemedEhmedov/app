using Business.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Intefaces
{
    public interface IUserService
    {
        public Task Register(RegisterDto dto);
        public Task<string> Login(LoginDto dto);
    }
}
