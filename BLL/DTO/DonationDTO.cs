using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    internal class DonationDTO
    {
        public int Id { get; set; }

        public DateTime DateOf { get; set; }

        public int IdUser { get; set; }

        public string UserName { get; set; } = null!;

        public int Donation1 { get; set; }
    }
}
