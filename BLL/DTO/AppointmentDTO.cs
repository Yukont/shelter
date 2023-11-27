using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public int IdVeterinarian { get; set; }

        public string VeterinarianName { get; set; } = null!;

        public int IdAnimal { get; set; }

        public string AnimalName { get; set; } = null!;

        public string Illnesses { get; set; } = null!;

        public string Descriptions { get; set; } = null!;

        public string Prescriptions { get; set; } = null!;

        public DateTime DateOf { get; set; }
    }
}
