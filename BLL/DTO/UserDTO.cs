using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int IdUserRole { get; set; }

        public string UserRoleName { get; set; } = null!;

        public string? Address { get; set; }

        public string? Email { get; set; }

        public int IdUserGender { get; set; }

        public string UserGendername { get; set; } = null!;

        public int Experience { get; set; }

        public string Phone { get; set; } = null!;

        public int IdAuth { get; set; }

        public IEnumerable<UsersGenderDTO>? UserGenders { get; set; }
    }
}
