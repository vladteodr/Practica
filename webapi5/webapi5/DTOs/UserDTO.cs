using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.DTOs
{
    public class UserDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Prenume { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Parola { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

    }
}
