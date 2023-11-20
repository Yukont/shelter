using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    internal class StaffDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int IdStaffRole { get; set; }

        public string StaffRoleName { get; set; } = null!;

        public string Contacts { get; set; } = null!;

        public string WorkSchedule { get; set; } = null!;
    }
}
