using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.Entities
{
    public class UserEntity: BaseEntity
    {
        [Required(ErrorMessage = "Trebuie sa adaugi un nume.")]
        public string Nume { get; set; }


        [Required(ErrorMessage = "Trebuie sa adaugi un prenume.")]
        public string Prenum { get; set; }


        [Required(ErrorMessage = "Trebuie sa adaugi un Email.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Trebuie sa adaugi o parola.")]
        public string Parola { get; set; }


        public bool IsAdmin { get; set; }

    }
}
