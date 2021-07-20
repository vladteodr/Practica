using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.DTOs
{
    public class RoomDTO
    {
        [Required]
        public Guid Id { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }

        [Required]
        public double M2 { get; set; }
        [Required]
        public double Pret { get; set; }
    }
}
