using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    internal class VeterinarianDTO
    {
        public int Id { get; set; }

        public int IdStaff { get; set; }

        public string StaffName { get; set; } = null!;

        public string StaffRoleName { get; set; } = null!;

        public string Contacts { get; set; } = null!;

        public string WorkSchedule { get; set; } = null!;

        public int IdPosition { get; set; }

        public string PositionName { get; set; } = null!;

        public int IdClinic { get; set; }

        public string ClinicName { get; set; } = null!;

        public int IdSpeciallization { get; set; }

        public string SpeciallizationName { get; set; } = null!;

        public int Experience { get; set; }
    }
}
