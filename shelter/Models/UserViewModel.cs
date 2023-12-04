using System.ComponentModel.DataAnnotations;

namespace shelter.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

/*        public int IdUserRole { get; set; }

        public string UserRoleName { get; set; } = null!;*/

        public string? Address { get; set; }

        public string? Email { get; set; }

        public int IdUserGender { get; set; }

        public string? UserGendername { get; set; }

        public int Experience { get; set; }

        public string Phone { get; set; } = null!;

        /*public int IdAuth { get; set; }*/
        public IEnumerable<UserGenderViewModel>? UserGenders { get; set; }
    }
}