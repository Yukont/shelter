using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    internal class EventScheduleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DateOf { get; set; }

        public TimeSpan TimeOf { get; set; }

        public string LocationOfEvent { get; set; } = null!;

        public string Descriptions { get; set; } = null!;
    }
}
