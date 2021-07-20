using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.Entities
{
    public class RoomEntity: BaseEntity
    {

        [Required(ErrorMessage = "Trebuie sa adaugi aria.")]
        public double M2 { get; set; }

        [Required(ErrorMessage = "Trebuie sa adaugi un pret.")]
        public double Pret { get; set; }


        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
