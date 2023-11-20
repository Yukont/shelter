using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    internal class ReviewDTO
    {
        public int Id { get; set; }

        public DateTime DateOf { get; set; }

        public int? IdUser { get; set; }

        public string UserName { get; set; } = null!;

        public int Rating { get; set; }

        public string Review1 { get; set; } = null!;
    }
}
