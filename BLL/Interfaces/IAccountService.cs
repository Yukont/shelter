using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<ClaimsIdentity> Register(AuthDTO authDTO, UserDTO userDTO);

        Task<ClaimsIdentity> Login(AuthDTO authDTO);
        Task<bool> CheakLoginAsync(string input);
    }
}
