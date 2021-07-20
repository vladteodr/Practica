using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.Controllers
{
    public class UserRegisterDTO
    {
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
