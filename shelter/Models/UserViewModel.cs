using System.ComponentModel.DataAnnotations;

namespace shelter.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Email { get; set; }

        public int IdUserGender { get; set; }

        public string? UserGendername { get; set; }

        public int Experience { get; set; }

        public string Phone { get; set; } = null!;

        public IEnumerable<UserGenderViewModel>? UserGenders { get; set; }
    }
}