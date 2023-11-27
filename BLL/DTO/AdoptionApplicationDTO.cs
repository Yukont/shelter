using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AdoptionApplicationDTO
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public string UserName { get; set; } = null!;

        public int IdAnimal { get; set; }

        public string AnimalName { get; set; } = null!;

        public int IdStatus { get; set; }

        public string Status { get; set; } = null!;
    }
}
