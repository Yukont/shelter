using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task RemoveUser(int userId);
        Task<UserDTO> GetUserById(int userId);
        Task<IEnumerable<UserDTO>> GetAllUsers();
    }
}
