using System.ComponentModel.DataAnnotations;

namespace shelter.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(5, ErrorMessage = "Пароль должен иметь длину больше 5 символов")]
        public string Password { get; set; }
    }
}
